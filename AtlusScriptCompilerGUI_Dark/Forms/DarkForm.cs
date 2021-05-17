using AtlusScriptCompilerGUI;
using DarkUI.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AtlusScriptCompilerGUIFrontend
{
    public partial class MainForm : DarkForm
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            comboGame.DataSource = GUI.GamesDropdown;
            if (File.Exists("Game.txt"))
                try { comboGame.SelectedIndex = GUI.GamesDropdown.IndexOf(File.ReadAllLines("Game.txt")[0]); } catch { }
            //GUI.CheckForUpdate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DecompileDragDrop(object sender, DragEventArgs e)
        {
            GUI.Hook = chk_Hook.Checked;
            GUI.Log = chk_Log.Checked;
            GUI.Disassemble = chk_Disassemble.Checked;
            GUI.Selection = comboGame.SelectedIndex;
            GUI.SumBits = chk_SumBits.Checked;

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists("AtlusScriptCompiler.exe"))
                GUI.Decompile(fileList);
            else
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. " +
                    "Put this program in the same folder and try running it again!",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CompileDragDrop(object sender, DragEventArgs e)
        {
            GUI.Hook = chk_Hook.Checked;
            GUI.Log = chk_Log.Checked;
            GUI.Disassemble = chk_Disassemble.Checked;
            GUI.Selection = comboGame.SelectedIndex;
            GUI.Overwrite = chk_Overwrite.Checked;
            GUI.SumBits = chk_SumBits.Checked;

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists("AtlusScriptCompiler.exe"))
                GUI.Compile(fileList);
            else
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. " +
                    "Put this program in the same folder and try running it again!",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DecompileDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void CompileDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void OpenLog_Click(object sender, EventArgs e)
        {
            GUI.OpenLog();
        }

        private void Game_Changed(object sender, EventArgs e)
        {
            if (comboGame.SelectedIndex != 0)
                File.WriteAllText("Game.txt", comboGame.SelectedItem.ToString());
        }
    }
}
