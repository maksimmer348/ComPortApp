using System.IO;
using Newtonsoft.Json;
namespace ComPortApp

{
    public class SerDeser
    {
        private void Deserialize()
        {
            //JsonConvert.DeserializeObject<>(File.ReadAllText("Materials.json"));

            //MatTerm.Insert(0, new ThermalMaterial() { Name = "", Min = -99999999999999999, Max = 99999999999999999 });

            //MatTerm = MatTerm.Where(e => e.Min <= e.Max).ToList();

            //UpdateCombobox();


        }

        private void Serialize()
        {
            //var matTermTemp = MatTerm.ToList();
            //matTermTemp.RemoveAt(0);
            //string ss = JsonConvert.SerializeObject(matTermTemp, Formatting.Indented);

            //File.WriteAllText("Materials.json", ss, Encoding.UTF8);
        }
    }
}