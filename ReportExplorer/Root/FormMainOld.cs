using DevExpress.Pdf;
using DevExpress.XtraPdfViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.IO;
using static DevExpress.Utils.HashCodeHelper.Primitives;
using System.Net.NetworkInformation;
using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraBars.Ribbon;
using System.Threading;
using DevExpress.Utils.Internal;
using DevExpress.Utils.DPI;
using DevExpress.XtraReports;
using static DevExpress.Utils.Frames.FrameHelper;
using Serilog;



namespace ReportExplorer
{
    public partial class FormMainOld : DevExpress.XtraBars.Ribbon.RibbonForm
    {

       
        PdfWriter pdf = new PdfWriter("C0");
        C0report C0report = new C0report();
        ReportMqttClient client;

        public FormMainOld()
        {
            
            InitializeComponent();
            

            // pdfViewer1.CreateBars(PdfViewerToolbarKind.All);
            pdfViewer1.DetachStreamAfterLoadComplete = true;
            pdfViewer1.ReadOnly = true;

            pdfViewer1.NavigationPanePageVisibility = PdfNavigationPanePageVisibility.None;

          

            client = new ReportMqttClient(gridControl1);

            gridControl1.DataSource = client.C0list;

            Thread display = new Thread(updateDisplay);
            display.IsBackground = true;
            display.Start();

            client.Start();
            client.Init();


        }

        private void barButtonPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(pdfViewer1.IsDocumentOpened)
            pdfViewer1.Print();

        }

        void updateDisplay()
        {
            while (true)
            {
               System.Threading.Thread.Sleep(1000);
                Online.BeginUpdate();
                if (client.Connected)
                {
                    Online.Checked = true;
                    Online.Caption = "Connected";

                    Broker.BeginUpdate();
                    Broker.EditValue = client.Broker;
                    Broker.EndUpdate();

                    Topic.BeginUpdate();
                    Topic.EditValue = client.Topic;
                    Topic.EndUpdate();

                }
                else
                {
                    Online.Checked = false;
                    Online.Caption = "Disconnected";
                }
                Online.EndUpdate();
            }

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            createPreview();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            createPreview();
        }

        void createPreview()
        {

                int rowHandle = gridView1.FocusedRowHandle;

                string json = client.C0list.Rows[rowHandle]["Result"].ToString();

                C0report c0Report = new C0report();
            

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new qj_NamingPolice(),

                };

                c0Report.Source = JsonSerializer.Deserialize<Report>(json, options);

                string region = Region_en.Checked ? "en" : "de";

                string preview = c0Report.Create(preview: true, protect: true, language: region);
                pdfViewer1.LoadDocument(preview);
                File.Delete(preview);
                pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
        
            
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;

            string json = client.C0list.Rows[rowHandle]["Result"].ToString();

            C0report c0Report = new C0report();


            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new qj_NamingPolice(),

            };

            c0Report.Source = JsonSerializer.Deserialize<Report>(json, options);

            string region = Region_en.Checked ? "en" : "de";

            string preview = c0Report.Create(preview: false, protect: true, language: region);
        }



        private void Region_en_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Region_de.Checked = !Region_en.Checked;
            if (Region_en.Checked)
            {
                Reporter.Language.Set = "en";
                createPreview();

            }
          
        }

        private void Region_de_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Region_en.Checked = !Region_de.Checked;
            if (Region_de.Checked)
            {
                Reporter.Language.Set = "de";
                createPreview();

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

                        //Debug.WriteLine(json);

                        languages test = JsonSerializer.Deserialize<languages>(json, option);

                        Debug.WriteLine("language.region.count:" + test.keyWord.Count());

                        if (test.keyWord.Count() > 0)
                        {
                            string message = JsonSerializer.Serialize<languages>(test, option);
                            // Debug.WriteLine(message);
                            client.Publish(client.RootTopic + "reports/data/languages", message, true);
                        }
                    }

                }
            }


            catch (Exception ex) { 
            Debug.WriteLine("Language publish failed: " + ex.ToString());
            }
        
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

                        Report test = JsonSerializer.Deserialize<Report>(json, option);

                        Debug.WriteLine("sys.keys.count:" + test.sys.Count());

                        if (test.sys.Count() > 0)
                        {
                            string message = JsonSerializer.Serialize<Report>(test, option);
                            // Debug.WriteLine(message);
                            client.Publish(client.RootTopic + "reports/c0/" + test.sys["aid"], message, true);
                        }


                    }
                }

            
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Report publish failed: " + ex.ToString());
            }

        }

        private void ExportLanguageFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void barButtonItem3_ItemClick_3(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            Console.WriteLine("KeyWords" + Reporter.Language.keyWord.Count);

            Console.WriteLine(Reporter.Language.GetLabel("devices.aid"));
        }

        private void btnLinCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var lgd = new FormDeviceReader("LGD Linearity Check", client);
                lgd.Socket = lgdSocket.EditValue.ToString();
           
                lgd.Start();

                int c = 0;

                while (!lgd.Client.Connected)
                {
                    Thread.Sleep(1000);
                    c++;
                    if (c == 5)
                        break;
                }

                if (c >= 5)
                    return;
                lgd.LincheckRead();
                lgd.ShowDialog();
            }
            catch 
            { 

            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm test = new MainForm();
            test.Show();

        }
    }
    

  


}
