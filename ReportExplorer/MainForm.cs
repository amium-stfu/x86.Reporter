using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPdfViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Frames.FrameHelper;
using System.IO;
using System.Diagnostics;
using PdfSharp.Charting;
using DevExpress.XtraWaitForm;
using Serilog;
using System.Threading;
using DevExpress.XtraBars.Customization;

namespace ReportExplorer
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        
        public MainForm()
        {
            InitializeComponent();
            Reporter.Client = new ReportMqttClient(gridControl);
            //Reporter.Client.BrokerUri = Reporter.Settings.MqttUri;
            //Reporter.Client.Username = Reporter.Settings.MqttUser;
            //Reporter.Client.Password = Reporter.Settings.MqttPassword;
            //Reporter.Client.ClientId = Reporter.Settings.ClientId;
            //Reporter.Client.RootTopic = Reporter.Settings.RootTopic;
            gridControl.DataSource = Reporter.Client.C0list;
           // Reporter.Client.TreeView.Show();


            Reporter.Client.Start();
            Reporter.Client.Init();
            setEnglish();
            setUser();
           

            controlMqttStatusBottom.Start(Reporter.Client);



        }

        void createPreview()
        {
            int rowHandle = gridView1.FocusedRowHandle;
           
            string json = Reporter.Client.C0list.Rows[rowHandle]["Result"].ToString();

           // File.WriteAllText(@"T:\debug_report.json", json);

            C0report c0Report = new C0report();
            c0Report.Source = JsonSerializer.Deserialize<Report>(json, Reporter.JsonOptions);

            string previewFile = c0Report.Create(preview: true, protect: true, language: Reporter.Language.Set);
            pdfViewer1.LoadDocument(previewFile);
            File.Delete(previewFile);
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
        }

        void saveReport()
        {
            int rowHandle = gridView1.FocusedRowHandle;
            string json = Reporter.Client.C0list.Rows[rowHandle]["Result"].ToString();

          //  File.WriteAllText(@"T:\debug_report.json", json);

            C0report c0Report = new C0report();
            c0Report.Source = JsonSerializer.Deserialize<Report>(json, Reporter.JsonOptions);
            string previewFile = c0Report.Create(preview: false, protect: true, language: Reporter.Language.Set);
    
        }

        void printReport()
        {
            if (pdfViewer1.IsDocumentOpened)
                pdfViewer1.Print();
        }


        void publishLanguage()
        {
            try
            {
                string filename = null;

                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {

                    ofd.Filter = "(*.json)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        filename = ofd.FileName;

                        var option = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = new qj_NamingPolice(),
                            WriteIndented = true
                        };

                        string json = System.IO.File.ReadAllText(filename);
                        LanguageLabler read = JsonSerializer.Deserialize<LanguageLabler>(json, Reporter.JsonOptions);

                        Debug.WriteLine("language.region.count:" + read.keyWord.Count());

                        if (read.keyWord.Count() > 0)
                        {
                            Reporter.Client.Publish(Reporter.Client.RootTopic + "$babel", json, true);
                        }
                    }

                }
            }


            catch (Exception ex)
            {
                Debug.WriteLine("Language publish failed: " + ex.ToString());
            }



        }

        private void btnEnglish_CheckedClick(object sender, EventArgs e)
        {
    
            createPreview();

        }

        private void btnGerman_CheckedClick(object sender, EventArgs e)
        {
    
            createPreview();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {
            createPreview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printReport();
        }

        private void menuPublishLanguage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            publishLanguage();
        }

        void setEnglish()
        {
            Reporter.Language.Set = "en";
            btnEnglish.ForeColor = Color.Blue;
            btnEnglish.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Bold);
            btnGerman.ForeColor = Color.Black;
            btnGerman.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Regular);
            
        }

        void setGerman()
        {
            Reporter.Language.Set = "de";
            btnEnglish.ForeColor = Color.Black;
            btnEnglish.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Regular);
            btnGerman.ForeColor = Color.Blue;
            btnGerman.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Bold);
            
        }

        private void btnGerman_Click(object sender, EventArgs e)
        {
            setGerman();
            createPreview();
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            setEnglish();
            createPreview();
        }

        void setAdmin() 
        {
            btnUser.ForeColor = Color.Red;
            btnUser.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Bold);
            btnUser.Text = "Admin";
            Reporter.User = "admin";
            btnPublishLanguage.Visible = true;
            btnExportLanguage.Visible = true;
            btnImportReport.Visible = true;
            btnEditReport.Visible = true;

        }

        void setUser()
        {
            btnUser.ForeColor = Color.Black;
            btnUser.Appearance.Font = new System.Drawing.Font(btnGerman.Font, FontStyle.Regular);
            btnUser.Text = "User";
            Reporter.User = "user";
            btnPublishLanguage.Visible = false;
            btnExportLanguage.Visible = false;
            btnImportReport.Visible = false;
            btnEditReport.Visible = false;

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if(Reporter.User == "admin")
                setUser();
            else
                setAdmin();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPublishLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = null;

                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {

                    ofd.Filter = "(*.json)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        filename = ofd.FileName;

                        string json = System.IO.File.ReadAllText(filename);

                        languages test = JsonSerializer.Deserialize<languages>(json, Reporter.JsonOptions);

                        Debug.WriteLine("language.region.count:" + test.keyWord.Count());

                        if (test.keyWord.Count() > 0)
                        {
                            string message = JsonSerializer.Serialize<languages>(test, Reporter.JsonOptions);
                            Reporter.Client.Publish(Reporter.Client.RootTopic + "$babel", message, true);
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Language publish failed: " + ex.ToString());
            }
        }

        private void btnExportLanguage_Click(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize<LanguageLabler>(Reporter.Language, Reporter.JsonOptions);
            using (System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog())
            {

                ofd.Filter = "(*.json)|";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!ofd.FileName.EndsWith(".json"))
                        ofd.FileName = ofd.FileName + ".json";
                    File.WriteAllText(ofd.FileName, json);
                }
            }
        }

        private void btnImportReport_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = null;

                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {

                    ofd.Filter = "(*.json)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.RestoreDirectory = true;
                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        filename = ofd.FileName;
                        string json = System.IO.File.ReadAllText(filename);
                        Report test = JsonSerializer.Deserialize<Report>(json, Reporter.JsonOptions);

                        Debug.WriteLine("sys.keys.count:" + test.sys.Count());

                        if (test.sys.Count() > 0)
                        {
                            Reporter.Client.Publish(Reporter.Client.RootTopic + "reports/c0/" + Reporter.dateTime(), json, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Report publish failed: " + ex.ToString());
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string id = DateTime.Now.ToString("yyMMddhhmmss").Replace(" ", "").Replace(":", "").Replace(".", "");

            double n = double.Parse(id);
            long longValue = (long)n;
            id = longValue.ToString("X");


            string folderPath = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

            id = dirInfo.FullName.GetHashCode() + "_" + id;
            id = id.Replace("-", "");



            if (dirInfo.Exists)
            {
                Console.WriteLine($"Folder Name: {dirInfo.Name}");
                Console.WriteLine($"Device Id: {id}");
                Console.WriteLine($"Folder ID: {dirInfo.FullName.GetHashCode()}"); // Using hash code as a simple ID
            }
            else
            {
                Console.WriteLine("Folder does not exist.");
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            System.Drawing.Point p = btnMenu.PointToScreen(System.Drawing.Point.Empty);
       
            p.Y = p.Y + btnMenu.Height;
            popupMenu.ShowPopup(p);
        }

        private void lgd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserControlDeviceReader lgd = new UserControlDeviceReader();
            lgd.Show();
        }

        private void btnLgdLincheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            WaitFormManager.ShowWaitForm();
            
            WaitFormManager.SetWaitFormDescription("Connecting to device");

            try
            {
                var device = new FormDeviceReader("LGD Linearity Check", Reporter.Client, "lgd");


                device.Socket = lgdSocket.EditValue.ToString();
                if (!lgdSocket.EditValue.ToString().Contains(":"))
                    device.Socket = lgdSocket.EditValue.ToString() + ":7700";

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
                    WaitFormManager.SendCommand(DeviceWaitForm.WaitFormCommand.Error, this);
                    WaitFormManager.SetWaitFormDescription("Conneting failed");
                    Thread.Sleep(2000);
                    WaitFormManager.CloseWaitForm();
                    return;
                }
                try
                {
                    device.LincheckRead();
                }
                catch
                {
                    WaitFormManager.SendCommand(DeviceWaitForm.WaitFormCommand.Error, this);
                    WaitFormManager.SetWaitFormDescription("Error read data");
                    Thread.Sleep(2000);
                    WaitFormManager.CloseWaitForm();
                    return;

                }
                WaitFormManager.CloseWaitForm();
                device.ShowDialog();

            }
            catch
            {
                WaitFormManager.CloseWaitForm();
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btnEditReport_Click(object sender, EventArgs e)
        {
            FormDeviceReader editor = new FormDeviceReader("Report Editor", Reporter.Client, "manual");
            editor.ShowDialog();
            
        }
    }
}