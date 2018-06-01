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
            this.SuspendLayout();
            // 
            // btnCompile
            // 
            this.btnCompile.AllowDrop = true;
            this.btnCompile.Location = new System.Drawing.Point(12, 51);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(180, 191);
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
            this.btnDecompile.Location = new System.Drawing.Point(199, 51);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Size = new System.Drawing.Size(180, 191);
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
            this.comboGame.Location = new System.Drawing.Point(57, 12);
            this.comboGame.MaxDropDownItems = 3;
            this.comboGame.Name = "comboGame";
            this.comboGame.Size = new System.Drawing.Size(121, 21);
            this.comboGame.TabIndex = 2;
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Location = new System.Drawing.Point(13, 15);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(38, 13);
            this.labelGame.TabIndex = 3;
            this.labelGame.Text = "Game:";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 250);
            this.Controls.Add(this.labelGame);
            this.Controls.Add(this.comboGame);
            this.Controls.Add(this.btnDecompile);
            this.Controls.Add(this.btnCompile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(407, 289);
            this.MinimumSize = new System.Drawing.Size(407, 289);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptCompiler GUI Frontend";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnDecompile;
        private System.Windows.Forms.ComboBox comboGame;
        private System.Windows.Forms.Label labelGame;
    }
}

