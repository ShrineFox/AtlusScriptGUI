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
            "Persona 3 Portable - EU",
            "Persona 3",
            "Persona 3 FES",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5",
            "Persona 5 Royal",
            "Persona 5 Royal (EFIGS)",
            "Persona Q2",
        };

        public void Compile(string[] fileList, bool decompile = false)
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

                Exe.Run(CompilerPath, args, redirectStdOut: true);
            }
            DeleteHeaderFiles(fileList);
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

            switch (comboBox_Game.SelectedIndex)
            {
                case 0: //SMT3
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library SMT3";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 1: //DDS
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library DDS";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1DDS";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1DDS";
                    break;
                case 2: //P3P
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3P";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 3: //P3P_EFIGS
                    encodingArg = "-Encoding P3P_EFIGS";
                    libraryArg = "-Library P3P";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 4: //P3
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 5: //P3FES
                    encodingArg = "-Encoding P3";
                    libraryArg = "-Library P3F";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 6: //P4
                    encodingArg = "-Encoding P4";
                    libraryArg = "-Library P4";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 7: //P4G
                    encodingArg = "-Encoding P4";
                    libraryArg = "-Library P4G";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 8: //P5
                    encodingArg = "-Encoding P5";
                    libraryArg = "-Library P5";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case 9: //P5R
                    encodingArg = "-Encoding P5";
                    libraryArg = "-Library P5R";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case 10: //P5R_EFIGS
                    encodingArg = "-Encoding P5R_EFIGS";
                    if (extension != ".BMD")
                        libraryArg = "-Library P5R";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE"; //V1 = Persona 5 PS4 Output
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case 11: //PQ2
                    encodingArg = "-Encoding SJ";
                    libraryArg = "-Library PQ2";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V2";
                    break;
            }

            StringBuilder args = new StringBuilder();
            args.Append($"\"{droppedFilePath}\" ");
            if (chk_Disassemble.Checked) //Omits all args if you are disassembling
                args.Append($" -Disassemble");
            else
            {
                args.Append($"{compileArg} ");
                args.Append($"{outFormatArg} ");
                args.Append($"{libraryArg} ");
                args.Append($"{encodingArg} ");
                if (chk_Hook.Checked)
                    args.Append(" -Hook ");
                if (chk_SumBits.Checked)
                    args.Append(" -SumBits ");
                if (compileArg == "-Compile " && chk_Overwrite.Checked)
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
                else if (compileArg == "-Decompile " && chk_Overwrite.Checked)
                {
                    string outPath = droppedFilePath.Replace(".bmd", "").Replace(".BMD", "");
                    args.Append($"-Out \"{outPath + ".msg"}\" ");
                }
            }

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

        public static void OpenLog()
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

        private void ToggleTheme_Click(object sender, EventArgs e)
        {
            ToggleTheme();
            ApplyTheme();
        }

        private void ToggleTheme()
        {
            if (Theme.ThemeStyle == MetroSet_UI.Enums.Style.Light)
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Dark;
            else
                Theme.ThemeStyle = MetroSet_UI.Enums.Style.Light;
        }

        private void ApplyTheme()
        {
            Theme.ApplyToForm(this);
        }
    }
}
