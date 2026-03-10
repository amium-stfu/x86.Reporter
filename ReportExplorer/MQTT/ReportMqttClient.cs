using MQTTnet;
using MQTTnet.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReportExplorer
{
    public class ReportMqttClient : MQTTclient
    {
        public DataTable C0list = new DataTable();
        DevExpress.XtraGrid.GridControl gridControl;
       // public languages Languages;

        public string Topic;
      //  public frmTreeView TreeView;

        public ReportMqttClient(DevExpress.XtraGrid.GridControl gridControl = null)
        {
        //TreeView = new frmTreeView();
        RootTopic = "stfu/amium/";
        Broker = "mqtt.amium.link";
        Port = 11883;
        ClientId = "stfu_ReportExplorer";
        Username = "amium";
        Password = "amium07";
        Topic = RootTopic;
    

        this.gridControl = gridControl;
        C0list.Columns.Add("Id", typeof(string));
        C0list.Columns.Add("datetime", typeof(DateTime));
        C0list.Columns.Add("Type", typeof(string));
        C0list.Columns.Add("Cfg", typeof(string));
        C0list.Columns.Add("DeviceID", typeof(string));
        C0list.Columns.Add("Date", typeof(string));
        C0list.Columns.Add("Order", typeof(string));
        C0list.Columns.Add("Result", typeof(string));


     

        }

        public void Init()
        {
            Subscribe(RootTopic + "#");
        }

        public override void OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            //TreeView.AddTopicToTree(arg.ApplicationMessage.Topic, System.Text.Encoding.UTF8.GetString(arg.ApplicationMessage.Payload));
          //  TreeView.AddTopicToTree(arg.ApplicationMessage.Topic);
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

            //if (arg.ApplicationMessage.Topic.StartsWith(RootTopic + "reports/c0"))
            //{

                if (arg.ApplicationMessage.Topic.Contains("$qa"))
                {
                Log.Information("MQTT: Report + " + arg.ApplicationMessage.Topic);
                string datetime = arg.ApplicationMessage.Topic.Split('/').Last();
                datetime = datetime.Substring(0, datetime.Length - 2).Replace("T"," ");
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
                        idExists[0]["datetime"] = DateTime.ParseExact(datetime,"yyyy-MM-dd HH:mm:ss.fff",CultureInfo.InvariantCulture);
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
                        Console.WriteLine("AddId");
                        row["Id"] = report.sys["aid"];
                        Console.WriteLine("AddType");
                        row["datetime"] = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                        row["Type"] = report.sys["type"];
                        Console.WriteLine("AddCfg");
                        row["Cfg"] = report.sys["cfg"];
                        Console.WriteLine("AddDeviceId");
                        row["DeviceID"] = report.devices[0].data["aid"];
                        Console.WriteLine("AddOrderDate " + report.order["date"]);
                        row["Date"] = report.order["date"];
                        Console.WriteLine("AddOrderId");
                        row["Order"] = report.order["aid"];
                        Console.WriteLine("AddResult");
                        row["Result"] = json;
                        C0list.Rows.Add(row);
                    }
                }));
            }
        }
    }
}
