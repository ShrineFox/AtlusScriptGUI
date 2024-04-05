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
        public static List<string> GamesList = new List<string>()
        {
            "SMT 3 Nocturne",
            "SMT Digital Devil Saga",
            "Persona 3 Portable",
            "Persona 3",
            "Persona 3 FES",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5",
            "Persona 5 Royal (PS4)",
            "Persona 5 Royal (PC/Switch)",
            "Persona Q2",
        };

        private void ApplyCheckboxStates()
        {
            chk_DeleteHeader.Checked = settings.DeleteHeader;
            chk_Disassemble.Checked = settings.Disassemble;
            chk_Hook.Checked = settings.Hook;
            chk_Overwrite.Checked = settings.Overwrite;
            chk_SumBits.Checked = settings.SumBits;

            EnableCheckboxes();
        }

        private void EnableCheckboxes()
        {
            chk_DeleteHeader.Enabled = true;
            chk_Disassemble.Enabled = true;
            chk_Hook.Enabled = true;
            chk_Overwrite.Enabled = true;
            chk_SumBits.Enabled = true;
        }

        private void SetLogging()
        {
            Output.Logging = true;
            Output.LogControl = rtb_Log;
        }

        private void SetCompilerPath(string[] args)
        {
            if (args.Length > 0 && File.Exists(args[0]))
                CompilerPath = Path.GetFullPath(args[0]);
            else
                CompilerPath = settings.CompilerPath;

            while (!File.Exists(CompilerPath))
            {
                var fileSelect = WinFormsDialogs.SelectFile("Select your AtlusScriptCompiler.exe", false, new string[] { "Executable File (.exe)" });
                if (fileSelect.Count > 0 && File.Exists(fileSelect.First()))
                {
                    CompilerPath = fileSelect.First();
                    settings.CompilerPath = CompilerPath;
                    settings.SaveJson(settings);
                }
            }
        }

        private void SetDropDowns()
        {
            SetGameDropDown();

            SetEncodingDropDown();
        }

        private void SetGameDropDown()
        {
            foreach (var game in GamesList)
                comboBox_Game.Items.Add(game);

            comboBox_Game.SelectedIndex = comboBox_Game.Items.IndexOf(settings.Game);
        }

        private void SetEncodingDropDown()
        {
            comboBox_Encoding.Enabled = false;
            comboBox_Encoding.Items.Clear();

            // Hide encoding options and display text saying default option will be used
            comboBox_Encoding.Visible = false;
            defaultEncodingToolStripMenuItem.Visible = true;

            // Show encoding dropdown if there are optional encodings, select commonly used default
            switch (settings.Game)
            {
                case "Persona 3 Portable":
                    foreach (var encoding in new string[] { "P3", "P3P_EFIGS" })
                        comboBox_Encoding.Items.Add(encoding);
                    comboBox_Encoding.SelectedIndex = 0;
                    comboBox_Encoding.Visible = true;
                    defaultEncodingToolStripMenuItem.Visible = false;
                    break;
                case "Persona 5":
                    // Populate comboBox options with all available AtlusEncodings
                    foreach (var encoding in new string[] { "P5", "P5_Chinese" })
                        comboBox_Encoding.Items.Add(encoding);
                    comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf("P5");
                    comboBox_Encoding.Visible = true;
                    defaultEncodingToolStripMenuItem.Visible = false;
                    break;
                case "Persona 5 Royal (PS4)":
                    foreach (var encoding in new string[] { "P5", "P5_Chinese" })
                        comboBox_Encoding.Items.Add(encoding);
                    comboBox_Encoding.SelectedIndex = 0;
                    comboBox_Encoding.Visible = true;
                    defaultEncodingToolStripMenuItem.Visible = false;
                    break;
                case "Persona 5 Royal (PC/Switch)":
                    // Populate comboBox options with all available AtlusEncodings
                    foreach (var encoding in new string[] { "P5R_EFIGS", "P5R_Japanese", "P5R_Chinese" })
                        comboBox_Encoding.Items.Add(encoding);
                    comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf("P5R_EFIGS");
                    comboBox_Encoding.Visible = true;
                    defaultEncodingToolStripMenuItem.Visible = false;
                    break;
                default:
                    comboBox_Encoding.Items.Add("P3");
                    comboBox_Encoding.SelectedIndex = 0;
                    break;
            }

            // Select previous setting if it's still in the list
            foreach (var item in comboBox_Encoding.Items)
                if (item.ToString() == settings.Encoding)
                    comboBox_Encoding.SelectedIndex = comboBox_Encoding.Items.IndexOf(item);

            comboBox_Encoding.Enabled = true;

            // Save selected encoding to config
            settings.Encoding = comboBox_Encoding.SelectedItem.ToString();
            settings.SaveJson(settings);
        }

        public void Compile(string[] fileList, bool decompile = false)
        {
            rtb_Log.Clear();
            new Thread(() =>
            {
                string args = "";
                for (int i = 0; i < fileList.Count(); i++)
                {
                    string ext = Path.GetExtension(fileList[i]).ToUpper();

                    if (!decompile && (ext == ".MSG" || ext == ".FLOW"))
                        args = GetArguments(fileList[i], ext, "-Compile ");
                    else if (decompile && ext == ".BMD" || ext == ".BF")
                        args = GetArguments(fileList[i], ext, "-Decompile ");
                    else
                        return;
                        Exe.Run(Path.GetFullPath(CompilerPath), args, redirectStdOut: true);
                }
                DeleteHeaderFiles(fileList);
            }).Start();
        }

        private void DeleteHeaderFiles(string[] fileList)
        {
            foreach (var file in fileList)
            {
                if (chk_DeleteHeader.Checked && Path.GetExtension(file).ToUpper() == ".BMD")
                {
                    string headerFile = file + ".msg.h";
                    if (chk_Overwrite.Checked)
                        headerFile = FileSys.GetExtensionlessPath(file) + ".msg.h";

                    if (File.Exists(headerFile))
                        File.Delete(headerFile);
                }
            }
        }

        private string GetArguments(string droppedFilePath, string extension, string compileArg)
        {
            string encodingArg = "";
            string libraryArg = "";
            string outFormatArg = "";

            encodingArg = $"-Encoding {settings.Encoding}";

            switch (settings.Game)
            {
                case "SMT 3 Nocturne":
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library SMT3";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "SMT Digital Devil Saga":
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library DDS";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1DDS";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1DDS";
                    break;
                case "Persona 3 Portable":
                    //encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3P";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "Persona 3":
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "Persona 3 FES":
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3F";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "Persona 4":
                    encodingArg = "-Encoding P4";
                    libraryArg = "-Library P4";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "Persona 4 Golden":
                    encodingArg = "-Encoding P4";
                    libraryArg = "-Library P4G";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case "Persona 5":
                    //encodingArg = "-Encoding P5";
                    libraryArg = "-Library P5";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case "Persona 5 Royal (PS4)":
                    //encodingArg = "-Encoding P5";
                    libraryArg = "-Library P5R";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case "Persona 5 Royal (PC/Switch)":
                    //encodingArg = "-Encoding P5R_EFIGS";
                    //if (extension != ".BMD")
                        libraryArg = "-Library P5R";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case "Persona Q2":
                    encodingArg = "-Encoding SJ";
                    libraryArg = "-Library PQ2";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V2";
                    break;
                default:
                    break;
            }

            StringBuilder args = new StringBuilder();
            args.Append($"\"{droppedFilePath}\" ");
            if (settings.Disassemble) //Omits all args if you are disassembling
                args.Append($" -Disassemble");
            else
            {
                args.Append($"{compileArg} ");
                args.Append($"{outFormatArg} ");
                args.Append($"{libraryArg} ");
                args.Append($"{encodingArg} ");
                if (settings.Hook)
                    args.Append(" -Hook ");
                if (settings.SumBits)
                    args.Append(" -SumBits ");
                if (compileArg == "-Compile " && settings.Overwrite)
                {
                    string outPath = droppedFilePath.Replace(".flow", "")
                        .Replace(".FLOW", "").Replace(".msg", "").Replace(".MSG", "")
                        .Replace(".bf", "").Replace(".BF", "").Replace(".bmd", "")
                        .Replace(".BMD", "");
                    if (extension == ".MSG")
                        args.Append($"-Out \"{outPath + ".bmd"}\" ");
                    else if (extension == ".FLOW")
                        args.Append($"-Out \"{outPath + ".bf"}\" ");
                }
                else if (compileArg == "-Decompile " && settings.Overwrite)
                {
                    string outPath = droppedFilePath.Replace(".bmd", "").Replace(".BMD", "");
                    if (extension == ".BF")
                        args.Append($"-Out \"{outPath + ".flow"}\" ");
                    else if (extension == ".BMD")
                        args.Append($"-Out \"{outPath + ".msg"}\" ");
                }
            }

            Output.Log(args.ToString(), ConsoleColor.Green);
            return args.ToString();
        }

        public static string ConvertRoyalFlag(string text)
        {
            return Flag.ConvertToVanilla(Convert.ToInt32(text)).ToString();
        }

        public static string ConvertVanillaFlag(string text)
        {
            return Flag.ConvertToRoyal(Convert.ToInt32(text)).ToString();
        }

        public void OpenLog()
        {
            string logPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(CompilerPath)), "AtlusScriptCompiler.log");
            if (File.Exists(logPath))
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = logPath;
                start.UseShellExecute = true;
                Process.Start(start);
            }
        }

        private void ToggleTheme()
        {
            if (Theme.ThemeStyle == MetroSet_UI.Enums.Style.Light)
            {
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Dark;
                settings.DarkMode = true;
            }
            else
            {
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Light;
                settings.DarkMode = false;
            }
            settings.SaveJson(settings);
        }

        private void ApplyTheme()
        {
            Theme.ApplyToForm(this);
        }
    }
}
