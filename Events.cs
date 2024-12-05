using AtlusScriptLibrary.Common.Libraries;
using AtlusScriptLibrary.Common.Logging;
using AtlusScriptLibrary.Common.Text.Encodings;
using AtlusScriptLibrary.FlowScriptLanguage;
using AtlusScriptLibrary.MessageScriptLanguage.Compiler;
using AtlusScriptLibrary.MessageScriptLanguage;
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

            if (!File.Exists(settings.CompilerPath))
                SetCompilerPath();

            if (File.Exists(settings.CompilerPath))
                Compile(fileList, btn.Name.Contains("Decompile"));
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
            settings.BigEndianFlow = chk_BigEndianFlowP3RE.Checked;

            settings.SaveJson(settings);
        }

        private void ToggleTheme_Click(object sender, EventArgs e)
        {
            ToggleTheme();
            ApplyTheme();
        }

        private void InjectMSG_Click(object sender, EventArgs e)
        {
            if (!File.Exists(settings.CompilerPath) && !SetCompilerPath())
                return;

            string bfPath = "";
            string msgPath = "";
            var bfSelect = ShrineFox.IO.WinFormsDialogs.SelectFile("Choose Original BF File", false, new string[] { "Flowscript Binary (.BF)" });
            if (bfSelect.Count <= 0 || string.IsNullOrEmpty(bfSelect.First()))
                return;
            else
                bfPath = bfSelect.FirstOrDefault();
            var msgSelect = ShrineFox.IO.WinFormsDialogs.SelectFile("Choose File To Inject", false, new string[] { "Messagescript Text (.MSG)", "Messagescript Binary (.BMD)" });
            if (msgSelect.Count <= 0 || string.IsNullOrEmpty(msgSelect.First()))
                return;
            else
                msgPath = msgSelect.FirstOrDefault();

            FlowScript flowScript = FlowScript.FromFile(bfPath, GetSelectedEncoding());
            MessageScript messageScript;

            if (Path.GetExtension(msgPath).ToLower() == ".bmd")
                messageScript = MessageScript.FromFile(msgPath, AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1BigEndian, GetSelectedEncoding());
            else
                using (FileStream fileStream = File.OpenRead(msgPath))
                {
                    MessageScriptCompiler messageScriptCompiler = new MessageScriptCompiler(
                        AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1BigEndian, GetSelectedEncoding());
                    messageScriptCompiler.AddListener(new ConsoleLogListener(true, LogLevel.Info | LogLevel.Warning
                        | LogLevel.Error | LogLevel.Fatal));
                    messageScriptCompiler.Library = LibraryLookup.GetLibrary("P5R");
                    if (!messageScriptCompiler.TryCompile(fileStream, out messageScript))
                        return;
                }
            flowScript.MessageScript = messageScript;
            flowScript.ToFile(bfPath);
            MessageBox.Show("Done injecting message into .BF!");
        }

        private void SetScriptCompilerPath_Click(object sender, EventArgs e)
        {
            SetCompilerPath();
        }

        private Encoding GetSelectedEncoding()
        {
            return AtlusEncoding.GetEncodings().First(x => x.Name.Equals(comboBox_Encoding.SelectedItem.ToString())).GetEncoding();
        }
    }
}
