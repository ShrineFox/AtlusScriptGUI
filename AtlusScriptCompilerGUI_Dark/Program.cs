using AtlusScriptCompilerGUIFrontend;
using System;
using System.Windows.Forms;

namespace AtlusScriptCompilerGUIFrontendDarkMode
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
