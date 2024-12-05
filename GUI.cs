using MetroSet_UI.Forms;
using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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
            "Persona 3 Reload",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5",
            "Persona 5 Royal (PS4)",
            "Persona 5 Royal (PC/Switch)",
            "Persona Q2",
            "Catherine Classic",
            "Catherine Full-Body",
        };

        private void ApplyCheckboxStates()
        {
            chk_DeleteHeader.Checked = settings.DeleteHeader;
            chk_Disassemble.Checked = settings.Disassemble;
            chk_Hook.Checked = settings.Hook;
            chk_Overwrite.Checked = settings.Overwrite;
            chk_SumBits.Checked = settings.SumBits;
            chk_BigEndianFlowP3RE.Checked = settings.BigEndianFlow;

            EnableCheckboxes();
        }

        private void EnableCheckboxes()
        {
            chk_DeleteHeader.Enabled = true;
            chk_Disassemble.Enabled = true;
            chk_Hook.Enabled = true;
            chk_Overwrite.Enabled = true;
            chk_SumBits.Enabled = true;
            chk_BigEndianFlowP3RE.Enabled = true;
        }

        private void SetLogging()
        {
            Output.Logging = true;
            Output.LogControl = rtb_Log;
        }

        private bool SetCompilerPath()
        {
            var fileSelect = WinFormsDialogs.SelectFile("Select your AtlusScriptCompiler.exe", false, new string[] { "Executable File (.exe)" });
            if (fileSelect.Count > 0 && File.Exists(fileSelect.First()))
            {
                settings.CompilerPath = fileSelect.First();
                settings.SaveJson(settings);
                return true;
            }
            return false;
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
                    else if (decompile && (ext == ".BMD" || ext == ".BF" || ext == ".UASSET"))
                        args = GetArguments(fileList[i], ext, "-Decompile ");
                    else
                        return;

                    bool success = Exe.Run(Path.GetFullPath(settings.CompilerPath), args, redirectStdOut: true);
                    if (success)
                    {
                        ProcessUassetOutput(fileList[i], decompile);
                        DeleteHeaderFiles(fileList[i]);
                    }
                }
            }).Start();
        }

        private void ProcessUassetOutput(string file, bool decompile)
        {
            if (settings.Game != "Persona 3 Reload" || !settings.Overwrite)
                return;

            if (decompile && Path.GetExtension(file).ToUpper() == ".UASSET")
            {
                string bfFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + "_unwrapped.bf");
                string bmdFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + "_unwrapped.bmd");
                string flowFile = bfFile + ".flow";
                string msgFile = bmdFile + ".msg";
                string newFlowDest = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".flow");
                string newMsgDest = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".msg");
                string hFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + "_unwrapped.bmd.msg.h");
                string newHFileDest = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".msg.h");

                if (File.Exists(bfFile))
                    File.Delete(bfFile);
                if (File.Exists(bmdFile))
                    File.Delete(bmdFile);

                if (File.Exists(newFlowDest))
                    File.Delete(newFlowDest);
                if (File.Exists(newMsgDest))
                    File.Delete(newMsgDest);
                if (File.Exists(newHFileDest))
                    File.Delete(newHFileDest);

                if (File.Exists(flowFile))
                    File.Move(flowFile, newFlowDest);
                if (File.Exists(msgFile))
                    File.Move(msgFile, newMsgDest);
                if (File.Exists(hFile))
                    File.Move(hFile, newHFileDest);
            }
            else
            {
                string extension = ".bf";
                if (Path.GetFileName(file).ToLower().Contains("bmd"))
                    extension = ".bmd";

                string scriptFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + extension);
                string uassetFile = scriptFile + ".uasset";
                string newUassetDest = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".uasset");

                if (File.Exists(scriptFile))
                    File.Delete(scriptFile);

                if (File.Exists(newUassetDest))
                    File.Delete(newUassetDest);

                if (File.Exists(uassetFile))
                    File.Move(uassetFile, newUassetDest);
            }
        }

        private void DeleteHeaderFiles(string file)
        {
            if (!settings.DeleteHeader)
                return;

            if (Path.GetExtension(file).ToUpper() == ".BMD")
            {
                string headerFile = file + ".msg.h";
                if (settings.Overwrite)
                    headerFile = FileSys.GetExtensionlessPath(file) + ".msg.h";

                if (File.Exists(headerFile))
                    File.Delete(headerFile);
            }
            else if (Path.GetExtension(file).ToUpper() == ".UASSET" && Path.GetFileName(file).ToLower().Contains("bmd"))
            {
                string headerFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + "_unwrapped.bmd.msg.h");
                if (settings.Overwrite)
                    headerFile = FileSys.GetExtensionlessPath(file) + ".msg.h";

                if (File.Exists(headerFile))
                    File.Delete(headerFile);
            }
        }

        private string GetArguments(string inputFile, string extension, string compileArg)
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
                case "Persona 3 Reload":
                    encodingArg = "-Encoding UT";
                    libraryArg = "-Library P3RE";
                    // OutFormat
                    if (extension == ".MSG" || extension == ".FLOW")
                    {
                        if (extension == ".MSG")
                            outFormatArg = "-OutFormat V1RE";
                        else if (extension == ".FLOW")
                        {
                            if (settings.BigEndianFlow)
                                outFormatArg = "-OutFormat V4BE";
                            else
                                outFormatArg = "-OutFormat V4";
                        }
                    }
                    else if (Path.GetFileName(inputFile).ToLowerInvariant().Contains("bmd"))
                        outFormatArg = "-InFormat MessageScriptBinary -OutFormat V1RE";
                    else if (Path.GetFileName(inputFile).ToLowerInvariant().Contains("bf"))
                        outFormatArg = "-InFormat FlowScriptBinary";
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
                case "Catherine Classic":
                    encodingArg = "-Enconding CAT";
                    libraryArg = "-Library CAT";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V2BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V2BE";
                    break;
                case "Catherine Full-Body":
                    encodingArg = "-Enconding CFB";
                    libraryArg = "-Library CFB";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V2";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V2";
                    break;
                default:
                    break;
            }

            StringBuilder args = new StringBuilder();
            args.Append($"\"{inputFile}\" ");
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
                if (compileArg == "-Compile " && File.Exists(Path.ChangeExtension(inputFile, ".uasset")))
                {
                    args.Append("-UPatch \"" + Path.ChangeExtension(inputFile, ".uasset") + "\" ");
                }
                if (compileArg == "-Compile " && settings.Overwrite)
                {
                    string outPath = inputFile.Replace(".flow", "")
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
                    string outPath = inputFile.Replace(".bmd", "").Replace(".BMD", "");
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
            string logPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(settings.CompilerPath)), "AtlusScriptCompiler.log");
            if (File.Exists(logPath))
                Exe.Run(logPath);
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
