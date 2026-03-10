using DevExpress.XtraEditors;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportExplorer
{
    public class ReportMqttClient : MQTTclient
    {
        public DataTable C0list = new DataTable();
        private readonly DevExpress.XtraGrid.GridControl gridControl;

        public string Topic;

        private SimpleFileMqttBroker localBroker;
        private int fallbackDialogShown;
        private int fallbackSwitchInProgress;
        private bool usingLocalBroker;

        public ReportMqttClient(DevExpress.XtraGrid.GridControl gridControl = null)
        {
            this.gridControl = gridControl;

            ApplySettings();

            C0list.Columns.Add("Id", typeof(string));
            C0list.Columns.Add("datetime", typeof(DateTime));
            C0list.Columns.Add("Type", typeof(string));
            C0list.Columns.Add("Cfg", typeof(string));
            C0list.Columns.Add("DeviceID", typeof(string));
            C0list.Columns.Add("Date", typeof(string));
            C0list.Columns.Add("Order", typeof(string));
            C0list.Columns.Add("Result", typeof(string));
        }

        private void ApplySettings()
        {
            if (Reporter.Settings == null)
            {
                return;
            }

            string[] mqttUri = (Reporter.Settings.MqttUri ?? string.Empty).Split(':');
            if (mqttUri.Length > 0 && !string.IsNullOrWhiteSpace(mqttUri[0]))
            {
                BrokerUri = mqttUri[0];
            }

            if (mqttUri.Length > 1)
            {
                int configuredPort;
                if (int.TryParse(mqttUri[1], out configuredPort))
                {
                    Port = configuredPort;
                }
            }

            RootTopic = Reporter.Settings.RootTopic;
            Username = Reporter.Settings.MqttUser;
            Password = Reporter.Settings.MqttPassword;
            ClientId = Reporter.Settings.ClientId;
            DeviceId = Reporter.Settings.ClientId;
            Topic = RootTopic;
        }

        public void Init()
        {
            Subscribe(RootTopic + "#");
        }

        protected override async Task OnConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            if (usingLocalBroker)
            {
                return;
            }

            if (Interlocked.CompareExchange(ref fallbackDialogShown, 1, 0) != 0)
            {
                return;
            }

            DialogResult result = await AskForLocalBrokerAsync();
            if (result != DialogResult.Yes)
            {
                return;
            }

            _ = Task.Run(async () =>
            {
                await Task.Delay(100);
                await SwitchToLocalBrokerAsync();
            });
        }

        private async Task<DialogResult> AskForLocalBrokerAsync()
        {
            const string question = "AmiumHost nicht erreichbar! Soll eine lokale Instanz erzeugt werden?";
            const string caption = "MQTT Verbindung";

            if (gridControl != null && gridControl.IsHandleCreated)
            {
                var tcs = new TaskCompletionSource<DialogResult>();
                gridControl.BeginInvoke(new Action(() =>
                {
                    DialogResult dialogResult = XtraMessageBox.Show(
                        gridControl,
                        question,
                        caption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    tcs.TrySetResult(dialogResult);
                }));

                return await tcs.Task;
            }

            return XtraMessageBox.Show(
                question,
                caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
        }

        private async Task SwitchToLocalBrokerAsync()
        {
            if (Interlocked.CompareExchange(ref fallbackSwitchInProgress, 1, 0) != 0)
            {
                return;
            }

            try
            {
                if (usingLocalBroker)
                {
                    return;
                }

                int localPort = FindLocalBrokerPort();
                string storagePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "mqtt-data",
                    "local-retained-messages.json");

                localBroker = new SimpleFileMqttBroker(
                    port: localPort,
                    storageFilePath: storagePath);

                await localBroker.StartAsync();

                BrokerUri = "127.0.0.1";
                Port = localPort;
                Username = string.Empty;
                Password = string.Empty;

                await RestartAsync();
                Init();

                usingLocalBroker = true;
                Error = false;

                Log.Information("MQTT fallback aktiv. Lokaler Broker gestartet auf 127.0.0.1:{Port}", localPort);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lokaler MQTT-Broker konnte nicht gestartet werden.");
                ShowFallbackError(ex.Message);
                Interlocked.Exchange(ref fallbackDialogShown, 0);
            }
            finally
            {

           

                Interlocked.Exchange(ref fallbackSwitchInProgress, 0);

                string languageFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Languages.json");

                if (File.Exists(languageFilePath))
                {
                    string message = File.ReadAllText(languageFilePath);
                    Reporter.Client.Publish(Reporter.Client.RootTopic + "$babel", message, true);
                }

            }
        }

        private void ShowFallbackError(string message)
        {
            string text = "Lokaler MQTT-Broker konnte nicht gestartet werden.\r\n" + message;

            if (gridControl != null && gridControl.IsHandleCreated)
            {
                gridControl.BeginInvoke(new Action(() =>
                {
                    XtraMessageBox.Show(gridControl, text, "MQTT Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));

                return;
            }

            XtraMessageBox.Show(text, "MQTT Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int FindLocalBrokerPort()
        {
            const int preferredPort = 28883;

            if (IsPortAvailable(preferredPort))
            {
                return preferredPort;
            }

            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();

            int dynamicPort = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();

            return dynamicPort;
        }

        private bool IsPortAvailable(int port)
        {
            try
            {
                var listener = new TcpListener(IPAddress.Loopback, port);
                listener.Start();
                listener.Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNamingPolicy = new qj_NamingPolice()
            };

            if (arg.ApplicationMessage.Topic.EndsWith("$babel"))
            {
                string json = arg.ApplicationMessage.ConvertPayloadToString();
                Reporter.Language = JsonSerializer.Deserialize<LanguageLabler>(json, options);
            }

            if (arg.ApplicationMessage.Topic.Contains("$qa"))
            {
                Log.Information("MQTT: Report + " + arg.ApplicationMessage.Topic);
                string datetime = arg.ApplicationMessage.Topic.Split('/').Last();
                datetime = datetime.Substring(0, datetime.Length - 2).Replace("T", " ");
                Console.WriteLine(datetime);

                gridControl.BeginInvoke(new Action(() =>
                {
                    string json = arg.ApplicationMessage.ConvertPayloadToString();
                    Report report = JsonSerializer.Deserialize<Report>(json, options);

                    string id = report.sys["aid"];
                    string searchExpression = "Id = '" + id + "'";

                    DataRow[] idExists = C0list.Select(searchExpression);

                    if (idExists.Length > 0)
                    {
                        idExists[0]["Id"] = report.sys["aid"];
                        idExists[0]["datetime"] = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                        idExists[0]["Type"] = report.sys["type"];
                        idExists[0]["Cfg"] = report.sys["cfg"];
                        idExists[0]["DeviceID"] = report.devices[0].data["aid"];
                        idExists[0]["Date"] = report.order["date"];
                        idExists[0]["Order"] = report.order["aid"];
                        idExists[0]["Result"] = json;
                    }
                    else
                    {
                        DataRow row = C0list.NewRow();
                        row["Id"] = report.sys["aid"];
                        row["datetime"] = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                        row["Type"] = report.sys["type"];
                        row["Cfg"] = report.sys["cfg"];
                        row["DeviceID"] = report.devices[0].data["aid"];
                        row["Date"] = report.order["date"];
                        row["Order"] = report.order["aid"];
                        row["Result"] = json;
                        C0list.Rows.Add(row);
                    }
                }));
            }
        }
    }
}
