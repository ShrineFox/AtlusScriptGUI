using DarkUI.Collections;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using DarkUI.Renderers;

namespace AtlusScriptCompilerGUIFrontend
{
    partial class MainForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCompile = new DarkUI.Controls.DarkButton();
            this.btnDecompile = new DarkUI.Controls.DarkButton();
            this.comboGame = new DarkUI.Controls.DarkComboBox();
            this.labelGame = new DarkUI.Controls.DarkLabel();
            this.chk_Hook = new DarkUI.Controls.DarkCheckBox();
            this.chk_Log = new DarkUI.Controls.DarkCheckBox();
            this.chk_Disassemble = new DarkUI.Controls.DarkCheckBox();
            this.btnOpenLog = new DarkUI.Controls.DarkButton();
            this.chk_Overwrite = new DarkUI.Controls.DarkCheckBox();
            this.tpOverwrite = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.AllowDrop = true;
            this.btnCompile.Location = new System.Drawing.Point(12, 57);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Padding = new System.Windows.Forms.Padding(5);
            this.btnCompile.Size = new System.Drawing.Size(180, 185);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Drag a BF or BMD here to Decompile";
            this.btnCompile.Click += new System.EventHandler(this.DecompileClick);
            this.btnCompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.DecompileDragDrop);
            this.btnCompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.DecompileDragEnter);
            // 
            // btnDecompile
            // 
            this.btnDecompile.AllowDrop = true;
            this.btnDecompile.Location = new System.Drawing.Point(199, 57);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Padding = new System.Windows.Forms.Padding(5);
            this.btnDecompile.Size = new System.Drawing.Size(180, 185);
            this.btnDecompile.TabIndex = 1;
            this.btnDecompile.Text = "Drag a Flowscript or Messagescript here to Compile";
            this.btnDecompile.Click += new System.EventHandler(this.CompileClick);
            this.btnDecompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.CompileDragDrop);
            this.btnDecompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.CompileDragEnter);
            // 
            // comboGame
            // 
            this.comboGame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboGame.DropDownHeight = 500;
            this.comboGame.FormattingEnabled = true;
            this.comboGame.IntegralHeight = false;
            this.comboGame.Location = new System.Drawing.Point(71, 5);
            this.comboGame.MaxDropDownItems = 3;
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(121, 21);
            this.comboGame.TabIndex = 2;
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelGame.Location = new System.Drawing.Point(27, 8);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(38, 13);
            this.labelGame.TabIndex = 3;
            this.labelGame.Text = "Game:";
            // 
            // chk_Hook
            // 
            this.chk_Hook.AutoSize = true;
            this.chk_Hook.Checked = true;
            this.chk_Hook.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Hook.Location = new System.Drawing.Point(199, 4);
            this.chk_Hook.Name = "chk_Hook";
            this.chk_Hook.Size = new System.Drawing.Size(102, 17);
            this.chk_Hook.TabIndex = 4;
            this.chk_Hook.Text = "Enable Hooking";
            // 
            // chk_Log
            // 
            this.chk_Log.AutoSize = true;
            this.chk_Log.Checked = true;
            this.chk_Log.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Log.Location = new System.Drawing.Point(302, 4);
            this.chk_Log.Name = "chk_Log";
            this.chk_Log.Size = new System.Drawing.Size(74, 17);
            this.chk_Log.TabIndex = 5;
            this.chk_Log.Text = "Show Log";
            // 
            // chk_Disassemble
            // 
            this.chk_Disassemble.AutoSize = true;
            this.chk_Disassemble.Location = new System.Drawing.Point(199, 28);
            this.chk_Disassemble.Name = "chk_Disassemble";
            this.chk_Disassemble.Size = new System.Drawing.Size(85, 17);
            this.chk_Disassemble.TabIndex = 6;
            this.chk_Disassemble.Text = "Disassemble";
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(71, 28);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Padding = new System.Windows.Forms.Padding(5);
            this.btnOpenLog.Size = new System.Drawing.Size(121, 23);
            this.btnOpenLog.TabIndex = 7;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.Click += new System.EventHandler(this.OpenLog);
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.AutoSize = true;
            this.chk_Overwrite.Location = new System.Drawing.Point(302, 28);
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(71, 17);
            this.chk_Overwrite.TabIndex = 8;
            this.chk_Overwrite.Text = "Overwrite";
            this.tpOverwrite.SetToolTip(this.chk_Overwrite, "Removes excess extension names when compiling, replacing if neccesary. Will close" +
        " the log.");
            // 
            // tpOverwrite
            // 
            this.tpOverwrite.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tpOverwrite.ToolTipTitle = "Info";
            this.tpOverwrite.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 249);
            this.Controls.Add(this.chk_Overwrite);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.chk_Disassemble);
            this.Controls.Add(this.chk_Log);
            this.Controls.Add(this.chk_Hook);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnDecompile);
            this.Controls.Add(this.btnCompile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(407, 288);
            this.MinimumSize = new System.Drawing.Size(407, 288);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptCompiler GUI Frontend 2.0 (Dark Mode)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkButton btnCompile;
        public System.Windows.Forms.ToolTip tpOverwrite;
        private DarkButton btnDecompile;
        private DarkComboBox comboGame;
        private DarkLabel labelGame;
        private DarkCheckBox chk_Hook;
        private DarkCheckBox chk_Log;
        private DarkCheckBox chk_Disassemble;
        private DarkCheckBox chk_Overwrite;
        public DarkButton btnOpenLog;
    }
}

