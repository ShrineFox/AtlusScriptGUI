using MetroSet_UI.Forms;
using ShrineFox.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlusScriptGUI
{
    public partial class MainForm : MetroSetForm
    {
        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool decompile = btn.Name.Contains("Decompile");

            string browseWindowTitle = "Choose .MSG/.FLOW to Compile";
            if (decompile)
                browseWindowTitle = "Choose .BMD/.BF to Decompile";

            var files = WinFormsDialogs.SelectFile(browseWindowTitle, true);
            Compile(files.ToArray(), decompile);
        }

        private void Btn_DragDrop(object sender, DragEventArgs e)
        {
            var btn = (Button)sender;

            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (File.Exists(settings.CompilerPath))
                Compile(fileList, btn.Name.Contains("Decompile"));
            else
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. " +
                    "Put this program in the same folder and try running it again!",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            settings.Game = comboBox_Game.SelectedItem.ToString();
            settings.SaveJson(settings);

            SetEncodingDropDown();
        }

        private void Encoding_Changed(object sender, EventArgs e)
        {
            if (!comboBox_Encoding.Enabled)
                return;

            settings.Encoding = comboBox_Encoding.SelectedItem.ToString();
            settings.SaveJson(settings);
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

        private void Check_Changed(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            if (!item.Enabled)
                return;

            settings.DeleteHeader = chk_DeleteHeader.Checked;
            settings.Disassemble = chk_Disassemble.Checked;
            settings.Hook = chk_Hook.Checked;
            settings.Overwrite = chk_Overwrite.Checked;
            settings.SumBits = chk_SumBits.Checked;

            settings.SaveJson(settings);
        }

        private void ToggleTheme_Click(object sender, EventArgs e)
        {
            ToggleTheme();
            ApplyTheme();
        }
    }
}
