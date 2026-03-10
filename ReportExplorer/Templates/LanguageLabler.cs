using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DevExpress.Utils.Frames.FrameHelper;

namespace ReportExplorer
{
    public class LanguageLabler
    {

        public string Name;
        public Dictionary<string, Dictionary<string, string>> keyWord
        {
            get; set;
        }

        public string Set = "en";

        public LanguageLabler() 
        { 
        }
        public LanguageLabler(string name) { 
            Name = name;
            keyWord = new Dictionary<string, Dictionary<string, string>>();
        }

        public string GetLabel(string key)
        {
            string result = key;
       
        
            if (keyWord.ContainsKey(key))
            {
                Dictionary<string, string> word = keyWord[key];
                if (word.ContainsKey(Set))
                {
                    result = word[Set];
                }
            }

            return result;
        }

        public void Export()
        {
            var option = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new qj_NamingPolice(),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize<Dictionary<string, Dictionary<string, string>>>(keyWord,option);


            using (System.Windows.Forms.SaveFileDialog ofd = new System.Windows.Forms.SaveFileDialog())
            {

                ofd.Filter = "(*.json)|";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (!ofd.FileName.EndsWith(".json"))
                        ofd.FileName = ofd.FileName + ".json";
                    System.IO.File.WriteAllText(ofd.FileName, json);
                }
            }
        }

        public void Import()
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
                        languages test = JsonSerializer.Deserialize<languages>(json, option);
                        keyWord = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>> > (json, option);
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine("Language import failed: " + ex.ToString());
            }
        }


    }
}
