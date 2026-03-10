using DevExpress.XtraEditors;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportExplorer
{
    public partial class UserControlDeviceReader : DevExpress.XtraEditors.XtraUserControl
    {

        public string DeviceGroup;
        public UserControlDeviceReader()
        {
            InitializeComponent();
        }

        private void tablePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        Thread load;
        DeviceWaitForm waitForm;
        private void btnLincheck_Click(object sender, EventArgs e)
        {
            load = new Thread(readLinCheck);
            load.SetApartmentState(ApartmentState.STA);
            load.Start();
            //  readLinCheck();
            //return;

            waitForm = new DeviceWaitForm();
            waitForm.Show();
            waitForm.BeginInvoke(new Action(() => { waitForm.SetDescription("Conneting to device"); }));


        }

        void readLinCheck()
        {
   
            try
            {
                var device = new FormDeviceReader("LGD Linearity Check", Reporter.Client, DeviceGroup);


                device.Socket = EditSocket.EditValue.ToString();
                if (!EditSocket.EditValue.ToString().Contains(":"))
                device.Socket = EditSocket.EditValue.ToString()+":7700";

                Log.Information("Connecting to: " + device.Socket);

          

                device.Start();

                int c = 0;

                while (!device.Client.Connected)
                {
                    Thread.Sleep(1000);
                    c++;
                    if (c == 5)
                        break;
                }

                if (c >= 5)
                {
                    waitForm.BeginInvoke(new Action(() => { waitForm.SetDescription("Conneting failed"); waitForm.table.BackColor = Color.Tomato; }));
                    Thread.Sleep(2000);
                    waitForm.BeginInvoke(new Action(() => {waitForm.Close();}));
                    return;
                }
                try
                {
                    device.LincheckRead();
                }
                catch 
                {
                    waitForm.BeginInvoke(new Action(() => { waitForm.SetDescription("Error read data"); waitForm.table.BackColor = Color.Tomato; }));
                    Thread.Sleep(2000);
                    waitForm.BeginInvoke(new Action(() => { waitForm.Close(); }));
                    return;

                }
                waitForm.BeginInvoke(new Action(() => { waitForm.Close(); }));
                device.ShowDialog();
             
            }
            catch
            {
                //waitForm.BeginInvoke(new Action(() => { waitForm.Close(); }));
            }
            

        }
    }
}
