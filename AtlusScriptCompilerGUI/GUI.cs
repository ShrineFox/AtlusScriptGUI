using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using HtmlAgilityPack;

namespace AtlusScriptCompilerGUI
{
    public partial class GUI
    {
        public static bool Hook { get; set; }
        public static bool Disassemble { get; set; }
        public static bool Overwrite { get; set; }
        public static bool Log { get; set; }
        public static bool SumBits { get; set; }
        public static int Selection { get; set; }

        public static List<string> GamesDropdown = new List<string>()
        {
            "SMT 3 Nocturne",
            "SMT Digital Devil Saga",
            "Persona 3 Portable",
            "Persona 3",
            "Persona 3 FES",
            "Persona 4",
            "Persona 4 Golden",
            "Persona 5",
            "Persona 5 Royal",
            "Persona Q2",
        };

        [STAThread]
        public static void CheckForUpdate()
        {
            if (File.Exists("AtlusScriptCompiler.exe"))
            {
                string version = "";
                string download = "";

                // Load webpage in browser
                HtmlWeb web = new HtmlWeb();
                web.BrowserTimeout = TimeSpan.FromSeconds(0);
                var appveyorPage = web.LoadFromBrowser("https://ci.appveyor.com/project/TGEnigma/atlusscripttools/build/artifacts", o =>
                {
                    var webBrowser = (WebBrowser)o;

                    // Wait until the download url loads
                    return webBrowser.Document.Body.InnerHtml.Contains("artifact-type");
                });

                // Scrape version and download url from HTML
                version = appveyorPage.DocumentNode.SelectSingleNode("//div[@class='project-build-version ng-binding']").InnerText;
                download = appveyorPage.DocumentNode.SelectSingleNode("//a[@class='artifact-type zip']").Attributes["href"].Value;

                if (version != "" && download != "")
                {
                    // Create/Modify Update XML
                    File.WriteAllText("updates.xml", $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<item>\n\t<version>{version}.0</version>\n\t<url>{download}</url>\n\t<changelog>https://github.com/TGEnigma/Atlus-Script-Tools/commits/master</changelog>\n\t<mandatory>false</mandatory>\n</item>");

                    //Wait for XML file to exist/not be in use
                    using (WaitForFile("updates.xml", FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { };

                    // Ask to download and install update from XML data
                    AutoUpdater.RunUpdateAsAdmin = false;
                    AutoUpdater.InstalledVersion = new Version(AssemblyName.GetAssemblyName("AtlusScriptCompiler.exe").Version.ToString());
                    AutoUpdater.Start("updates.xml");
                }
            }
            else
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. " +
                    "Put this program in the same folder and try running it again!",
                    "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static FileStream WaitForFile(string fullPath, FileMode mode, FileAccess access, FileShare share)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                FileStream fs = null;
                try
                {
                    fs = new FileStream(fullPath, mode, access, share);
                    return fs;
                }
                catch (IOException)
                {
                    if (fs != null)
                    {
                        fs.Dispose();
                    }
                    Thread.Sleep(1000);
                }
            }
            return null;
        }

        public static void Compile(string[] fileList)
        {
            ArrayList args = new ArrayList();
            for (int i = 0; i < fileList.Count(); i++)
            {
                string ext = Path.GetExtension(fileList[i]).ToUpper();
                if (ext == ".MSG" || ext == ".FLOW")
                {
                    args.Add(GetArgument(fileList[i], ext, "-Compile "));
                }
            }

            RunCMD(args);
        }

        public static void Decompile(string[] fileList)
        {
            ArrayList args = new ArrayList();
            for (int i = 0; i < fileList.Count(); i++)
            {
                string ext = Path.GetExtension(fileList[i]).ToUpper();
                if (ext == ".BMD" || ext == ".BF")
                {
                    args.Add(GetArgument(fileList[i], ext, "-Decompile "));
                }
            }
            RunCMD(args);
        }

        private static string GetArgument(string droppedFilePath, string extension, string compileArg)
        {
            string encodingArg = "";
            string libraryArg = "";
            string outFormatArg = "";

            switch (Selection)
            {
                case 0: //SMT3
                    encodingArg = "-Encoding P3";
                    if (extension != ".BMD")
                        libraryArg = "-Library SMT3";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 1: //DDS
                    encodingArg = "-Encoding P3";
                    if (extension != ".BMD")
                        libraryArg = "-Library DDS";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1DDS";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V1DDS";
                    break;
                case 2: //P3P
                    encodingArg = "-Encoding P3";
                    if (extension != ".BMD")
                        libraryArg = "-Library P3P";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 3: //P3
                    encodingArg = "-Encoding P3";
                    if (extension != ".BMD")
                        libraryArg = "-Library P3";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 4: //P3FES
                    encodingArg = "-Encoding P3";
                    if (extension != ".BMD")
                        libraryArg = "-Library P3F";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 5: //P4
                    encodingArg = "-Encoding P4";
                    if (extension != ".BMD")
                        libraryArg = "-Library P4";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 6: //P4G
                    encodingArg = "-Encoding P4";
                    if (extension != ".BMD")
                        libraryArg = "-Library P4G";
                    if (extension == ".MSG" || extension == ".FLOW")
                        outFormatArg = "-OutFormat V1";
                    break;
                case 7: //P5
                    encodingArg = "-Encoding P5";
                    if (extension != ".BMD")
                        libraryArg = "-Library P5";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case 8: //P5R
                    encodingArg = "-Encoding P5";
                    if (extension != ".BMD")
                        libraryArg = "-Library P5R";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1BE";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V3BE";
                    break;
                case 9: //PQ2
                    encodingArg = "-Encoding SJ";
                    if (extension != ".BMD")
                        libraryArg = "-Library PQ2";
                    if (extension == ".MSG")
                        outFormatArg = "-OutFormat V1";
                    if (extension == ".FLOW")
                        outFormatArg = "-OutFormat V2";
                    break;
            }

            StringBuilder args = new StringBuilder();
            args.Append("/C AtlusScriptCompiler.exe ");
            args.Append($"\"{droppedFilePath}\" ");
            if (Disassemble) //Omits all args if you are disassembling
                args.Append($" -Disassemble");
            else
            {
                args.Append($"{compileArg} ");
                args.Append($"{outFormatArg} ");
                args.Append($"{libraryArg} ");
                args.Append($"{encodingArg} ");
                if (Hook)
                    args.Append(" -Hook ");
                if (SumBits)
                    args.Append(" -SumBits ");
                if (compileArg == "-Compile " && Overwrite)
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
            }

            return args.ToString();
        }

        private static void RunCMD(ArrayList args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "cmd";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;

            StringBuilder cmdInput = new StringBuilder();
            for (int i = 0; i < args.Count; i++)
            {
                if (i > 0)
                    cmdInput.Append(" && ");
                cmdInput.Append(args[i]);
            }
            if (Overwrite)
                cmdInput.Append(" && EXIT");
            start.Arguments = cmdInput.ToString();
            //Whether or not to show log while compiling
            if (!Log)
                start.WindowStyle = ProcessWindowStyle.Hidden;
            else
                start.Arguments = start.Arguments.Replace("/C", "/K");

            using (Process process = Process.Start(start))
            {
            }
        }

        public static void OpenLog()
        {
            if (File.Exists("AtlusScriptCompiler.log"))
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "AtlusScriptCompiler.log";
                start.UseShellExecute = true;
                Process.Start(start);
            }
        }
    }
}
