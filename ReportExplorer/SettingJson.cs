
using PdfSharp.Pdf.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ReportExplorer
{
    public class SettingJson
    {
        public string MqttUri { get; set; } = "127.0.0.1:1883";
        public string MqttUser { get; set; } = "mzu";
        public string MqttPassword { get; set; } = "amium07";
        public string ClientId { get; set; } = "MZU";
        public string RootTopic { get; set; } = "MZU";
 

        [JsonIgnore]
        private string name = "showtime";
        [JsonIgnore]
        string uri;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mqttUri"></param>
        /// <param name="mqttUser"></param>
        /// <param name="mqttPassword"></param>
        /// <param name="clientId"></param>
        [JsonConstructor]
        public SettingJson(string mqttUri, string mqttUser, string mqttPassword,string rootTopic, string clientId)
        {

            MqttUri = mqttUri;
            MqttUser = mqttUser;
            MqttPassword = mqttPassword;
            RootTopic = rootTopic;
            ClientId = clientId;

            uri = Path.Combine(Directory.GetCurrentDirectory(), AppDomain.CurrentDomain.FriendlyName) + ".setting";
            uri = uri.Replace(".exe", "");
            Debug.WriteLine(uri);

            Import();
        }

        public void Export()
        {
            try
            {
                string jsonStringSettings = JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true
                });
                System.IO.File.WriteAllText(uri, jsonStringSettings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error exporting settings: {ex.Message}");
            }
        }

        public void Import()
        {

            if (!System.IO.File.Exists(uri))
                Export();

            string jsonString = System.IO.File.ReadAllText(uri);
           Debug.WriteLine("file -------------------------------" + jsonString);
            try
            {
                Dictionary<string, string> read = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString, new JsonSerializerOptions
                {
                    IncludeFields = true
                });

                foreach (var item in read)
                {
                    Debug.WriteLine($"{item.Key}: {item.Value}");
                }

                MqttUri = read["MqttUri"];
                MqttUser = read["MqttUser"];
                MqttPassword = read["MqttPassword"];
                RootTopic = read["RootTopic"];
                ClientId = read["ClientId"];
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error importing settings: {ex.Message}");
       
            }
            
        }

    }
}
