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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnDecompile = new System.Windows.Forms.Button();
            this.comboGame = new System.Windows.Forms.ComboBox();
            this.labelGame = new System.Windows.Forms.Label();
            this.chk_Hook = new System.Windows.Forms.CheckBox();
            this.chk_Log = new System.Windows.Forms.CheckBox();
            this.chk_Disassemble = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.AllowDrop = true;
            this.btnCompile.Location = new System.Drawing.Point(16, 63);
            this.btnCompile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(240, 235);
            this.btnCompile.TabIndex = 0;
            this.btnCompile.Text = "Drag a BF or BMD here to Decompile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.DecompileClick);
            this.btnCompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.DecompileDragDrop);
            this.btnCompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.DecompileDragEnter);
            // 
            // btnDecompile
            // 
            this.btnDecompile.AllowDrop = true;
            this.btnDecompile.Location = new System.Drawing.Point(265, 63);
            this.btnDecompile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Size = new System.Drawing.Size(240, 235);
            this.btnDecompile.TabIndex = 1;
            this.btnDecompile.Text = "Drag a Flowscript or Messagescript here to Compile";
            this.btnDecompile.UseVisualStyleBackColor = true;
            this.btnDecompile.Click += new System.EventHandler(this.CompileClick);
            this.btnDecompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.CompileDragDrop);
            this.btnDecompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.CompileDragEnter);
            // 
            // comboGame
            // 
            this.comboGame.FormattingEnabled = true;
            this.comboGame.Location = new System.Drawing.Point(76, 15);
            this.comboGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboGame.MaxDropDownItems = 3;
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(160, 24);
            this.comboGame.TabIndex = 2;
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Location = new System.Drawing.Point(17, 18);
            this.labelGame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(50, 17);
            this.labelGame.TabIndex = 3;
            this.labelGame.Text = "Game:";
            // 
            // chk_Hook
            // 
            this.chk_Hook.AutoSize = true;
            this.chk_Hook.Checked = true;
            this.chk_Hook.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Hook.Location = new System.Drawing.Point(265, 5);
            this.chk_Hook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_Hook.Name = "chk_Hook";
            this.chk_Hook.Size = new System.Drawing.Size(130, 21);
            this.chk_Hook.TabIndex = 4;
            this.chk_Hook.Text = "Enable Hooking";
            this.chk_Hook.UseVisualStyleBackColor = true;
            // 
            // chk_Log
            // 
            this.chk_Log.AutoSize = true;
            this.chk_Log.Location = new System.Drawing.Point(403, 5);
            this.chk_Log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chk_Log.Name = "chk_Log";
            this.chk_Log.Size = new System.Drawing.Size(92, 21);
            this.chk_Log.TabIndex = 5;
            this.chk_Log.Text = "Show Log";
            this.chk_Log.UseVisualStyleBackColor = true;
            // 
            // chk_Disassemble
            // 
            this.chk_Disassemble.AutoSize = true;
            this.chk_Disassemble.Location = new System.Drawing.Point(265, 34);
            this.chk_Disassemble.Margin = new System.Windows.Forms.Padding(4);
            this.chk_Disassemble.Name = "chk_Disassemble";
            this.chk_Disassemble.Size = new System.Drawing.Size(110, 21);
            this.chk_Disassemble.TabIndex = 6;
            this.chk_Disassemble.Text = "Disassemble";
            this.chk_Disassemble.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 298);
            this.Controls.Add(this.chk_Disassemble);
            this.Controls.Add(this.chk_Log);
            this.Controls.Add(this.chk_Hook);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnDecompile);
            this.Controls.Add(this.btnCompile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(537, 345);
            this.MinimumSize = new System.Drawing.Size(537, 345);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptCompiler GUI Frontend 1.2";
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
    }
}

