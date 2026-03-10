using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportExplorer
{
    public partial class ControlMqttStatusBottom : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlMqttStatusBottom()
        {
            InitializeComponent();
        }
        MQTTclient mqttclient;
        public void Start(MQTTclient mqttclient)
        {
            this.mqttclient = mqttclient;
            Thread threadIdle = new Thread(idle) { IsBackground = true };
            threadIdle.Start();
        }


        void idle()
        {
            while (true)
            {
         
                Thread.Sleep(1000);

                if(labelClock.IsHandleCreated)
                  labelClock.BeginInvoke(new Action(() => { labelClock.Text = " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }));

                //if (mqttclient.Connected) setState(error: false, m: $" Connected {Reporter.Client.BrokerUri} {Reporter.Client.RootTopic}");

                //if (!mqttclient.Connected) setState(error: false, m: $" Disconneted {Reporter.Client.BrokerUri} {Reporter.Client.RootTopic}"); ;

                //if (mqttclient.Error) setState(error: true, m: $" Error {Reporter.Client.BrokerUri} {Reporter.Client.RootTopic}");


                if (mqttclient.Connected) setState(error: false, m: $" Connected ");
                if (!mqttclient.Connected) setState(error: false, m: $" Disconneted "); ;
                if (mqttclient.Error) setState(error: true, m: $" Error ");


            }

        }

        void setState(bool error,string m)
        {

            if (!labelMqtt.IsHandleCreated) return;

            Color set = Color.White;
            if (error) set = Color.Tomato;

        
    
            labelMqtt.BeginInvoke(new Action(() =>
            {
                labelMqtt.Text = m;
                labelMqtt.BackColor =set;
            }));

            //labelUri.BeginInvoke(new Action(() =>
            //{
            //    labelUri.BackColor = set;
            //}));

            //labelRootTopic.BeginInvoke(new Action(() =>
            //{
            //    labelRootTopic.BackColor =set;
            //}));

        }



    }
}
