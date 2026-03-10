using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Data;
using System.Text.Json;
using DevExpress.XtraPrinting;
using System.IO;

namespace ReportExplorer
{
    public class MQTTclient
    {
        public string Broker = "127.0.0.1";
        public int Port = 1883;
        public string ClientId = "Test";
        public string Username = "amium";
        public string Password = "amium07";
        public string RootTopic = "stfu/amium/";
        public bool Connected = false;
        public bool Error = false;
        public string BrokerUri = null;

        public MqttFactory factory = new MqttFactory();
        public ManagedMqttClientOptions options;
        public MqttClientOptionsBuilder builder;
        MqttTopicFilterBuilder topicFilter;

        public IManagedMqttClient Client = new MqttFactory().CreateManagedMqttClient();

        public MQTTclient()
        {

        }

        public void Start()
        {

            //string id = DateTime.Now.ToString("yyMMddhhmmss").Replace(" ", "").Replace(":", "").Replace(".", "");

            //double n = double.Parse(id);
            //long longValue = (long)n;
            //id = longValue.ToString("X");

           

            if (BrokerUri != null)
            {

                BrokerUri = BrokerUri.Replace("mqtt://", "");
                BrokerUri = BrokerUri.Replace("tcp://", "");

                string[] read = BrokerUri.Split(':');
                Broker = BrokerUri.Replace(":"+read.Last(),"");
                Port = int.Parse(read.Last());
            
            }


            string folderPath = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            string id = dirInfo.FullName.GetHashCode().ToString().Replace("-", "");
            ClientId = ClientId + "_" + id;

            builder = new MqttClientOptionsBuilder()
                        .WithTcpServer(Broker, Port)
                        .WithCredentials(Username, Password)
                        .WithClientId(ClientId)
                        .WithCleanSession();


            options = new ManagedMqttClientOptionsBuilder()
                        .WithAutoReconnectDelay(TimeSpan.FromSeconds(60))
                        .WithClientOptions(builder.Build())
                        .Build();

            Client.StartAsync(options);
            Client.ConnectedAsync += mqttClient_ConnectedAsync;
            Client.DisconnectedAsync += mqttClient_DisconnectedAsync;
            Client.ConnectingFailedAsync += mqttClient_ConnectingFailedAsync;
            Client.ApplicationMessageReceivedAsync += mqttClientMessageReceived;

        }

        public void Publish(string topic, string message, bool retain)
        {
            Client.EnqueueAsync(topic, message, retain: retain);
        }


        public void Subscribe(string topic)
        {
            Client.SubscribeAsync(topic);
        }

        public void Stop()
        {
            Client.StopAsync();
        }

        Task mqttClientMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            OnMessageReceived(arg);
            return Task.CompletedTask;
        }

        public virtual void OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {

        }

        Task mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Connected = true;
            Error = false;
            Debug.WriteLine("MQTT connected");
            return Task.CompletedTask;
        }


        Task mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {

            Connected = false;
            Debug.WriteLine("MQTT diconnected");
            return Task.CompletedTask;
        }

        Task mqttClient_ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            Connected = false;
            Error = true;
            Debug.WriteLine("MQTT failed connect");
            Debug.WriteLine("Broker:   '" + Broker + "'");
            Debug.WriteLine("Port:     '" + Port + "'");
            Debug.WriteLine("Username: '" + Username + "'");
            Debug.WriteLine("Password: '" + Password + "'");
            return Task.CompletedTask;
        }





    }
}
