using MetroSet_UI.Forms;
using ShrineFox.IO;
using System;
using System.IO;

namespace AtlusScriptGUI
{
    public partial class MainForm : MetroSetForm
    {
        public static Version version = new Version(3, 5, 0);
        public Config settings = new Config();

        public MainForm(string[] args)
        {
            InitializeComponent();
            settings = settings.LoadJson();
            if (!settings.DarkMode)
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Light;
            Theme.ApplyToForm(this);
            MenuStripHelper.SetMenuStripIcons(MenuStripHelper.GetMenuStripIconPairs("Icons.txt"), this);

            ApplyCheckboxStates();
            SetDropDowns();
            SetLogging();
            
            this.Text += $" v{version.Major}.{version.Minor}.{version.Build}";

            string versionTxtPath = Path.Combine(Exe.Directory(), "Version.txt");
            if (File.Exists(versionTxtPath))
            {
                var lines = File.ReadAllLines(versionTxtPath);
                if (lines.Length > 2)
                    Output.Log($"AtlusScriptCompiler built from commit \"{lines[0].Replace("v1.0-","")}\"" +
                        $"\nBuild Date: {lines[1]}", ConsoleColor.Green);
            } 
        }
    }
}
