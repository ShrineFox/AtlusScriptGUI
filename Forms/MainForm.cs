using AtlusScriptGUI;
using MetroSet_UI.Forms;
using ShrineFox.IO;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AtlusScriptGUI
{
    public partial class MainForm : MetroSetForm
    {
        public static Version version = new Version(3, 1);
        public Config settings = new Config();
        public string CompilerPath { get; set; } = "./AtlusScriptCompiler.exe";

        public MainForm(string[] args)
        {
            InitializeComponent();
            settings = settings.LoadJson();
            if (!settings.DarkMode)
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Light;
            Theme.ApplyToForm(this);
            MenuStripHelper.SetMenuStripIcons(MenuStripHelper.GetMenuStripIconPairs("Icons.txt"), this);

            ApplyCheckboxStates();
            SetCompilerPath(args);
            SetDropDowns();
            SetLogging();
            
            this.Text += $" v{version.Major}.{version.Minor}";
        }
    }
}
