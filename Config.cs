﻿using Newtonsoft.Json;
using ShrineFox.IO;
using System.IO;

namespace AtlusScriptGUI
{
    public class Config
    {
        public string Game { get; set; } = "Persona 5 Royal (PC/Switch)";
        public string Encoding { get; set; } = "P5R_EFIGS";
        public bool DarkMode { get; set; } = true;
        public bool Hook { get; set; } = true;
        public bool Disassemble { get; set; } = false;
        public bool Overwrite { get; set; } = false;
        public bool SumBits { get; set; } = true;
        public bool DeleteHeader { get; set; } = false;
        public bool BigEndianFlow { get; set; } = true;
        public bool CompilerLogOutput { get; set; } = true;

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
