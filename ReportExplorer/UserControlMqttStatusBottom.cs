using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ReportExplorer
{
    public partial class UserControlMqttStatusBottom : DevExpress.XtraEditors.XtraUserControl
    {
       
        
        public UserControlMqttStatusBottom()
        {
            InitializeComponent();
        }

        MQTTclient mqttclient;

        public void Start(MQTTclient mqttclient)
        {
            this.mqttclient = mqttclient;
            labelUri.Text = mqttclient.Broker + ":" + mqttclient.Port;
            labelRootTopic.Text = mqttclient.RootTopic;

            Thread threadIdle = new Thread(idle) { IsBackground = true };
            threadIdle.Start();
        }



        void idle()
        {
            while (true) 
            {
                Thread.Sleep(1000);

                labelClock.Text = " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                
                if (mqttclient.Error) 
                {
                    labelMqtt.Text = "Failed";
                    labelMqtt.BackColor = Color.Tomato;
                    return;
                }

                if (mqttclient.Connected) 
                {
                    labelMqtt.Text = "Connected";
                    return;
                }
                if (!mqttclient.Connected)
                {
                    labelMqtt.Text = "Disconneted";
                }

            }
        
        }
    }



    
}
