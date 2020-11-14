using System.IO;
using Newtonsoft.Json;

namespace ComPortSettings
{
    public class ComConfigsSerializer
    {
        public void Serialize(Stream stream, ComConfig[] config)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            
            var writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }

        public ComConfig[] Deserialize(Stream stream)
        {
            var reader = new StreamReader(stream);
            
            var config = JsonConvert.DeserializeObject<ComConfig[]>(reader.ReadToEnd());
            return config;
        }
    }
}