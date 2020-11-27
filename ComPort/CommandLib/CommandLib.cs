using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ComPortSettings.ComPort
{
    public class CommandLib
    {
        //todo сделать в класс или стурктуру 
        public Dictionary<string,string> Commands = new Dictionary<string, string>();

        
        public CommandLib()
        {
            CreateCommands();
        }

        public virtual void CreateCommands()
        {
            
        }

        public void Add(string key, string value)
        {
            Commands.Add(key, value);
        }

        public string GetCommand(string key, string param = null)
        {
            //return await Service<ComPorts>.Get().Supply.Write($"{Commands[key]} {param}");
            return $"{Commands[key]} {param}";
        }
    }
}