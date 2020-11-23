using System.Collections.Generic;
using System.ComponentModel;

namespace ComPortSettings.ComPort
{
    public class CommandLib
    {
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

            return $"{Commands[key]} {param}";
        }
    }
}