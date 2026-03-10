using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.Utils.DPI;
using DevExpress.XtraReports;
using PdfSharp.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;

namespace ReportExplorer
{

    public class C0report
    {
        PdfWriter pdf = new PdfWriter("C0");
        public Dictionary<string, string> Language = new Dictionary<string, string>();

        string language;
        public Report Source;
        public string Headline1 = "amium";
        public string Headline2 = "C0 Calibration certificate";

        public C0report() {

        }


        public void Export() { 
        

        }

        void writeGroup(string group, double x, double y, double hLine, double wLabel, double wValue, string labelStyle = "Regular", string valueStyle = "Bold",string exclude = "", int index = 0)
        {
            int line = 0;


            Dictionary<string, string> list = new Dictionary<string, string>();

            if (group == "order")
                list = Source.order;

            if (group == "customer")
                list = Source.customer[index];

            if (group == "procedure")
                list = Source.procedure;

            if (group == "devices")
                list = Source.devices[index].data;

            if (group == "ambient_conditions")
                list = Source.ambient_conditions;


            List<string> temp = exclude.Split(',').ToList();

            List<string> excludeList = new List<string>();
            foreach (string ex in temp)
                excludeList.Add(group + "." + ex);

            Dictionary<string, string> valueList = new Dictionary<string, string>();
            Dictionary<string, string> labelList = new Dictionary<string, string>();


            foreach (var kvp in list)
            {
                if (!kvp.Key.EndsWith("__label"))
                {
                    valueList.Add(group + "." + kvp.Key, kvp.Value);
                    labelList.Add(group + "." + kvp.Key, kvp.Key);
                }
            }

            foreach (var kvp in valueList)
            {
                if (!excludeList.Contains(kvp.Key) && kvp.Value != null)
                {
                  // Debug.WriteLine("'"+ kvp.Key+ "'");
               
                    string label = Reporter.Language.GetLabel(kvp.Key);
                    string value = kvp.Value;
                    line = TextWithLinefeed(line, x: x, y: y + hLine * line, w: wLabel, h: hLine, aling: "Left", labeFontStyle: labelStyle, valueFontStyle:valueStyle, label: label, value: value);
                }

            }
        }

        int TextWithLinefeed(int line,double x, double y, double w, double h, string aling, string labeFontStyle, string valueFontStyle, string label, string value)
        {
            List<string> lines = value.Split('\n').ToList();
            pdf.Text(label, "Calibri", size: 3, color: "black", x: x, y, w: w, align: aling, fontStyle: labeFontStyle);
            int subline = 0;
            foreach (string lineText in lines)
            {
               // Debug.WriteLine("lines = " + count + ": " + lineText);
                pdf.Text(lineText, "Calibri", size: 3, color: "black", x: x+w, y + subline * h, w: w, align: aling, fontStyle: valueFontStyle);
                subline++;
                line++;
            }

            return line;
        }
        void writeValueList(string group, string nameList, double x, double y, double h, double wLabel, double wValue, string labelStyle = "Regular", string valueStyle = "Bold",int index = 0)
        {
            int line = 0;
            foreach(string name in nameList.Split(','))
            {
                string value = readValue(group, name, index:index, key:false);
                string label = readValue(group, name, index:index, key: true);

                label = Reporter.Language.GetLabel(group + "." + label);

                line = TextWithLinefeed(line, x: x, y: y + line * h, w: wLabel, h: h, aling: "Left", labeFontStyle: labelStyle, valueFontStyle: valueStyle, label: label, value: value);
            }

        }

