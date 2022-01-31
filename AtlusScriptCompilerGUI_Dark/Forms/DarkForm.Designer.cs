using DarkUI.Collections;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using DarkUI.Renderers;

namespace AtlusScriptCompilerGUIFrontend
{
    partial class MainForm : DarkUI.Forms.DarkForm
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
            this.tpOverwrite = new System.Windows.Forms.ToolTip();
            this.chk_SumBits = new DarkUI.Controls.DarkCheckBox();
            this.txtBox_Vanilla = new DarkUI.Controls.DarkTextBox();
            this.txtBox_Royal = new DarkUI.Controls.DarkTextBox();
            this.lbl_Royal = new DarkUI.Controls.DarkLabel();
            this.lbl_Vanilla = new DarkUI.Controls.DarkLabel();
            this.lbl_BitFlag = new DarkUI.Controls.DarkLabel();
            this.btn_Convert = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.AllowDrop = true;
            this.btnCompile.Location = new System.Drawing.Point(16, 95);
            this.btnCompile.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCompile.Size = new System.Drawing.Size(240, 173);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Drag a .BF or .BMD\r\nto Decompile";
            this.btnCompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.DecompileDragDrop);
            this.btnCompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.DecompileDragEnter);
            // 
            // btnDecompile
            // 
            this.btnDecompile.AllowDrop = true;
            this.btnDecompile.Location = new System.Drawing.Point(265, 95);
            this.btnDecompile.Margin = new System.Windows.Forms.Padding(4);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDecompile.Size = new System.Drawing.Size(240, 173);
            this.btnDecompile.TabIndex = 1;
            this.btnDecompile.Text = "Drag a .FLOW or .MSG \r\nto Compile";
            this.btnDecompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.CompileDragDrop);
            this.btnDecompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.CompileDragEnter);
            // 
            // comboGame
            // 
            this.comboGame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboGame.DropDownHeight = 500;
            this.comboGame.FormattingEnabled = true;
            this.comboGame.IntegralHeight = false;
            this.comboGame.Location = new System.Drawing.Point(95, 6);
            this.comboGame.Margin = new System.Windows.Forms.Padding(4);
            this.comboGame.MaxDropDownItems = 3;
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(160, 23);
            this.comboGame.TabIndex = 2;
            this.comboGame.SelectionChangeCommitted += new System.EventHandler(this.Game_Changed);
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelGame.Location = new System.Drawing.Point(36, 10);
            this.labelGame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(47, 16);
            this.labelGame.TabIndex = 3;
            this.labelGame.Text = "Game:";
            // 
            // chk_Hook
            // 
            this.chk_Hook.AutoSize = true;
            this.chk_Hook.Checked = true;
            this.chk_Hook.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Hook.Location = new System.Drawing.Point(265, 5);
            this.chk_Hook.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Hook.Name = "chk_Hook";
            this.chk_Hook.Size = new System.Drawing.Size(126, 20);
            this.chk_Hook.TabIndex = 4;
            this.chk_Hook.Text = "Enable Hooking";
            // 
            // chk_Log
            // 
            this.chk_Log.AutoSize = true;
            this.chk_Log.Checked = true;
            this.chk_Log.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Log.Location = new System.Drawing.Point(403, 5);
            this.chk_Log.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Log.Name = "chk_Log";
            this.chk_Log.Size = new System.Drawing.Size(88, 20);
            this.chk_Log.TabIndex = 5;
            this.chk_Log.Text = "Show Log";
            // 
            // chk_Disassemble
            // 
            this.chk_Disassemble.AutoSize = true;
            this.chk_Disassemble.Location = new System.Drawing.Point(265, 34);
            this.chk_Disassemble.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Disassemble.Name = "chk_Disassemble";
            this.chk_Disassemble.Size = new System.Drawing.Size(109, 20);
            this.chk_Disassemble.TabIndex = 6;
            this.chk_Disassemble.Text = "Disassemble";
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(95, 34);
            this.btnOpenLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnOpenLog.Size = new System.Drawing.Size(161, 28);
            this.btnOpenLog.TabIndex = 7;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.Click += new System.EventHandler(this.OpenLog_Click);
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.AutoSize = true;
            this.chk_Overwrite.Location = new System.Drawing.Point(403, 34);
            this.chk_Overwrite.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(85, 20);
            this.chk_Overwrite.TabIndex = 8;
            this.chk_Overwrite.Text = "Overwrite";
            this.tpOverwrite.SetToolTip(this.chk_Overwrite, "Removes excess extension names when compiling, replacing if neccesary. Will close" +
        " the log.");
            // 
            // tpOverwrite
            // 
            this.tpOverwrite.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tpOverwrite.ToolTipTitle = "Info";
            // 
            // chk_SumBits
            // 
            this.chk_SumBits.AutoSize = true;
            this.chk_SumBits.Location = new System.Drawing.Point(265, 63);
            this.chk_SumBits.Margin = new System.Windows.Forms.Padding(4);
            this.chk_SumBits.Name = "chk_SumBits";
            this.chk_SumBits.Size = new System.Drawing.Size(81, 20);
            this.chk_SumBits.TabIndex = 9;
            this.chk_SumBits.Text = "Sum Bits";
            this.tpOverwrite.SetToolTip(this.chk_SumBits, "Adds all the hex bits");
            // 
            // txtBox_Vanilla
            // 
            this.txtBox_Vanilla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtBox_Vanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_Vanilla.ForeColor = System.Drawing.Color.Silver;
            this.txtBox_Vanilla.Location = new System.Drawing.Point(67, 295);
            this.txtBox_Vanilla.Name = "txtBox_Vanilla";
            this.txtBox_Vanilla.Size = new System.Drawing.Size(161, 22);
            this.txtBox_Vanilla.TabIndex = 10;
            this.txtBox_Vanilla.Leave += new System.EventHandler(this.VanillaText_Changed);
            // 
            // txtBox_Royal
            // 
            this.txtBox_Royal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtBox_Royal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_Royal.ForeColor = System.Drawing.Color.Silver;
            this.txtBox_Royal.Location = new System.Drawing.Point(299, 295);
            this.txtBox_Royal.Name = "txtBox_Royal";
            this.txtBox_Royal.Size = new System.Drawing.Size(160, 22);
            this.txtBox_Royal.TabIndex = 11;
            this.txtBox_Royal.Leave += new System.EventHandler(this.RoyalText_Changed);
            // 
            // lbl_Royal
            // 
            this.lbl_Royal.AutoSize = true;
            this.lbl_Royal.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_Royal.Location = new System.Drawing.Point(465, 298);
            this.lbl_Royal.Name = "lbl_Royal";
            this.lbl_Royal.Size = new System.Drawing.Size(43, 16);
            this.lbl_Royal.TabIndex = 12;
            this.lbl_Royal.Text = "Royal";
            // 
            // lbl_Vanilla
            // 
            this.lbl_Vanilla.AutoSize = true;
            this.lbl_Vanilla.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_Vanilla.Location = new System.Drawing.Point(13, 298);
            this.lbl_Vanilla.Name = "lbl_Vanilla";
            this.lbl_Vanilla.Size = new System.Drawing.Size(48, 16);
            this.lbl_Vanilla.TabIndex = 13;
            this.lbl_Vanilla.Text = "Vanilla";
            // 
            // lbl_BitFlag
            // 
            this.lbl_BitFlag.AutoSize = true;
            this.lbl_BitFlag.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_BitFlag.Location = new System.Drawing.Point(13, 274);
            this.lbl_BitFlag.Name = "lbl_BitFlag";
            this.lbl_BitFlag.Size = new System.Drawing.Size(110, 16);
            this.lbl_BitFlag.TabIndex = 14;
            this.lbl_BitFlag.Text = "BitFlag Converter";
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(234, 295);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Padding = new System.Windows.Forms.Padding(5);
            this.btn_Convert.Size = new System.Drawing.Size(59, 23);
            this.btn_Convert.TabIndex = 15;
            this.btn_Convert.Text = "<=>";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 324);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.lbl_BitFlag);
            this.Controls.Add(this.lbl_Vanilla);
            this.Controls.Add(this.lbl_Royal);
            this.Controls.Add(this.txtBox_Royal);
            this.Controls.Add(this.txtBox_Vanilla);
            this.Controls.Add(this.chk_SumBits);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(537, 371);
            this.MinimumSize = new System.Drawing.Size(537, 371);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptCompiler GUI 2.1 (Dark Mode)";
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
        private DarkCheckBox chk_SumBits;
        private DarkTextBox txtBox_Vanilla;
        private DarkTextBox txtBox_Royal;
        private DarkLabel lbl_Royal;
        private DarkLabel lbl_Vanilla;
        private DarkLabel lbl_BitFlag;
        private DarkButton btn_Convert;
    }
}

