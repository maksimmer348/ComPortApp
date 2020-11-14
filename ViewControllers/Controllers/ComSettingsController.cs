using System.IO;
using ComPortSettings.MVC;

namespace ComPortSettings
{
    public class ComSettingsController : Controller<ComSettings>
    {
        
        public ComSettingsController(ComSettings view) : base(view)
        {
        }

        protected override void OnShown()
        {
            var serializer = new ComConfigsSerializer();
            if (File.Exists("Settings.json"))
            {
                serializer.Serialize(File.OpenWrite("Settings.json"), ComConfig.Default);
            }


            var ss = serializer.Deserialize(File.OpenRead("Settings.json"));
        }
    }
}