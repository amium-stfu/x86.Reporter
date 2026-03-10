using DevExpress.Pdf.Native.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReportExplorer
{


    public class qj_NamingPolice : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            string newName = name.Replace("__", ".");
            return newName;
        }
    }

public class languages
    {
        public Dictionary<string, Dictionary<string, string>> keyWord
        {
            get; set;
        }

        public languages() { }
        public languages(string id)
        {
            keyWord = new Dictionary<string, Dictionary<string, string>>();
        }
    }




    public class Report
    {
        public Dictionary<string, string> sys
        {
            get; set;
        }
        public Dictionary<string, string> order
        {
            get; set;
        }
        public List<Dictionary<string, string>> customer
        {
            get; set;
        }
        public List<device> devices
        {
            get; set;
        }
        public Dictionary<string, string> procedure
        {
            get; set;
        }

        public Dictionary<string, string> ambient_conditions
        {
            get; set;
        }

        public result result
        {
            get; set;
        }

        public Report() { }

        public Report(string aid,string type, string cfg) 
        {

            sys = new Dictionary<string, string>();
            order = new Dictionary<string, string>();
            customer = new List<Dictionary<string, string>>();
            devices = new List<device>();
            procedure = new Dictionary<string, string>();
            ambient_conditions = new Dictionary<string, string>();
            result = new result("manual");

            sys.Add("aid", aid);
            sys.Add("type", type);
            sys.Add("cfg", cfg);
          
        }

        public void AddDevice(
            string aid = null,
            string hsn = null,
            string type = null,
            string component = null, 
            string manufacturer = null,
            string description = null, 
            string cfg = null, 
            string range = null, 
            string unit = null,
            string accuracy = null,
            string calibrationAid = null,
            string calibrationDate = null,
            string calibrationValidUntil = null
            )
        {
            device _device = new device();

           
            _device.data.Add("aid", aid);
            _device.data.Add("hsn", hsn);
            _device.data.Add("type", type);
            _device.data.Add("component", component);
            _device.data.Add("manufacturer", manufacturer);
            _device.data.Add("description", description);
            _device.data.Add("cfg", cfg);
            _device.data.Add("range", range);
            _device.data.Add("unit", unit);
            _device.data.Add("accuracy", accuracy);
            _device.calibration.Add("date", calibrationDate);
            _device.calibration.Add("aid", calibrationAid);
            _device.calibration.Add("valid_until", calibrationValidUntil);




            devices.Add(_device);
        }
        public void AddAmbientConditions(string t = null, string h = null, string p = null)
        {
            ambient_conditions.Add("t", t); 
            ambient_conditions.Add("rh", h);
            ambient_conditions.Add("patm", p);

        }
        public void AddOrderData(string aid = null, string reportAid = null, string date = null, string location = null, string user = null)
        {
            order.Add("aid", aid);
            order.Add("report_aid", reportAid);
            order.Add("date", date);
            order.Add("location", location);
            order.Add("user", user);
  
        }
        public void AddProcedureData(string name, string value = null)
        {
            procedure.Add(name, value);
         

        }

        public void AddCustomer(
            string aid = null,
            string aidLabel = null,
            string person = null,
            string personLabel = null,
            string company = null,
            string company_label = null,
            string street = null,
            string street_label = null,
            string postcode = null,
            string postcode_label = null,
            string country = null,
            string country_label = null
            )
        {
            Dictionary<string, string> item = new Dictionary<string, string>();
            item.Add("aid", aid);        
            item.Add("person", person);        
            item.Add("company", company);      
            item.Add("street", street);      
            item.Add("postcode", street);;
            item.Add("country", country);
            customer.Add(item);
        }
    }
    public class device
    {
        public Dictionary<string, string> data
        {
            get; set;
        }
        public Dictionary<string, string> calibration
        {
            get; set;
        }

        public device () {
            data = new Dictionary<string, string>();
            calibration = new Dictionary<string, string>();
        }
    }

    public class ReadValue
    {
        public string read { get; set; }
        public string set { get; set; }
        public string raw { get; set; }
        public Dictionary<string, string> stats { get; set; }

        public ReadValue()
        {

        }

        public ReadValue(string read = null,string raw = null, string set = null, string statisticValues = null)
        {
            this.read = read;
            this.set = set;
            this.raw = raw;
            stats = new Dictionary<string, string>();

            if (statisticValues != null)
            {
                
                List<string> statsRead = statisticValues.Split(',').ToList();
                foreach (string item in statsRead)
                {
                    stats.Add(item.Split('=')[0], item.Split('=')[1]);
                    Debug.WriteLine(item);

                }

            }
        }
    }


    public class datapoint
    {
        public string description { get; set; }

        public string dut { get; set; }
      //  public ReadValue dut__stats { get; set; }

        public Dictionary<string, string> dut__stats { get; set; }
        public string reference { get; set; }
       // public ReadValue reference__Stats { get; set; }

        public Dictionary<string, string> reference__stats { get; set; }

        public string limit { get; set; }
        public string result { get; set; }

        public datapoint() { }

        public datapoint(
            string description = null,
            string reference = null, 
            string dut = null, 
            string limit = null, 
            string result = null, 
            string dut_raw = null,
            string reference_raw = null, 
            string dutStatisticValues = null, 
            string referenceStatisticValues = null,
            string referenceSet = null) 

          
        {
            this.description = description;
            this.dut = dut;
            this.reference = reference;
            dut__stats = new Dictionary<string, string>();
            reference__stats = new Dictionary<string, string>();

            Console.WriteLine("datapoint: " + description + " " + dut + "dutstats '" + dutStatisticValues + "refstats '" + referenceStatisticValues + "'");
     

            if (dutStatisticValues != null)
            {
                List<string> statsRead = dutStatisticValues.Split(',').ToList();
                foreach (string item in statsRead)
                {
                    dut__stats.Add(item.Split('=')[0], item.Split('=')[1]);
                   Console.WriteLine(item);
                }
            }
            if (referenceStatisticValues != null)
            {
                List<string> statsRead = referenceStatisticValues.Split(',').ToList();
                foreach (string item in statsRead)
                {
                    reference__stats.Add(item.Split('=')[0], item.Split('=')[1]);
                    Console.WriteLine(item);
                }
            }


            this.limit = limit;
            this.result = result;
        }
    }


    public class result
    {

        public List<datapoint> data { get; set; }
        public List<verification_type> verification { get; set; }
       
        public result() { }
        public result(string types) {

            data = new List<datapoint>();
            verification = new List<verification_type>();

            List<string> list = new List<string>();
            list = types.Split(',').ToList();

            foreach (string type in list)
                verification.Add(new verification_type(type: type));
        }
    }
    public class verification_type
    {
    
        public string type { get; set; }
        public List<datapoint> data { get; set; }
        public verification_type() { }
        public verification_type(string type) 
        {
     
            this.type = type;
            data = new List<datapoint>();
        }
    }

        public class C0
    {

        public string DeviceId
        {
            get; set;
        }

        public string Date
        {
            get; set;
        }

        public string Range
        {
            get; set;
        }

        public string OrderNumber
        {
            get; set;
        }

        public List<string> OrderData
        {
            get; set;
        }
        public List<string> Results
        {
            get; set;
        }
  
     

        public C0() { }
        public C0(string id, string date, string range, string oderNumber, List<string> orderData, List<string> results)
        {
            DeviceId = id;
            Date = date;
            Range = range;
            OrderNumber = oderNumber;
            OrderData = orderData;
            Results = results;
        }

    }

 
}
