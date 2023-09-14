using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlusScriptGUI
{
    public class Config
    {
        public string Game { get; set; } = "Persona 5 Royal (EFIGS)";
        public string CompilerPath { get; set; } = "./AtlusScriptCompiler.exe";
        public bool DarkMode { get; set; } = true;
        public bool Hook { get; set; } = true;
        public bool Disassemble { get; set; } = false;
        public bool Overwrite { get; set; } = false;
        public bool SumBits { get; set; } = true;
        public bool DeleteHeader { get; set; } = false;

        public void SaveJson(Config settings)
        {
            File.WriteAllText("Config.json", JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented));
        }

        public Config LoadJson()
        {
            if (!File.Exists("Config.json"))
                return new Config();

            return JsonConvert.DeserializeObject<Config>(File.ReadAllText("Config.json"));
        }
    }
}
