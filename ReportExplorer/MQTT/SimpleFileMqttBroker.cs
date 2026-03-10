using MQTTnet;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReportExplorer
{
    public class SimpleFileMqttBroker : IDisposable
    {
        private readonly object _syncRoot = new object();
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        private readonly string _username;
        private readonly string _password;
        private MqttServer _server;

        public int Port { get; private set; }
        public string StorageFilePath { get; private set; }
        public bool IsRunning
        {
            get { return _server != null && _server.IsStarted; }
        }

        public SimpleFileMqttBroker(
            int port = 1883,
            string storageFilePath = null,
            string username = null,
            string password = null)
        {
            Port = port;
            _username = username;
            _password = password;

            if (string.IsNullOrWhiteSpace(storageFilePath))
            {
                string appDataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mqtt-data");
                StorageFilePath = Path.Combine(appDataFolder, "retained-messages.json");

            }
            else
            {
                StorageFilePath = storageFilePath;
            }

            Debug.WriteLine("SimpleFileMqttBroker initialized BackingStore in: " + StorageFilePath);
            Debug.WriteLine("SimpleFileMqttBroker initialized Port: " + Port);
            Debug.WriteLine("SimpleFileMqttBroker initialized Username: " + (string.IsNullOrWhiteSpace(username) ? "(none)" : username));
            Debug.WriteLine("SimpleFileMqttBroker initialized Password: " + (string.IsNullOrWhiteSpace(password) ? "(none)" : new string('*', password.Length)));
            Debug.WriteLine("SimpleFileMqttBroker initialized IsRunning: " + IsRunning);


        }

        public async Task StartAsync()
        {
            if (IsRunning)
            {
                return;
            }

            EnsureStorageFolderExists();

            var options = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithDefaultEndpointPort(Port)
                .WithPersistentSessions(true)
                .Build();

            _server = new MqttFactory().CreateMqttServer(options);
            _server.LoadingRetainedMessageAsync += OnLoadingRetainedMessagesAsync;
            _server.RetainedMessageChangedAsync += OnRetainedMessageChangedAsync;
            _server.RetainedMessagesClearedAsync += OnRetainedMessagesClearedAsync;
            _server.ValidatingConnectionAsync += OnValidatingConnectionAsync;

            await _server.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_server == null)
            {
                return;
            }

            await SaveCurrentRetainedMessagesAsync();

            var stopOptions = new MqttServerStopOptionsBuilder().Build();
            await _server.StopAsync(stopOptions);
            UnregisterEventHandlers(_server);
            _server.Dispose();
            _server = null;
        }

        private Task OnLoadingRetainedMessagesAsync(LoadingRetainedMessagesEventArgs args)
        {
            List<RetainedMessageRecord> records = ReadRecordsFromFile();
            foreach (RetainedMessageRecord record in records)
            {
                args.LoadedRetainedMessages.Add(ToApplicationMessage(record));
            }

            return Task.CompletedTask;
        }

        private Task OnRetainedMessageChangedAsync(RetainedMessageChangedEventArgs args)
        {
            SaveRecordsToFile(args.StoredRetainedMessages.Select(ToRecord).ToList());
            return Task.CompletedTask;
        }

        private Task OnRetainedMessagesClearedAsync(EventArgs args)
        {
            SaveRecordsToFile(new List<RetainedMessageRecord>());
            return Task.CompletedTask;
        }

        private Task OnValidatingConnectionAsync(ValidatingConnectionEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(_username))
            {
                args.ReasonCode = MqttConnectReasonCode.Success;
                return Task.CompletedTask;
            }

            bool userNameMatches = string.Equals(args.UserName, _username, StringComparison.Ordinal);
            bool passwordMatches = string.Equals(args.Password, _password ?? string.Empty, StringComparison.Ordinal);

            args.ReasonCode = userNameMatches && passwordMatches
                ? MqttConnectReasonCode.Success
                : MqttConnectReasonCode.BadUserNameOrPassword;

            return Task.CompletedTask;
        }

        private async Task SaveCurrentRetainedMessagesAsync()
        {
            if (_server == null)
            {
                return;
            }

            var retainedMessages = await _server.GetRetainedMessagesAsync();
            SaveRecordsToFile(retainedMessages.Select(ToRecord).ToList());
        }

        private void EnsureStorageFolderExists()
        {
            string directory = Path.GetDirectoryName(StorageFilePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private List<RetainedMessageRecord> ReadRecordsFromFile()
        {
            lock (_syncRoot)
            {
                try
                {
                    if (!File.Exists(StorageFilePath))
                    {
                        return new List<RetainedMessageRecord>();
                    }

                    string json = File.ReadAllText(StorageFilePath);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return new List<RetainedMessageRecord>();
                    }

                    List<RetainedMessageRecord> records = JsonSerializer.Deserialize<List<RetainedMessageRecord>>(json, _jsonOptions);
                    return records ?? new List<RetainedMessageRecord>();
                }
                catch
                {
                    return new List<RetainedMessageRecord>();
                }
            }
        }

        private void SaveRecordsToFile(List<RetainedMessageRecord> records)
        {
            lock (_syncRoot)
            {
                string json = JsonSerializer.Serialize(records, _jsonOptions);
                File.WriteAllText(StorageFilePath, json);
            }
        }

        private static RetainedMessageRecord ToRecord(MqttApplicationMessage message)
        {
            var record = new RetainedMessageRecord
            {
                Topic = message.Topic,
                PayloadBase64 = message.Payload == null ? string.Empty : Convert.ToBase64String(message.Payload),
                QualityOfServiceLevel = (int)message.QualityOfServiceLevel,
                Retain = message.Retain,
                ContentType = message.ContentType,
                ResponseTopic = message.ResponseTopic,
                CorrelationDataBase64 = message.CorrelationData == null ? string.Empty : Convert.ToBase64String(message.CorrelationData),
                MessageExpiryInterval = message.MessageExpiryInterval,
                PayloadFormatIndicator = (int)message.PayloadFormatIndicator,
                UserProperties = message.UserProperties == null
                    ? new List<UserPropertyRecord>()
                    : message.UserProperties
                        .Select(p => new UserPropertyRecord { Name = p.Name, Value = p.Value })
                        .ToList()
            };

            return record;
        }

        private static MqttApplicationMessage ToApplicationMessage(RetainedMessageRecord record)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(record.Topic)
                .WithPayload(string.IsNullOrWhiteSpace(record.PayloadBase64)
                    ? Array.Empty<byte>()
                    : Convert.FromBase64String(record.PayloadBase64))
                .WithQualityOfServiceLevel((MqttQualityOfServiceLevel)record.QualityOfServiceLevel)
                .WithRetainFlag(record.Retain)
                .Build();

            message.ContentType = record.ContentType;
            message.ResponseTopic = record.ResponseTopic;
            message.CorrelationData = string.IsNullOrWhiteSpace(record.CorrelationDataBase64)
                ? null
                : Convert.FromBase64String(record.CorrelationDataBase64);
            message.MessageExpiryInterval = record.MessageExpiryInterval;
            message.PayloadFormatIndicator = (MqttPayloadFormatIndicator)record.PayloadFormatIndicator;

            if (record.UserProperties != null && record.UserProperties.Count > 0)
            {
                message.UserProperties = record.UserProperties
                    .Select(p => new MqttUserProperty(p.Name, p.Value))
                    .ToList();
            }

            return message;
        }

        public void Dispose()
        {
            if (_server != null)
            {
                UnregisterEventHandlers(_server);
                _server.Dispose();
                _server = null;
            }
        }

        private void UnregisterEventHandlers(MqttServer server)
        {
            server.LoadingRetainedMessageAsync -= OnLoadingRetainedMessagesAsync;
            server.RetainedMessageChangedAsync -= OnRetainedMessageChangedAsync;
            server.RetainedMessagesClearedAsync -= OnRetainedMessagesClearedAsync;
            server.ValidatingConnectionAsync -= OnValidatingConnectionAsync;
        }

        private class RetainedMessageRecord
        {
            public string Topic { get; set; }
            public string PayloadBase64 { get; set; }
            public int QualityOfServiceLevel { get; set; }
            public bool Retain { get; set; }
            public string ContentType { get; set; }
            public string ResponseTopic { get; set; }
            public string CorrelationDataBase64 { get; set; }
            public uint MessageExpiryInterval { get; set; }
            public int PayloadFormatIndicator { get; set; }
            public List<UserPropertyRecord> UserProperties { get; set; }
        }

        private class UserPropertyRecord
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
