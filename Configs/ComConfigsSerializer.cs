using System.IO;
using Newtonsoft.Json;

namespace ComPortSettings
{
    public class ComConfigsSerializer
    {
        const string Path = "Settings.json";
        public void Serialize(ComConfig[] config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            
            File.WriteAllText(Path, json);
        }

        public ComConfig[] Deserialize()
        {
            var config = JsonConvert.DeserializeObject<ComConfig[]>(File.ReadAllText(Path));
            return config;
        }
    }
}