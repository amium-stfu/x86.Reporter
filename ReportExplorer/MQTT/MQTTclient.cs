using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ReportExplorer
{
    public class MQTTclient
    {
        public string BrokerUri = "192.123.12.12";
        public int Port = 11884;
        public string ClientId = "Test";
        public string Username = "amium";
        public string Password = "Showtime007";
        public string DeviceId = "0815";
        public bool Connected = false;
        public bool Error = false;
        public string RootTopic = "amium/reports/";

        public MqttFactory factory = new MqttFactory();
        public ManagedMqttClientOptions options;
        public MqttClientOptionsBuilder builder;

        public IManagedMqttClient Client = new MqttFactory().CreateManagedMqttClient();

        public void Start()
        {
            StartAsync().GetAwaiter().GetResult();
        }

        public async Task StartAsync()
        {
            builder = new MqttClientOptionsBuilder()
                .WithTcpServer(BrokerUri, Port)
                .WithCredentials(Username, Password)
                .WithClientId(DeviceId)
                .WithCleanSession();

            options = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(10))
                .WithClientOptions(builder.Build())
                .Build();

            await UnregisterAndStopClientAsync();
            Client = new MqttFactory().CreateManagedMqttClient();

            Client.ConnectedAsync += mqttClient_ConnectedAsync;
            Client.DisconnectedAsync += mqttClient_DisconnectedAsync;
            Client.ConnectingFailedAsync += mqttClient_ConnectingFailedAsync;
            Client.ApplicationMessageReceivedAsync += mqttClientMessageReceived;

            await Client.StartAsync(options);

            Debug.WriteLine("MQTT connected to");
            Debug.WriteLine("Broker:   '" + BrokerUri + "'");
            Debug.WriteLine("Port:     '" + Port + "'");
            Debug.WriteLine("DeviceID: '" + DeviceId + "'");
            Debug.WriteLine("Username: '" + Username + "'");
            Debug.WriteLine("Password: '" + Password + "'");
            Debug.WriteLine("RootTopic: '" + RootTopic + "'");
        }

        public async Task RestartAsync()
        {
            await StartAsync();
        }

        public void Publish(string topic, string message, bool retain)
        {
            var appMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(message)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .WithRetainFlag(retain)
                .Build();

            Client.EnqueueAsync(appMessage);
        }

        public void Subscribe(string topic)
        {
            var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(topic)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            Client.SubscribeAsync(new List<MqttTopicFilter> { topicFilter });
        }

        public void Unsubscribe(string topic)
        {
            Client.UnsubscribeAsync(new string[] { topic });
        }

        public void Shutdown()
        {
            UnregisterAndStopClientAsync().GetAwaiter().GetResult();
        }

        private async Task UnregisterAndStopClientAsync()
        {
            if (Client == null)
            {
                return;
            }

            try
            {
                Client.ConnectedAsync -= mqttClient_ConnectedAsync;
                Client.DisconnectedAsync -= mqttClient_DisconnectedAsync;
                Client.ConnectingFailedAsync -= mqttClient_ConnectingFailedAsync;
                Client.ApplicationMessageReceivedAsync -= mqttClientMessageReceived;

                Task stopTask = Client.StopAsync();
                await Task.WhenAny(stopTask, Task.Delay(2000));
                Client.Dispose();
            }
            catch
            {
                // Ignore stop/dispose errors during reconnect handling.
            }
        }

        private Task mqttClientMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            OnMessageReceived(arg);
            return Task.CompletedTask;
        }

        public virtual void OnMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
        }

        private async Task mqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Connected = true;
            Error = false;
            Debug.WriteLine("MQTT connected");
            await OnConnectedAsync(arg);
        }

        private async Task mqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Connected = false;
            Debug.WriteLine("MQTT diconnected");
            await OnDisconnectedAsync(arg);
        }

        private async Task mqttClient_ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            Connected = false;
            Error = true;
            Debug.WriteLine("MQTT failed connect");
            Debug.WriteLine("Broker:   '" + BrokerUri + "'");
            Debug.WriteLine("Port:     '" + Port + "'");
            Debug.WriteLine("DeviceID: '" + DeviceId + "'");
            Debug.WriteLine("Username: '" + Username + "'");
            Debug.WriteLine("Password: '" + Password + "'");
            Debug.WriteLine("RootTopic: '" + RootTopic + "'");
            await OnConnectingFailedAsync(arg);
        }

        protected virtual Task OnConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnDisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            return Task.CompletedTask;
        }
    }
}
