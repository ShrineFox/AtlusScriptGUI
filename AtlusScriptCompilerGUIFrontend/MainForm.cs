using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlusScriptCompilerGUIFrontend
{
    public partial class MainForm : Form
    {
        public string compileArg = "";
        public string encodingArg = "";
        public string libraryArg = "";
        public string outFormatArg = "";
        
        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            comboGame.DataSource = gamesDropdown;
            comboGame.SelectedIndex = 3;

            

        }

        public List<string> gamesDropdown = new List<string>()
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DecompileDragDrop(object sender, DragEventArgs e)//Rather than running the thing for each iteration, we get a list of all the args and then run them in one cmd window
        {
            if (File.Exists("AtlusScriptCompiler.exe")) {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                ArrayList args = new ArrayList();
                for (int i = 0; i < fileList.Count(); i++)
                {
                    string ext = Path.GetExtension(fileList[i]).ToUpper();
                    if (ext == ".BMD" || ext == ".BF")
                    {
                        compileArg = "-Decompile";
                        args.Add(GetArgument(fileList[i], ext));
                    }
                }
                RunCMD(args);
            }
            else
            {
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. Put this program in the same folder and try running it again!", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CompileDragDrop(object sender, DragEventArgs e)
        {

            if (File.Exists("AtlusScriptCompiler.exe"))
            {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                ArrayList args = new ArrayList();
                ArrayList input = new ArrayList();
                for (int i = 0; i < fileList.Count(); i++)
                {
                    string ext = Path.GetExtension(fileList[i]).ToUpper();
                    if (ext == ".MSG" || ext == ".FLOW")
                    {
                        input.Add(fileList[i]);
                        compileArg = "-Compile";
                        args.Add(GetArgument(fileList[i], ext));
                    }
                }
                RunCMD(args);
                if (chk_Overwrite.Checked)
                {
                    for (int i = 0; i < args.Count; i++)
                    {
                        String created = fileList[i] + ".bf";

                        
                        String renamed = (string)fileList[i];
                        renamed = renamed.Replace(".msg", "");
                        renamed = renamed.Replace(".MSG", "");
                        renamed = renamed.Replace(".FLOW", "");
                        renamed = renamed.Replace(".flow", "");
                        renamed = renamed.Replace(".BF", "");
                        renamed = renamed.Replace(".bf", "");
                        renamed += ".bf";

                        if (System.IO.File.Exists(renamed)) { System.IO.File.Delete(renamed); }
                        System.IO.File.Move(created, renamed);
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not find AtlusScriptCompiler.exe. Put this program in the same folder and try running it again!", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        public string GetArgument(string droppedFilePath, string extension)
        {
             
                switch (comboGame.SelectedIndex)
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
                            outFormatArg = "-OutFormat V1";
                        break;

                    
            }

                StringBuilder args = new StringBuilder();
                args.Append("AtlusScriptCompiler.exe ");
                args.Append($"\"{droppedFilePath}\" ");
                if (chk_Disassemble.Checked)//Omits all args if you are disassembling
                {
                    args.Append($" -Disassemble");
                }
                else
                {
                    args.Append($"{compileArg} ");
                    args.Append($"{outFormatArg} ");
                    args.Append($"{libraryArg} ");
                    args.Append($"{encodingArg} ");

                    if (chk_Hook.Checked)
                        args.Append($" -Hook");
                }
                

                //RunCMD(args.ToString());
                droppedFilePath = "";
                compileArg = "";
                outFormatArg = "";
                libraryArg = "";
                encodingArg = "";
                return args.ToString();

            
            
        }//Used to be get compiler

        private void RunCMD(ArrayList args)//Now runs a list of args, rather than running individually
        {
            ProcessStartInfo start = new ProcessStartInfo();

            start.FileName = "cmd";
            start.UseShellExecute = true;
            start.RedirectStandardOutput = false;

            //Creates a long argument string, putting && tells cmd to run the command multiple times
            StringBuilder cmdInput = new StringBuilder();
            cmdInput.Append($"/C {args[0]} && ");
            for (int i = 1; i < args.Count-1; i++)
            {
                cmdInput.Append($"{args[i]} && ");
            }
            cmdInput.Append(args[args.Count - 1]);
            if (chk_Overwrite.Checked)
            {
                cmdInput.Append(" && EXIT");
            }
            start.Arguments = cmdInput.ToString();


            if (!chk_Log.Checked)
                start.WindowStyle = ProcessWindowStyle.Hidden;
            else
                start.Arguments = start.Arguments.Replace("/C", "/K");

            using (Process process = Process.Start(start))
            {
                if (chk_Overwrite.Checked)
                {
                    process.WaitForExit();
                }
            }

            
        }

        private void DecompileDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void CompileDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void DecompileClick(object sender, EventArgs e)
        {

        }

        private void CompileClick(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void OpenLog(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "AtlusScriptCompiler.log";
            start.UseShellExecute = true;
            Process.Start(start);
        }
    }
}
