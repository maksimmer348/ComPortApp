using System.IO;
using Newtonsoft.Json;

namespace ComPortSettings
{
    public class ComConfigsSerializer
    {
        public void Serialize(ComConfig[] config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            
            File.WriteAllText("Settings.json", json);
            
          
        }

        public ComConfig[] Deserialize()
        {
          

            var config = JsonConvert.DeserializeObject<ComConfig[]>(File.ReadAllText("Settings.json"));
            
            return config;
        }
    }
}