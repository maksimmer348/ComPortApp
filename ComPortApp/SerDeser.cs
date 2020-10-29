using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace ComPortApp

{
    public class SerDeser
    {
        List<ComConfig> ComConf = new List<ComConfig>();

        //Bug: del
        ////Person tom = new Person { Name = "Tom", Age = 35 };
        private void Deserialize()
        {
            
            //JsonConvert.DeserializeObject<>(File.ReadAllText("Materials.json"));

            //MatTerm.Insert(0, new ThermalMaterial() { Name = "", Min = -99999999999999999, Max = 99999999999999999 });

            //MatTerm = MatTerm.Where(e => e.Min <= e.Max).ToList();

            //UpdateCombobox();


        }

        public void Serialize()
        {

            //var matTermTemp = MatTerm.ToList();
            //matTermTemp.RemoveAt(0);
            //Bug: del
            //string json = JsonSerializer.Serialize<Person>(tom);
            //Console.WriteLine(json);
            string ss = JsonConvert.SerializeObject(ComConf, Formatting.Indented);

            File.WriteAllText("Settings.json", ss, Encoding.UTF8);
        }
    }
}