        int writeValue(string group,string name, double x, double y, double h, double wLabel, double wValue, string labelStyle = "Regular", string valueStyle = "Bold",int index = 0 )
        {
            int linefeed = 0;
            Dictionary<string, string> list = new Dictionary<string, string>();


            if (group == "order")
                list = Source.order;

            if (group == "customer")
                list = Source.customer[index];

            if (group == "procedure")
                list = Source.procedure;

            if (group == "devices")
                list = Source.devices[index].data;

            if (group == "ambient_conditions")
                list = Source.ambient_conditions;

            string label = null;
            string value = null;

                foreach (var kvp in list)
                {
                    if (kvp.Key == name)
                    {
                        //label = group + "."+kvp.Key;
                   // label = Language.ContainsKey(group + "." + kvp.Key) ? Language[group + "." + kvp.Key] : group + "." + kvp.Key;
                    label = Reporter.Language.GetLabel(group + "." + kvp.Key);
                    value = kvp.Value;

                    }
                }

            if (value != null)
            {
                pdf.Text(label, "Calibri", size: 3, color: "black", x: x, y: y + h * linefeed, w: wLabel, align: "Left", fontStyle: labelStyle);
                pdf.Text(value, "Calibri", size: 3, color: "black", x: x + wLabel, y: y + h * linefeed, w: wLabel, align: "Left", fontStyle: valueStyle);
                linefeed++;
            }
            else
            {
                Debug.WriteLine(group + "." +  name + " not found");

            }

            return linefeed;
        }
        void writeCustomValue(string label, string value, double x, double y, double h, double wLabel, double wValue, string labelStyle = "Regular", string valueStyle = "Bold")
        {
            int linefeed = 0;
            pdf.Text(label, "Calibri", size: 3, color: "black", x: x, y: y + h * linefeed, w: wLabel, align: "Left", fontStyle: labelStyle);
            pdf.Text(value, "Calibri", size: 3, color: "black", x: x + wLabel, y: y + h * linefeed, w: wLabel, align: "Left", fontStyle: valueStyle);
          
        }
        public string readValue(string group, string name, int index = 0, bool key = false)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();


            if (group == "sys")
                list = Source.sys;

            if (group == "order")
                list = Source.order;

            if (group == "customer")
                list = Source.customer[index];

            if (group == "procedure")
                list = Source.procedure;

            if (group == "devices")
                list = Source.devices[index].data;

            if (group == "ambient_conditions")
                list = Source.ambient_conditions;

