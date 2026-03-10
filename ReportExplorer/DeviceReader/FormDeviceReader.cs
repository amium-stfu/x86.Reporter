using DevExpress.XtraEditors;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReportExplorer
{


    public partial class FormDeviceReader : DevExpress.XtraEditors.XtraForm
    {
        internal class ResultDataPoint
        {
            public string Cfg = "";
            public double Dut = double.NaN;
            public double Ref = double.NaN;
            public double DevAbs = double.NaN;
            public double DevRel = double.NaN;
            public string Limit = "";
            public string Result = "";
        }

        public class ValueTable : DataTable
        {
            public string Name = "";
            public ValueTable(string name)
            {
                Name = name;
                Columns.Add("name", typeof(string));
                Columns.Add("label", typeof(string));
                Columns.Add("value", typeof(string));
            }

            public void Add(string name, string value = null)
            {
                DataRow row = this.NewRow();
                row["name"] = name;
                row["label"] = Reporter.Language.GetLabel(name);
                row["value"] = value;
                Rows.Add(row);
            }

            public void Update(string name, string value)
            {
                Console.WriteLine("looking for '" + name + "'");
                foreach (DataRow row in Rows)
                {
                    Console.WriteLine(row["name"].ToString());
                    if (row["name"].ToString() == name)
                    {
                        row["value"] = value.ToString();
                        Console.WriteLine("Table " + Name + " udating: " + row["name"] + "= " + row["value"]);

                    }

                }
            
            }

            public string Read(string name)
            {
                string result = "NA";
                try
                {
                    foreach (DataRow row in Rows)
                    {
                        if (row["name"] == name)
                            return result = row["value"].ToString();
                    }
                    return result;
                }
                catch 
                {
                    Console.WriteLine("Error get value: " + name);
                    return result;
                }
            }
        }

        public class ResultsTable : DataTable
        {
            public ResultsTable()
            {
                Columns.Add("cfg", typeof(string));
                Columns.Add("label", typeof(string));
                Columns.Add("dut", typeof(double));
                Columns.Add("ref", typeof(double));
                Columns.Add("devAbs", typeof(double));
                Columns.Add("devRel", typeof(double));
                Columns.Add("limit", typeof(string));
                Columns.Add("result", typeof(string));
            }

            public void Add(string name, double _ref = double.NaN, double dut = double.NaN, double devAbs = double.NaN, double devRel = double.NaN, string limit = "", string result = "")
            {
                DataRow row = this.NewRow();
                row["cfg"] = name;
                row["label"] = Reporter.Language.GetLabel(name);
                row["ref"] = _ref;
                row["dut"] = dut;
                row["devAbs"] = devAbs;
                row["devRel"] = devRel;
                row["limit"] = limit;
                row["result"] = result;
                Rows.Add(row);
            }

        }

        public class DeviceData : ValueTable
        {

            public DeviceData(string name) :base(name)
                
            { 
              
                Add("devices.aid");
                Add("devices.hsn");
                Add("devices.description");
                Add("devices.component");
                Add("devices.manufacturer");
                Add("devices.cfg");
                Add("devices.range");
                Add("devices.unit");
                Add("devices.accuracy");
            }
        }

        DeviceData dut;
        DeviceData ref1;
        DeviceData ref2;
        DeviceData ref3;

        ValueTable order;

        ValueTable customer;

        ValueTable ambientConditions;
        ValueTable procedure;

        public ResultsTable Results;
        public ResultsTable Verification;

        public AkClient Client;

        List<ResultDataPoint> results = new List<ResultDataPoint>();
        List<ResultDataPoint> verification = new List<ResultDataPoint>();
        public double Spangas = 300;

        public string ASTZ = "";
        public string ASTF = "";
        List<string> lin = new List<string>();
        public string Socket;
        ReportMqttClient mqttClient;

        Report report;
        public string DeviceGroup;
        public FormDeviceReader(string name, ReportMqttClient mqttClient,string deviceGroup)
        {
            InitializeComponent();

            DeviceGroup = deviceGroup;
            labelHeader.Text = name;

            dut = new DeviceData("dut");
            ref1 = new DeviceData("ref1");
            ref2 = new DeviceData("ref2");
            ref3 = new DeviceData("ref3");
            order = new ValueTable("order");
            customer = new ValueTable("customer");
            ambientConditions = new ValueTable("ambientConditions");
            procedure = new ValueTable("procedure");
            Results = new ResultsTable();
            Verification = new ResultsTable();

            this.mqttClient = mqttClient;

            order.Add("order.aid");
            order.Add("order.date");
            order.Add("order.location");
            order.Add("order.user");

            customer.Add("customer.aid");
            customer.Add("customer.person");
            customer.Add("customer.company");
            customer.Add("customer.street");
            customer.Add("customer.postcode");
            customer.Add("customer.country");

            ambientConditions.Add("ambient_conditions.t");
            ambientConditions.Add("ambient_conditions.rh");
            ambientConditions.Add("ambient_conditions.patm");

            gridControlDut.DataSource = dut;
            gridControlRef1.DataSource = ref1;
            gridControlRef2.DataSource = ref2;
            gridControlRef3.DataSource = ref3;
            gridControlOrder.DataSource = order;
            gridControlCustomer.DataSource = customer;
            gridControlProcedure.DataSource = procedure;
            gridControlAmbientConditions.DataSource = ambientConditions;
            gridControlResults.DataSource = Results;
            gridControlVerification.DataSource = Verification;


        }

        //void ReplaceNaN() 
        //{
        //    if (e.Column.FieldName == "devRel" && double.IsNaN((double)e.Value))
        //    {
        //        e.DisplayText = "-";
        //    }

        //}


        public void Start()
        {
            Client = new AkClient("LgdClient", Socket);
        }

        public List<string> Command(string cmd)
        {
            string response = Client.Command(cmd);
            Console.WriteLine(response);
            List<string> responseList = response.Split(' ').ToList();
             return responseList;
        }

        void astz()
        {
            
        }

        void astf()
        {
           
        }

        void akak()
        {

        }

        public void LincheckRead()
        {
            verification1066 v1066 = new verification1066();
            List<string> read = Command(" ATST K0 TLIN");
            Log.Information("'"+string.Join(" ", read)+"'");
            dut.Update("devices.aid", Command(" AKEN K0")[3]);
            Log.Information("devices.aid:'" + dut.Read("devices.aid") +"'");

            int hsn0 = int.Parse(Command(" AHSN K0")[3]);
            int hsn1 = int.Parse(Command(" AHSN K0")[4]);

            Log.Information("HSN: " + hsn0.ToString("0000") + "." + hsn1.ToString("0000"));

            dut.Update("devices.hsn", hsn0.ToString("0000") + "." + hsn1.ToString("0000"));

            string r = Command(" AKAK K1 M1")[5].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            Spangas = double.Parse(r, CultureInfo.CurrentCulture);
            Log.Information("Spangas:'" + Spangas + "'");
            Client.Abort();
            dut.Update("devices.description", "Laser gas detector");
            dut.Update("devices.component", "NH3");
            dut.Update("devices.manufacturer", "Amium GmbH");
            dut.Update("devices.unit", "ppm");

            ref1.Update("devices.description", "Gasdivider");
            ref1.Update("devices.manufacturer", "Amium GmbH");

            ref2.Update("devices.description", $"{Spangas} ppm in N2");


            procedure.Add("procedure.step.count");
            procedure.Add("procedure.step.duration");
            procedure.Add("procedure.verification.type");

            procedure.Update("procedure.verification.type", "40CFR1065.307");
            procedure.Update("procedure.step.duration", read[4] + " s");





            string id = DateTime.Now.ToString("yyMMddhhmmss").Replace(" ", "").Replace(":", "").Replace(".", "");

            double n = double.Parse(id);
            long longValue = (long)n;
            id = longValue.ToString("X");

            report = new Report(
            aid: id,
            type: "C0",
            cfg: "linCheck"
            );

            order.Update("order.aid",id);
            order.Update("order.report_aid", id + "-0");
            order.Update("order.date", read[3].Replace("_", " "));

            double div = 0;
            int c = 0;
            foreach (string value in read)
            {
                if (c > 4)
                {
                    if (value.Length > 0)
                    {
                        v1066.Linearity.SamplePoints++;
                        ResultDataPoint p = new ResultDataPoint();
                        p.Cfg = div + " %";
                        p.Ref = Math.Round(div / 100 * Spangas, 2);


                        p.Dut = Math.Round(double.Parse(value, CultureInfo.InvariantCulture), 2);

                        p.DevAbs = Math.Round(p.Dut - p.Ref, 2);
                        if (div > 0)
                        {
                            p.DevRel = Math.Round(p.DevAbs / p.Ref * 100, 2);
                        }

                        results.Add(p);
                        Results.Add(name: p.Cfg, _ref: p.Ref, dut: p.Dut, devAbs: p.DevAbs, devRel: p.DevRel, limit: "", result: "");
                        v1066.Linearity.Dut.Add(p.Dut);
                        v1066.Linearity.Ref.Add(p.Ref);
                        div += 10;
                    }
                }
                
                c++;
            }
    
            v1066.CalculateLinearity();

            ResultDataPoint v = new ResultDataPoint();
            v.Cfg = "n";
            v.Dut = v1066.Linearity.SamplePoints;
            v.Limit = ">= 10";
            v.Result = v1066.Linearity.SamplePoints >= 10 ? "passed" : "failed";
            verification.Add(v);
            Console.WriteLine($"{v.Cfg} {v.Dut} {v.Limit} {v.Result}");
            Verification.Add(name: v.Cfg, dut: v.Dut, limit: v.Limit, result: v.Result);
            procedure.Update("procedure.step.count", v.Dut.ToString());

            v = new ResultDataPoint();
            v.Cfg = "a1";
            v.Dut = Math.Round((double)v1066.Linearity.a1,2);
            v.Limit = "0.98 .. 1.02";
            v.Result = (double)v1066.Linearity.a1 >= 0.98 && (double)v1066.Linearity.a1 <= 1.02 ? "passed" : "failed";
            verification.Add(v);
            Console.WriteLine($"{v.Cfg} {v.Dut} {v.Limit} {v.Result}");
            Verification.Add(name: v.Cfg, dut: v.Dut, limit: v.Limit, result: v.Result);

            v = new ResultDataPoint();
            v.Cfg = "|Xmin(a1-1)+a0|";
            v.Dut = Math.Round((double)v1066.Linearity.xmin, 4);
            double nmax = Math.Round((double)v1066.Linearity.nmax * 0.01, 2);
            v.Limit = $"<= {nmax} [1 % nmax]";
            v.Result = (double)v1066.Linearity.xmin <= nmax ? "passed" : "failed";
            verification.Add(v);
            Console.WriteLine($"{v.Cfg} {v.Dut} {v.Limit} {v.Result}");
            Verification.Add(name: v.Cfg, dut: v.Dut, limit: v.Limit, result: v.Result);

            v = new ResultDataPoint();
            v.Cfg = "SEE";
            v.Dut = Math.Round((double)v1066.Linearity.SEE, 4);
            nmax = Math.Round((double)v1066.Linearity.nmax * 0.02, 2);
            v.Limit = $"<= {nmax} [2 % nmax]";
            v.Result = (double)v1066.Linearity.SEE <= nmax ? "passed" : "failed";
            verification.Add(v);
            Console.WriteLine($"{v.Cfg} {v.Dut} {v.Limit} {v.Result}");
            Verification.Add(name: v.Cfg, dut: v.Dut, limit: v.Limit, result: v.Result);

            v = new ResultDataPoint();
            v.Cfg = "r2";
            v.Dut = Math.Round((double)v1066.Linearity.r2, 4);
            nmax = Math.Round((double)v1066.Linearity.nmax * 0.02, 2);
            v.Limit = $">= 0.99";
            v.Result = (double)v1066.Linearity.r2 >= 0.99 ? "passed" : "failed";
            verification.Add(v);
            Console.WriteLine($"{v.Cfg} {v.Dut} {v.Limit} {v.Result}");
            Verification.Add(name: v.Cfg, dut: v.Dut, limit: v.Limit, result: v.Result);   
        }


        void createReport()
        {

            report.AddOrderData(
                aid: order.Read("order.aid"),
                date: order.Read("order.date"),
                user: order.Read("order.user"),
                location: order.Read("order.location")
                );
            report.AddCustomer(
                aid: customer.Read("customer.aid"),
                person: customer.Read("customer.person"),
                company: customer.Read("customer.company"),
                street: customer.Read("customer.street"),
                postcode: customer.Read("customer.postcode"),
                country: customer.Read("customer.country"));


            report.AddDevice(
                aid: dut.Read("devices.aid"),
                type: "dut",
                component: dut.Read("devices.component"),
                manufacturer: dut.Read("devices.manufacturer"),
                description: dut.Read("devices.description"),
                cfg: dut.Read("devices.cfg"),
                range: dut.Read("devices.range"),
                unit: dut.Read("devices.unit"),
                accuracy: dut.Read("devices.accuracy")
            );

            report.AddDevice(
                aid: ref1.Read("devices.aid"),
                type: "ref1",
                component: ref1.Read("devices.component"),
                manufacturer: ref1.Read("devices.manufacturer"),
                description: ref1.Read("devices.description"),
                cfg: ref1.Read("devices.cfg"),
                range: ref1.Read("devices.range"),
                unit: ref1.Read("devices.unit"),
                accuracy: ref1.Read("devices.accuracy")
            );

            report.AddDevice(
               aid: ref2.Read("devices.aid"),
               type: "ref2",
               component: ref2.Read("devices.component"),
               manufacturer: ref2.Read("devices.component"),
               description: ref2.Read("devices.description"),
               cfg: ref2.Read("devices.cfg"),
               range: ref2.Read("devices.range"),
               unit: ref2.Read("devices.unit"),
               accuracy: ref2.Read("devices.accuracy")
            );

            report.AddDevice(
               aid: ref3.Read("devices.aid"),
               type: "ref3",
               component: ref3.Read("devices.component"),
               manufacturer: ref3.Read("devices.manufacturer"),
               description: ref3.Read("devices.description"),
               cfg: ref3.Read("devices.cfg"),
               range: ref3.Read("devices.range"),
               unit: ref3.Read("devices.unit"),
               accuracy: ref3.Read("devices.accuracy")
            );

            report.AddAmbientConditions(
                t: ambientConditions.Read("ambient_conditions.t"),
                h: ambientConditions.Read("ambient_conditions.rh"),
                p: ambientConditions.Read("ambient_conditions.patm")
                );



            report.AddProcedureData(name: "step.count", value: procedure.Read("procedure.step.count"));
            report.AddProcedureData(name: "step.duration", value: "60 s");
            report.AddProcedureData(name: "verification.type", value: "40CFR1065.307");

            foreach (ResultDataPoint p in results)
            {
                report.result.data.Add(new datapoint(description: p.Cfg, reference: p.Ref.ToString(), dut: p.Dut.ToString(),
                                dutStatisticValues: $"dev.abs={p.DevAbs.ToString().Replace(",", ".")},dev.rel={p.DevRel.ToString().Replace(",", ".")}"));
             
            }
            report.result.data.Add(new datapoint(description: "formula")); // from language database

            foreach (ResultDataPoint p in verification)
            {
                Console.WriteLine(p.Cfg);
                report.result.verification[0].data.Add(new datapoint(description: p.Cfg, dut: p.Dut.ToString(), limit: p.Limit, result: p.Result));
            }

        }


        private void FormLgd_FormClosed(object sender, FormClosedEventArgs e)
        {
            Client.Abort();
        }

        private void FormLgd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Abort();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
           
            createReport();
            var writeOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new qj_NamingPolice(),
                WriteIndented = true
            };

          
            Dictionary<string, string> s = new Dictionary<string, string>();
            s.Add("id", dut.Read("devices.hsn"));
            s.Add("location", dut.Read("devices.aid"));

            string settings = JsonSerializer.Serialize<Dictionary<string, string>>(s, writeOption);
            mqttClient.Publish(mqttClient.RootTopic + DeviceGroup + "/" + dut.Read("devices.hsn") + "/$settings", settings,true);
            string message = JsonSerializer.Serialize<Report>(report, writeOption);
            mqttClient.Publish(mqttClient.RootTopic + DeviceGroup + "/" + dut.Read("devices.hsn") + "/$qa/" + Reporter.dateTime(), message, true);

            message = DateTime.Now.ToString("MM'/'dd HH:mm")+"; " + dut.Read("devices.aid") + "; " + "new lincheck";
            mqttClient.Publish(mqttClient.RootTopic + DeviceGroup + "/" + dut.Read("devices.hsn"),message, true); 





           Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //tring json = JsonSerializer.Serialize<LanguageLabler>(Reporter.Language, Reporter.JsonOptions);

            string directory = "";
            string filename  = "";

            using (System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog())
            {

                ofd.Filter = "(*.json)|";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    directory = Path.GetDirectoryName(ofd.FileName);
                    filename = Path.GetFileName(ofd.FileName).Replace(".json","") ;
                    ValueTableToJsonFile(directory, filename, order);
                    ValueTableToJsonFile(directory, filename, customer);
                    ValueTableToJsonFile(directory, filename, dut);
                    ValueTableToJsonFile(directory, filename, ref1);
                    ValueTableToJsonFile(directory, filename, ref2);
                    ValueTableToJsonFile(directory, filename, ref3);
                    ValueTableToJsonFile(directory, filename, procedure);
                    ValueTableToJsonFile(directory, filename, ambientConditions);

                    //string json = JsonSerializer.Serialize<Dictionary<string, string>>(convertDataTable(dut), Reporter.JsonOptions);
                    //File.WriteAllText(ofd.FileName + "_dut.json", json);

                }
            }

        }

        void ValueTableToJsonFile(string folder, string name, ValueTable table)
        {
            try
            {

                Dictionary<string, string> result = new Dictionary<string, string>();

                foreach (DataRow row in table.Rows)
                {
                    string key = row["name"].ToString();
                    string value = row["value"].ToString();
                    result.Add(key, value);
                }
                string json = JsonSerializer.Serialize<Dictionary<string, string>>(result, Reporter.JsonOptions);
                string filename = name + "_" + table.Name + ".json";
                File.WriteAllText(Path.Combine(folder, filename), json);
            }
            catch
            {
                Log.Fatal($"Export Valuetable: {folder} {name} {table.Name}");
            
            }
        }

        void JsonFileToValueTable(string file)
        {
           
            bool isDut = false;
            try
            {

                ValueTable table = null;
                if (file.EndsWith("dut.json"))
                {
                    table = dut;
                    Console.WriteLine("table dut");
                    isDut = true;
                }


                if (file.EndsWith("ref1.json"))
                {
                    table = ref1;
                }

                if (file.EndsWith("ref2.json"))
                {
                    table = ref2;

                }

                if (file.EndsWith("ref3.json"))
                {
                    table = ref3;

                }

                if (file.EndsWith("order.json")) table = order;

                if (file.EndsWith("customer.json")) table = customer;
                if (file.EndsWith("ambientConditions.json")) table = ambientConditions;
                if (file.EndsWith("procedure.json")) table = procedure;

                string json = System.IO.File.ReadAllText(file);
                Dictionary<string, string> read = JsonSerializer.Deserialize<Dictionary<string, string>>(json, Reporter.JsonOptions);

                Console.WriteLine("Table selected " + table.Name);

                if (isDut) 
                {
                    foreach (var item in read)
                    { 
                        if(!item.Key.EndsWith("hsn") && !item.Key.EndsWith("aid"))
                        table.Update(item.Key, item.Value);
                    }

                }
                else
                {
                    foreach (var item in read)
                        table.Update(item.Key, item.Value);   
                }
            }
            catch
            {
                Log.Fatal($"Import Valuetable: {file}");
            }

            //gridControlDut.Refresh();
            //gridView1.RefreshData();
 
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {

                ofd.Filter = "(*.json)|";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    JsonFileToValueTable(ofd.FileName);
                }
            }

        }

        private void gridViewResults_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "devRel" && double.IsNaN((double)e.Value))
            {
                e.DisplayText = "";
            }
        }

        private void gridViewVerification_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "devRel" || e.Column.FieldName == "ref" || e.Column.FieldName == "devAbs")
            {

                if (double.IsNaN((double)e.Value))
                    e.DisplayText = "";

            }
   

        }

        private void tabControlData_DragDrop(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Copy;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                foreach (string file in files) {
                    JsonFileToValueTable(file);

                    }
               // JsonFileToValueTable(ofd.FileName);
               // /// textBox1.Text = files[0]; // Display the first file path in the TextBox
            }
        }

        private void tabControlData_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            string test  = dut.Rows[rowHandle]["name"].ToString();
            Console.WriteLine(test);

            if (test.EndsWith("hsn") || test.EndsWith("aid"))
            {
                Console.WriteLine("is hsn");
                e.Cancel = true;
                return;
            }     
               
        }

        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)
        {

            //int rowHandle = gridView2.FocusedRowHandle;
            //string test = ref1.Rows[rowHandle]["name"].ToString();
            //Console.WriteLine(test);

            //if (test.EndsWith("hsn") || test.EndsWith("aid"))
            //{
            //    Console.WriteLine("is hsn");
            //    e.Cancel = true;
            //    return;
            //}

        }

        private void gridView3_ShowingEditor(object sender, CancelEventArgs e)
        {
            //int rowHandle = gridView3.FocusedRowHandle;
            //string test = ref2.Rows[rowHandle]["name"].ToString();
            //Console.WriteLine(test);

            //if (test.EndsWith("hsn") || test.EndsWith("aid"))
            //{
            //    Console.WriteLine("is hsn");
            //    e.Cancel = true;
            //    return;
            //}

        }

        private void gridView4_ShowingEditor(object sender, CancelEventArgs e)
        {
            //int rowHandle = gridView4.FocusedRowHandle;
            //string test = ref3.Rows[rowHandle]["name"].ToString();
            //Console.WriteLine(test);

            //if (test.EndsWith("hsn") || test.EndsWith("aid"))
            //{
            //    Console.WriteLine("is hsn");
            //    e.Cancel = true;
            //    return;
            //}
        }
    }

   
}