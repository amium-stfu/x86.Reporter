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


namespace ReportExplorer
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        PdfWriter pdf = new PdfWriter("C0");
        C0report C0report = new C0report();
        MQTTclient client;





        public Form1()
        {
            
            InitializeComponent();
            

            // pdfViewer1.CreateBars(PdfViewerToolbarKind.All);
            pdfViewer1.DetachStreamAfterLoadComplete = true;
            pdfViewer1.ReadOnly = true;

            pdfViewer1.NavigationPanePageVisibility = PdfNavigationPanePageVisibility.None;

          

            client = new MQTTclient(gridControl1);

            gridControl1.DataSource = client.C0list;

            Thread display = new Thread(updateDisplay);
            display.IsBackground = true;
            display.Start();

            client.Start();


        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //C0report.Import();

            //C0 c0 = new C0(C0report.readValue("READ", "SN"), C0report.readValue("ORDER", "DATE"), C0report.readValue("READ", "RANGE"), C0report.readValue("ORDER", "PNO"), C0report.Order, C0report.Results);

            //string message = JsonSerializer.Serialize<C0>(c0);

            //client.Publish("Amium/Reports/C0/" + C0report.readValue("ORDER", "PNO") + "-1" , message, true);
            //client.Publish("Amium/Reports/C0/" + C0report.readValue("ORDER", "PNO") + "-2", message, true);
            //client.Publish("Amium/Reports/C0/" + C0report.readValue("ORDER", "PNO") + "-3", message, true);

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

            C0report.Order = (List<string>)client.C0list.Rows[rowHandle]["Data"];
            C0report.Results = (List<string>)client.C0list.Rows[rowHandle]["Results"];

            string preview = C0report.Create(preview: true, protect:true);
            pdfViewer1.LoadDocument(preview);
            File.Delete(preview);
            pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            C0report.Create(preview: false, protect: true);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            C0report.Import();

            C0 c0 = new C0(C0report.readValue("READ", "SN"), C0report.readValue("ORDER", "DATE"), C0report.readValue("READ", "RANGE"), C0report.readValue("ORDER", "PNO"), C0report.Order, C0report.Results);

            string message = JsonSerializer.Serialize<C0>(c0);

            Random rnd = new Random();

            int i = rnd.Next(100);

            client.Publish("Amium/Reports/C0/" + C0report.readValue("ORDER", "PNO") + "-" + i , message, true);

      

        }

        private void Brocker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //C0report.Import();


            //C0 c0 = new C0(C0report.readValue("READ", "SN"), C0report.readValue("ORDER", "DATE"), C0report.readValue("READ", "RANGE"), C0report.readValue("ORDER", "PNO"), C0report.Order, C0report.Results);

            //string message = JsonSerializer.Serialize<C0>(c0);

            //Random rnd = new Random();

            //int i = rnd.Next(100);

            //client.Publish("Amium/Reports/C0/" + C0report.readValue("ORDER", "PNO") + "-" + i, message, true);

            Report test = new Report("test");
            test.sys.Add("aid", "2824-35001");
            test.sys.Add("type", "report");
            test.sys.Add("cfg", "c0");
            test.sys.Add("info", "This certificate confirms the correct realisation of a calibration according to the appropriate specifications. It documents and evaluates the detecte deviations regarding given criteria.\n\nThis calibration certificate is automatically generated and valid without signature.");

            test.order.Add("aid", "NA");
            test.order.Add("aid$label", "Order number");
            test.order.Add("report_aid", "2824-35001");
            test.order.Add("report_aid$label", "Protocolnumber");
            test.order.Add("date", "2024-07-11");
            test.order.Add("date$label", "Date");
            test.order.Add("location", "Amium Labor 007");
            test.order.Add("location$label", "Locaton");
            test.order.Add("user", "Amium / J. Haselsberger");
            test.order.Add("user$label", "Operator");

            test.customer.Add(new company(

            aid:"aid",
            person:"Hans Dampf",
            name:"Amium",
            street:"Durchholzen 34",
            postcode:"Walchsee",
            country:"Austria"
                ));

            test.result.data.Add(new datapoint(info:"Cal. Zeropoint",reference:"0.040", dut:"0.000", abs:"0.040"));
            test.result.data.Add(new datapoint(info: "Cal. Endpoint", reference: "100.100", dut:"100.000", abs: "0.100", rel:"0.10"));
            test.result.data.Add(new datapoint(info: "Offset", reference: "0.000", dut: "0.000"));
            test.result.data.Add(new datapoint(info: "Span", reference: "0.000", dut: "101.000"));
            test.result.data.Add(new datapoint(info: "0 %", reference: "0.000", dut: "0.000", abs: "0.000"));
            test.result.data.Add(new datapoint(info: "10 %", reference: "10.030", dut: "10.100", abs: "-0.070", rel: "-0.69"));
            test.result.data.Add(new datapoint(info: "20 %", reference: "20.000", dut: "20.200", abs: "-0.200", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "30 %", reference: "30.000", dut: "30.300", abs: "-0.300", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "40 %", reference: "40.000", dut: "40.400", abs: "-0.400", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "50 %", reference: "50.000", dut: "50.500", abs: "-0.500", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "60 %", reference: "60.000", dut: "60.600", abs: "-0.600", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "70 %", reference: "70.000", dut: "70.700", abs: "-0.700", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "80 %", reference: "80.000", dut: "80.800", abs: "-0.800", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "90 %", reference: "90.000", dut: "90.900", abs: "-0.900", rel: "-0.99"));
            test.result.data.Add(new datapoint(info: "100 %", reference: "100.000", dut: "101.000", abs: "-1.000", rel: "-0.99"));
            test.result.data.Add(new datapoint(info:"Formula for REF: (Span - Offset)  * Configuration + Offset"));

            test.result.verification.Add(new datapoint(info:"n", dut:"11.000", limit:">10", result:"passed"));
            test.result.verification.Add(new datapoint(info: "a1", dut: "0.990", limit: "0.98..1.02", result: "passed"));
            test.result.verification.Add(new datapoint(info: "Xmin", dut: "0.008",  limit: "<= 1.01 [1 % nmax]", result: "passed"));
            test.result.verification.Add(new datapoint(info: "SEE",  dut: "0.009",  limit: "<= 2.02 [ 2 % nmax]", result: "passed"));
            test.result.verification.Add(new datapoint(info: "r2",  dut: "1.000",  limit: "> 0.99", result: "passed"));


            string message = JsonSerializer.Serialize<Report>(test).Replace("_","$");


            //Debug.WriteLine("'"+message+"'");

            //Random rnd = new Random();

            //int i = rnd.Next(100);

            client.Publish("Amium/Reports/C0/test", message, true);




        }
    }
}