            string result = "NA";
            foreach (var kvp in list)
            {
                if (kvp.Key == name)
                {
                    result = kvp.Value;
                    if (key)
                        result = kvp.Key;
                }
            }
            return result;
        }
        void writeResults(string group, double x, double y, double hLine,string columnsWidth = "20,20,20,20,20", string fontStyle = "Regular")
        {
            int line = 0;
            double parsedVal;
            double[] columns = columnsWidth.Split(',').Select(str => double.TryParse(str, out parsedVal) ? parsedVal : 0).ToArray();
            string unit = readValue("devices", "unit",index:0);

            if (group == "HEADER")
            {
                pdf.Text(Reporter.Language.GetLabel("configuration"), "Calibri", size: 3, color: "black", x: x, y: y + hLine * line, w: columns[0], align: "Right", fontStyle: "Bold");
                pdf.Text(Reporter.Language.GetLabel("measurement.reference") +" in " + unit, "Calibri", size: 3, color: "black", x: x + columns[0], y: y + hLine * line, w: columns[1], align: "Right", fontStyle: "Bold");
                pdf.Text(Reporter.Language.GetLabel("measurement.dut") + " in " + unit, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1], y: y + hLine * line, w: columns[2], align: "Right", fontStyle: "Bold");
                pdf.Text(Reporter.Language.GetLabel("rating") +" (" + Reporter.Language.GetLabel("limit") +")", "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1] + columns[2], y: y + hLine * line, w: columns[3], align: "Right", fontStyle: "Bold");
                return;
            }

            foreach(datapoint point in Source.result.data)
            {

                // string type = d[0];

                string description = point.description;
                string dut = point.dut;
                string reference = point.reference;
                string limit = point.limit;
                string result = point.result;


                string dev_abs = null;
                string dev_rel = null;
                string dev_std = null;

                dev_abs = point.dut__stats.ContainsKey("dev.abs") ? point.dut__stats["dev.abs"] : null;
                dev_rel = point.dut__stats.ContainsKey("dev.rel") ? point.dut__stats["dev.rel"] : null;
                dev_std = point.dut__stats.ContainsKey("dev.std") ? point.dut__stats["dev.std"] : null;

                string rating = $"Δ {dev_abs} {unit} / {dev_rel} %";

                if (limit != null)
                    rating = rating + " (" + limit + ")";

                if (dev_rel == null || dev_rel.ToUpper() == "NAN")
                    rating = $"Δ {dev_abs} {unit} / -";

                if (description == "formula")
                {
                    pdf.Text(Reporter.Language.GetLabel(Source.sys["cfg"] + ".formula"), "Calibri", size: 2, color: "black", x: x, y: y + hLine * line + 1, w: columns[0], align: "Left", fontStyle: fontStyle);
                }
                else
                {
                    pdf.Text(Reporter.Language.GetLabel(description), "Calibri", size: 3, color: "black", x: x, y: y + hLine * line, w: columns[0], align: "Right", fontStyle: fontStyle);
                    pdf.Text(reference, "Calibri", size: 3, color: "black", x: x + columns[0], y: y + hLine * line, w: columns[1], align: "Right", fontStyle: fontStyle);
                    pdf.Text(dut, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1], y: y + hLine * line, w: columns[2], align: "Right", fontStyle: fontStyle);
                    pdf.Text(rating, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1] + columns[2], y: y + hLine * line, w: columns[3], align: "Right", fontStyle: fontStyle);
                    pdf.Text(result, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1] + columns[2] + columns[3] + 2, y: y + hLine * line, w: columns[4], align: "Left", fontStyle: "Bold");
                }
                line++;

            }

        }
        void writeVerification(double x, double y, double hLine, string columnsWidth = "20,20,20,20,20", string fontStyle = "Regular",int index = 0)
        {
            int line = 0;
            double parsedVal;
            double[] columns = columnsWidth.Split(',').Select(str => double.TryParse(str, out parsedVal) ? parsedVal : 0).ToArray();


            foreach (datapoint point in Source.result.verification[index].data)
            {

                // string type = d[0];

                string description = point.description;
                string dut = point.dut;
                string reference = point.reference;
                string limit = point.limit;
                string result = point.result;

                string rating = "(" + limit + ")";

                pdf.Text(description, "Calibri", size: 3, color: "black", x: x, y: y + hLine * line, w: columns[0], align: "Right", fontStyle: fontStyle);
                pdf.Text(reference, "Calibri", size: 3, color: "black", x: x + columns[0], y: y + hLine * line, w: columns[1], align: "Right", fontStyle: fontStyle);
                pdf.Text(dut, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1], y: y + hLine * line, w: columns[2], align: "Right", fontStyle: fontStyle);
                pdf.Text(rating, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1] + columns[2], y: y + hLine * line, w: columns[3], align: "Right", fontStyle: fontStyle);
                pdf.Text(result, "Calibri", size: 3, color: "black", x: x + columns[0] + columns[1] + columns[2] + columns[3] + 2, y: y + hLine * line, w: columns[4], align: "Left", fontStyle: "Bold");
                line++;
            }

        }


        public string Create(bool preview, bool protect,string language = "en")
        {

            this.language = language; 
            pdf.Open("test");
            pdf.NewPage();
            //Page 1
            AddHeader();
            AddCalMark(1,2);

            //BodyGrid

            pdf.Line("lightGray", 0.3, x1: 99,  y1: 27, x2: 99, y2: 193);  //V 1
            pdf.Line("lightGray", 0.3, x1: 198, y1: 27, x2: 198, y2: 193); //V 2

            pdf.Line("lightGray", 0.3, x1: 10, y1: 110, x2: 97, y2: 110); //H 1

            pdf.Line("lightGray", 0.3, x1: 101, y1: 110, x2: 196, y2: 110); //H 2

            pdf.Line("lightGray", 0.3, x1: 200, y1: 81.66, x2: 287, y2: 81.66); //H 3
            pdf.Line("lightGray", 0.3, x1: 200, y1: 138.32, x2: 287, y2: 138.32); //H 3


            //Content
            pdf.Text(Reporter.Language.GetLabel("order"), "Calibri", size: 3, color: "black", x: 10, y: 26.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("dut"), "Calibri", size: 3, color: "black", x: 102, y: 26.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 1", "Calibri", size: 3, color: "black", x: 201, y: 26.5, w: 90, align: "Left", fontStyle: "Bold");

            pdf.Text(Reporter.Language.GetLabel("procedure"), "Calibri", size: 3, color: "black", x: 10, y: 111.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("settings"), "Calibri", size: 3, color: "black", x: 102, y: 111.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 2", "Calibri", size: 3, color: "black", x: 201, y:83.16, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 3", "Calibri", size: 3, color: "black", x: 201, y:139.82, w: 90, align: "Left", fontStyle: "Bold");

           
            //Order
            writeValue("order", "aid",       x: 10, y: 31.5, h: 5, wLabel: 40, wValue: 50);
            writeValue("order", "location", x: 10, y: 38.5, h: 5, wLabel: 40, wValue: 50);
            writeValue("order", "date",     x: 10, y: 43.5, h: 5, wLabel: 40, wValue: 50);
            writeValue("order", "user",     x: 10, y: 48.5, h: 5, wLabel: 40, wValue: 50);

            writeGroup("customer", x: 10, y: 57.5, hLine: 5, wLabel: 40, wValue: 50);

            //Procedure
           
            pdf.TextBox(Reporter.Language.GetLabel("procedure." + Source.sys["cfg"]), x: 10, y: 116.5, w: 85, h: 60, fontName: "Calibri", "Black", size: 2.8, fontStyle: "Regular");
            // pdf.TextBox(Source.sys["description"], x: 10, y: 156.5, w: 85, h: 60, fontName: "Calibri", "Black", size: 3, fontStyle: "Italic");
               pdf.TextBox(Reporter.Language.GetLabel("sys.c0.description"), x: 10, y: 156.5, w: 85, h: 60, fontName: "Calibri", "Black", size: 2.8, fontStyle: "Italic");

            //Device under test

            writeGroup("devices", x: 102, y: 31.5, hLine: 5, wLabel: 40, wValue: 50, index: 0, exclude: "type");

            //Setings
            writeGroup("procedure", x: 102, y: 116.5, hLine: 5, wLabel: 40, wValue: 50,exclude:"description");

            //Reference 1

            writeGroup("devices", x: 201, y: 31.5, hLine: 5, wLabel: 40, wValue: 50,index:1,exclude:"type");

            ////Reference 2
            writeGroup("devices", x: 201, y: 88.16, hLine: 5, wLabel: 40, wValue: 50,index:2, exclude: "type");

            ////Reference 3
            writeGroup("devices", x: 201, y: 144.82, hLine: 5, wLabel: 40, wValue: 50,index:3, exclude: "type");



            //Footer
            AddFooter();

            pdf.NewPage();
            //Page 2
            AddHeader();
            AddCalMark(2,2);

            //BodyGrid
            pdf.Line("lightGray", 0.3, x1: 99, y1: 27, x2: 99, y2: 193);

            pdf.Line("lightGray", 0.3, x1: 10, y1:59, x2: 97, y2:59);
            pdf.Line("lightGray", 0.3, x1: 10, y1: 93, x2: 97, y2: 93);
            pdf.Line("lightGray", 0.3, x1: 10, y1: 127, x2: 97, y2: 127);
            pdf.Line("lightGray", 0.3, x1: 10, y1: 161, x2: 97, y2: 161);

            pdf.Line("lightGray", 0.3, x1: 101, y1: 144, x2: 287, y2: 144);

            //Content
            pdf.Text(Reporter.Language.GetLabel("dut"), "Calibri", size: 3, color: "black", x: 10, y: 26.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 1", "Calibri", size: 3, color: "black", x: 10, y: 60.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 2", "Calibri", size: 3, color: "black", x: 10, y: 94.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("reference") + " 3", "Calibri", size: 3, color: "black", x: 10, y: 128.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("ambient.conditions"), "Calibri", size: 3, color: "black", x: 10, y: 162.5, w: 90, align: "Left", fontStyle: "Bold");

            pdf.Text(Reporter.Language.GetLabel("measurement.result"), "Calibri", size: 3, color: "black",  x: 102, y: 26.5, w: 90, align: "Left", fontStyle: "Bold");
            pdf.Text(Reporter.Language.GetLabel("verification.result"), "Calibri", size: 3, color: "black", x: 102, y: 145.5, w: 90, align: "Left", fontStyle: "Bold");

            //Device under test
            writeValue("devices", "description", x: 10, y: 31.5, h: 5, wLabel: 40, wValue: 50,index:0);
            writeValue("devices", "aid", x: 10, y: 36.5, h: 5, wLabel: 40, wValue: 50, index: 0);
            writeCustomValue("Component", readValue("devices", "component",index:0) + " " +  readValue("devices", "range",index:0) + " " + readValue("devices", "unit",index:0), x: 10, y: 41.5, h: 5, wLabel: 40, wValue: 50);
            writeValue("devices", "accuracy", x: 10, y: 46.5, h: 5, wLabel: 40, wValue: 50);

            //Reference 1
            writeValueList("devices", nameList:"description,aid,accuracy", x: 10, y: 65.5, h: 5, wLabel: 40, wValue: 50,index:1);

            //Reference 2
            writeValueList("devices", nameList: "description,aid,accuracy", x: 10, y: 99.5, h: 5, wLabel: 40, wValue: 50,index:2);

            //Reference 3
            writeValueList("devices", nameList: "description,aid,accuracy", x: 10, y: 133.5, h: 5, wLabel: 40, wValue: 50,index:3);
    

            //Ambient conditions
            writeGroup("ambient_conditions", x: 10, y: 167.5, hLine: 5, wLabel: 40, wValue: 50);


            //Results

            writeResults("HEADER", x: 102, y: 33.5, hLine: 5, columnsWidth: "30,35,35,60,20", fontStyle: "Regular");

            writeResults("LIN", x: 102, y: 40, hLine: 5, columnsWidth: "30,35,35,60,20", fontStyle: "Regular");

            writeVerification(x: 102, y: 152.5, hLine: 5, columnsWidth: "30,35,35,60,20", fontStyle: "Regular");

            //Footer
            AddFooter();
           
            //pdf.Save("test.pdf", true);
            string file = "";
            if (preview)
            {
                file = pdf.Preview(protect: protect);

            }
            else
            {
                Console.WriteLine("Try save pdf " + protect);
                pdf.Save(protect: protect);
            }

            return file;
        }

        void AddCalMark(int page, int pageMax)
        {
            pdf.Rectangle("Gray", 0.5, x: 267, y: 5, w: 20, h: 15);
            pdf.Line("Gray", 0.5, x1: 267, y1: 9, x2: 287, y2: 9);
            pdf.Line("Gray", 0.5, x1: 267, y1: 16, x2: 287, y2: 16);

            pdf.Text("amium", "Calibri", size: 2.5, x: 267, y: 5, w: 20, align: "Center");

            pdf.Text(readValue("order", "aid"), "Calibri", size: 2.5, x: 267, y: 9, w: 20, align: "center");
            //pdf.Text(readValue("ORDER", "PNOE"), "Calibri", size: 2.5, x: 267, y: 12, w: 20, align: "center");
            pdf.Text(readValue("order", "date").Substring(0,7), "Calibri", size: 2.5, x: 267, y: 16, w: 20, align: "center");

            pdf.Text(Reporter.Language.GetLabel("page") + " " + page + " / " + pageMax, "Calibri", size:3, x: 245, y:4.5, w: 20, align: "right");
            pdf.Text(Reporter.Language.GetLabel("calibration.mark"), "Calibri", size: 3, x: 245, y: 15, w: 20, align: "right");  
        }

        void AddHeader()
        {
            pdf.Text(Headline1, "Ft4", size: 11, color: "black", x: 10, y: 0, align: "Left");
            pdf.Text(Reporter.Language.GetLabel("sys.c0.title"), "Calibri", size: 4, y: 18, align: "Left");
            pdf.Bounds = null;
            pdf.Line("lightGray", 0.3, x1: 10, y1: 25, x2: 287, y2: 25);

        }

        void AddFooter()
        {
            pdf.Line("lightGray", 0.3, x1: 10, y1: 195, x2: 287, y2: 195);
            pdf.Text("Amium GmbH", "Calibri", size: 2, x: 10, y: 197, w: 20, align: "Left");
            pdf.Text(pdf.Filename, "Calibri", size: 2, x: 10, y: 200.5, w: 20, align: "Left");
        }
    }
}
