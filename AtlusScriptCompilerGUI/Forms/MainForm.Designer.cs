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
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnDecompile = new System.Windows.Forms.Button();
            this.comboGame = new System.Windows.Forms.ComboBox();
            this.labelGame = new System.Windows.Forms.Label();
            this.chk_Hook = new System.Windows.Forms.CheckBox();
            this.chk_Log = new System.Windows.Forms.CheckBox();
            this.chk_Disassemble = new System.Windows.Forms.CheckBox();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.chk_Overwrite = new System.Windows.Forms.CheckBox();
            this.tpOverwrite = new System.Windows.Forms.ToolTip(this.components);
            this.chk_SumBits = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.AllowDrop = true;
            this.btnCompile.Location = new System.Drawing.Point(12, 77);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(180, 191);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Drag a .BF or .BMD\r\nto Decompile\r\n";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.DecompileDragDrop);
            this.btnCompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.DecompileDragEnter);
            // 
            // btnDecompile
            // 
            this.btnDecompile.AllowDrop = true;
            this.btnDecompile.Location = new System.Drawing.Point(199, 77);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Size = new System.Drawing.Size(180, 191);
            this.btnDecompile.TabIndex = 1;
            this.btnDecompile.Text = "Drag a .FLOW or .MSG \r\nto Compile\r\n";
            this.btnDecompile.UseVisualStyleBackColor = true;
            this.btnDecompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.CompileDragDrop);
            this.btnDecompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.CompileDragEnter);
            // 
            // comboGame
            // 
            this.comboGame.FormattingEnabled = true;
            this.comboGame.Location = new System.Drawing.Point(71, 5);
            this.comboGame.MaxDropDownItems = 3;
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(121, 21);
            this.comboGame.TabIndex = 2;
            this.comboGame.SelectionChangeCommitted += new System.EventHandler(this.Game_Changed);
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
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
            this.chk_Hook.UseVisualStyleBackColor = true;
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
            this.chk_Log.UseVisualStyleBackColor = true;
            // 
            // chk_Disassemble
            // 
            this.chk_Disassemble.AutoSize = true;
            this.chk_Disassemble.Location = new System.Drawing.Point(199, 28);
            this.chk_Disassemble.Name = "chk_Disassemble";
            this.chk_Disassemble.Size = new System.Drawing.Size(85, 17);
            this.chk_Disassemble.TabIndex = 6;
            this.chk_Disassemble.Text = "Disassemble";
            this.chk_Disassemble.UseVisualStyleBackColor = true;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(71, 28);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(122, 23);
            this.btnOpenLog.TabIndex = 7;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.OpenLog_Click);
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
            this.chk_Overwrite.UseVisualStyleBackColor = true;
            // 
            // tpOverwrite
            // 
            this.tpOverwrite.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tpOverwrite.ToolTipTitle = "Info";
            // 
            // chk_SumBits
            // 
            this.chk_SumBits.AutoSize = true;
            this.chk_SumBits.Checked = true;
            this.chk_SumBits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SumBits.Location = new System.Drawing.Point(199, 51);
            this.chk_SumBits.Name = "chk_SumBits";
            this.chk_SumBits.Size = new System.Drawing.Size(67, 17);
            this.chk_SumBits.TabIndex = 9;
            this.chk_SumBits.Text = "Sum Bits";
            this.tpOverwrite.SetToolTip(this.chk_SumBits, "Removes excess extension names when compiling, replacing if neccesary. Will close" +
        " the log.");
            this.chk_SumBits.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 271);
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
            this.MaximumSize = new System.Drawing.Size(407, 310);
            this.MinimumSize = new System.Drawing.Size(407, 310);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptCompiler GUI 2.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnDecompile;
        private System.Windows.Forms.ComboBox comboGame;
        private System.Windows.Forms.Label labelGame;
        private System.Windows.Forms.CheckBox chk_Hook;
        private System.Windows.Forms.CheckBox chk_Log;
        private System.Windows.Forms.CheckBox chk_Disassemble;
        private System.Windows.Forms.CheckBox chk_Overwrite;
        public System.Windows.Forms.ToolTip tpOverwrite;
        public System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.CheckBox chk_SumBits;
    }
}

