using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Serilog;
using Serilog.Sinks.File;
using System.Text.Json;
using ReportExplorer.Properties;

namespace ReportExplorer
{

    public static class Reporter
    {

      
        public static LanguageLabler Language { get; set; }
      
        public static ReportMqttClient Client;
        public static JsonSerializerOptions JsonOptions { get; set; }
        public static qj_NamingPolice NamingPolicy { get; set; }

        public static SettingJson Settings { get; set; }

        public static string User { get; set; }


        public static string dateTime()
        {
            DateTime localTime = DateTime.Now; // Local time
            DateTime utcTime = localTime.ToUniversalTime();
            TimeSpan difference = localTime - utcTime;
            string d = "m";
            if (difference.TotalHours > 0) d = "p";
            return DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff") + d + Math.Abs(difference.TotalHours);
        }

    }

    internal static class Program
    {

    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
        static void Main()
        {

            Reporter.Settings = new SettingJson(
                mqttUri: "127.0.0.1:7700",
                mqttUser: "amium",
                mqttPassword: "amium07#",
                rootTopic: "stfu/amium",
                clientId: "stfu_laptop");


            Reporter.Language = new LanguageLabler("ReportExplorer");
            Reporter.NamingPolicy = new qj_NamingPolice();
            Reporter.JsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new qj_NamingPolice(),
                WriteIndented = true
            };

            string logFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log", "log-.txt");
            Log.Logger = new LoggerConfiguration().WriteTo.File(
                path: logFilePath,
                fileSizeLimitBytes: 10 * 1024 * 1024, // 10 MB
                rollOnFileSizeLimit: true,
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:l}{NewLine}{Exception}")
            .CreateLogger();

            Log.Information("Init Application");




           
            // DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new FormMainOld());
            Application.Run(new MainForm());
        }
    }




}
