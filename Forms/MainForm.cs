using AtlusScriptGUI;
using MetroSet_UI.Forms;
using ShrineFox.IO;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AtlusScriptGUI
{
    public partial class MainForm : MetroSetForm
    {
        public static Version version = new Version(3, 0);
        public static string CompilerPath = "AtlusScriptCompiler.exe";

        public MainForm(string[] args)
        {
            InitializeComponent();
            Theme.ApplyToForm(this);
            //MenuStripHelper.SetMenuStripIcons(MenuStripHelper.GetMenuStripIconPairs("Icons.txt"), this);
            SetCompilerPath(args);
            SetGamesDropDown();
            SetLogging();
            
            this.Text += $" v{version.Major}.{version.Minor}";
        }

        private void SetLogging()
        {
            Output.Logging = true;
            Output.LogControl = rtb_Log;
        }

        private void SetCompilerPath(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
                CompilerPath = args[0];
        }

        private void SetGamesDropDown()
        {
            foreach (var game in GamesList)
                comboBox_Game.Items.Add(game);

            comboBox_Game.SelectedIndex = 10;
            if (File.Exists("Game.txt"))
                try { comboBox_Game.SelectedIndex = GamesList.IndexOf(File.ReadAllLines("Game.txt")[0]); } catch { }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool decompile = btn.Name.Contains("Decompile");

            string browseWindowTitle = "Choose .MSG/.FLOW to Compile";
            if (decompile)
                browseWindowTitle = "Choose .BMD/.BF to Decompile";

            var files = WinFormsDialogs.SelectFile(browseWindowTitle, true);
            new Thread(() =>
            {
                Compile(files.ToArray(), decompile);
            }).Start();
        }

        private void Btn_DragDrop(object sender, DragEventArgs e)
        {
            var btn = (Button)sender;

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            new Thread(() =>
            {
                if (File.Exists(CompilerPath))
                    Compile(fileList, btn.Name.Contains("Decompile"));
                else
                    MessageBox.Show("Could not find AtlusScriptCompiler.exe. " +
                        "Put this program in the same folder and try running it again!",
                        "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }).Start();
            
        }

        private void Btn_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void OpenLog_Click(object sender, EventArgs e)
        {
            OpenLog();
        }

        private void Game_Changed(object sender, EventArgs e)
        {
            if (comboBox_Game.SelectedIndex != 0)
                File.WriteAllText("Game.txt", comboBox_Game.SelectedItem.ToString());
        }

        private void VanillaText_Changed(object sender, EventArgs e)
        {
            try
            {
                string result = ConvertVanillaFlag(txtBox_Vanilla.Text);
                if (result != "-1")
                    txtBox_Royal.Text = result;
                else
                    txtBox_Royal.Text = txtBox_Vanilla.Text;
            }
            catch
            {
                txtBox_Royal.Text = "Out of Range";
            }
        }

        private void RoyalText_Changed(object sender, EventArgs e)
        {
            try
            {
                string result = ConvertRoyalFlag(txtBox_Royal.Text);
                if (result != "-1")
                    txtBox_Vanilla.Text = result;
                else
                    txtBox_Vanilla.Text = txtBox_Royal.Text;
            }
            catch
            {
                txtBox_Vanilla.Text = "Out of Range";
            }
        }
    }
}
