using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ComPortSettings
{
    public class ComSettingSerializer
    {
       
        public void Serialize()
        {
            string json = JsonConvert.SerializeObject(comConfigs, Formatting.Indented);
            File.WriteAllText("Settings.json", json, Encoding.UTF8);
        }

        private void Deserialize()
        {
            var ss = JsonConvert.DeserializeObject<List<ComConfig>>(File.ReadAllText("Settings.json"));
        }
    }
}