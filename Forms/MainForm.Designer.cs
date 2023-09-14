using MetroSet_UI.Forms;

namespace AtlusScriptGUI
{
    partial class MainForm : MetroSetForm
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
            this.btn_Decompile = new System.Windows.Forms.Button();
            this.btn_Compile = new System.Windows.Forms.Button();
            this.tpOverwrite = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_Vanilla = new System.Windows.Forms.Label();
            this.lbl_Royal = new System.Windows.Forms.Label();
            this.txtBox_Royal = new System.Windows.Forms.TextBox();
            this.txtBox_Vanilla = new System.Windows.Forms.TextBox();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_Game = new System.Windows.Forms.ToolStripComboBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_Hook = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_Disassemble = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_Overwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_SumBits = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_DeleteHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer_Log = new System.Windows.Forms.SplitContainer();
            this.groupBox_BitFlagConverter = new System.Windows.Forms.GroupBox();
            this.tlp_BitFlagConverter = new System.Windows.Forms.TableLayoutPanel();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.menuStrip_Main.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Log)).BeginInit();
            this.splitContainer_Log.Panel1.SuspendLayout();
            this.splitContainer_Log.Panel2.SuspendLayout();
            this.splitContainer_Log.SuspendLayout();
            this.groupBox_BitFlagConverter.SuspendLayout();
            this.tlp_BitFlagConverter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Decompile
            // 
            this.btn_Decompile.AllowDrop = true;
            this.btn_Decompile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Decompile.Location = new System.Drawing.Point(4, 4);
            this.btn_Decompile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Decompile.Name = "btn_Decompile";
            this.btn_Decompile.Size = new System.Drawing.Size(231, 106);
            this.btn_Decompile.TabIndex = 0;
            this.btn_Decompile.Text = "Drag a .BF or .BMD\r\nto Decompile\r\n";
            this.btn_Decompile.UseVisualStyleBackColor = true;
            this.btn_Decompile.Click += new System.EventHandler(this.Btn_Click);
            this.btn_Decompile.DragDrop += new System.Windows.Forms.DragEventHandler(this.Btn_DragDrop);
            this.btn_Decompile.DragEnter += new System.Windows.Forms.DragEventHandler(this.Btn_DragEnter);
            // 
            // btn_Compile
            // 
            this.btn_Compile.AllowDrop = true;
            this.btn_Compile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Compile.Location = new System.Drawing.Point(243, 4);
            this.btn_Compile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Compile.Name = "btn_Compile";
            this.btn_Compile.Size = new System.Drawing.Size(231, 106);
            this.btn_Compile.TabIndex = 1;
            this.btn_Compile.Text = "Drag a .FLOW or .MSG \r\nto Compile\r\n";
            this.btn_Compile.UseVisualStyleBackColor = true;
            this.btn_Compile.Click += new System.EventHandler(this.Btn_Click);
            this.btn_Compile.DragDrop += new System.Windows.Forms.DragEventHandler(this.Btn_DragDrop);
            this.btn_Compile.DragEnter += new System.Windows.Forms.DragEventHandler(this.Btn_DragEnter);
            // 
            // tpOverwrite
            // 
            this.tpOverwrite.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tpOverwrite.ToolTipTitle = "Info";
            // 
            // lbl_Vanilla
            // 
            this.lbl_Vanilla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Vanilla.AutoSize = true;
            this.lbl_Vanilla.Location = new System.Drawing.Point(63, 40);
            this.lbl_Vanilla.Name = "lbl_Vanilla";
            this.lbl_Vanilla.Size = new System.Drawing.Size(59, 20);
            this.lbl_Vanilla.TabIndex = 18;
            this.lbl_Vanilla.Text = "Vanilla";
            // 
            // lbl_Royal
            // 
            this.lbl_Royal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Royal.AutoSize = true;
            this.lbl_Royal.Location = new System.Drawing.Point(347, 40);
            this.lbl_Royal.Name = "lbl_Royal";
            this.lbl_Royal.Size = new System.Drawing.Size(51, 20);
            this.lbl_Royal.TabIndex = 17;
            this.lbl_Royal.Text = "Royal";
            // 
            // txtBox_Royal
            // 
            this.txtBox_Royal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Royal.Location = new System.Drawing.Point(282, 7);
            this.txtBox_Royal.Name = "txtBox_Royal";
            this.txtBox_Royal.Size = new System.Drawing.Size(181, 26);
            this.txtBox_Royal.TabIndex = 16;
            this.txtBox_Royal.Leave += new System.EventHandler(this.RoyalText_Changed);
            // 
            // txtBox_Vanilla
            // 
            this.txtBox_Vanilla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Vanilla.Location = new System.Drawing.Point(3, 7);
            this.txtBox_Vanilla.Name = "txtBox_Vanilla";
            this.txtBox_Vanilla.Size = new System.Drawing.Size(180, 26);
            this.txtBox_Vanilla.TabIndex = 15;
            this.txtBox_Vanilla.Leave += new System.EventHandler(this.VanillaText_Changed);
            // 
            // btn_Convert
            // 
            this.btn_Convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Convert.Location = new System.Drawing.Point(189, 8);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(87, 23);
            this.btn_Convert.TabIndex = 20;
            this.btn_Convert.Text = "<=>";
            this.btn_Convert.UseVisualStyleBackColor = true;
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.openLogToolStripMenuItem,
            this.toggleThemeToolStripMenuItem});
            this.menuStrip_Main.Location = new System.Drawing.Point(2, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(478, 28);
            this.menuStrip_Main.TabIndex = 21;
            this.menuStrip_Main.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBox_Game});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // comboBox_Game
            // 
            this.comboBox_Game.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Game.Name = "comboBox_Game";
            this.comboBox_Game.Size = new System.Drawing.Size(230, 28);
            this.comboBox_Game.SelectedIndexChanged += new System.EventHandler(this.Game_Changed);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chk_Hook,
            this.chk_Disassemble,
            this.chk_Overwrite,
            this.chk_SumBits,
            this.chk_DeleteHeader});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // chk_Hook
            // 
            this.chk_Hook.Checked = true;
            this.chk_Hook.CheckOnClick = true;
            this.chk_Hook.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Hook.Name = "chk_Hook";
            this.chk_Hook.Size = new System.Drawing.Size(198, 26);
            this.chk_Hook.Text = "Enable Hooking";
            // 
            // chk_Disassemble
            // 
            this.chk_Disassemble.CheckOnClick = true;
            this.chk_Disassemble.Name = "chk_Disassemble";
            this.chk_Disassemble.Size = new System.Drawing.Size(198, 26);
            this.chk_Disassemble.Text = "Disassemble";
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.CheckOnClick = true;
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(198, 26);
            this.chk_Overwrite.Text = "Overwrite";
            // 
            // chk_SumBits
            // 
            this.chk_SumBits.Checked = true;
            this.chk_SumBits.CheckOnClick = true;
            this.chk_SumBits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SumBits.Name = "chk_SumBits";
            this.chk_SumBits.Size = new System.Drawing.Size(198, 26);
            this.chk_SumBits.Text = "Sum Bits";
            // 
            // chk_DeleteHeader
            // 
            this.chk_DeleteHeader.CheckOnClick = true;
            this.chk_DeleteHeader.Name = "chk_DeleteHeader";
            this.chk_DeleteHeader.Size = new System.Drawing.Size(198, 26);
            this.chk_DeleteHeader.Text = "Delete .h";
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.Visible = false;
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.OpenLog_Click);
            // 
            // toggleThemeToolStripMenuItem
            // 
            this.toggleThemeToolStripMenuItem.Name = "toggleThemeToolStripMenuItem";
            this.toggleThemeToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.toggleThemeToolStripMenuItem.Text = "Toggle Theme";
            this.toggleThemeToolStripMenuItem.Click += new System.EventHandler(this.ToggleTheme_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.btn_Decompile, 0, 0);
            this.tlp_Main.Controls.Add(this.btn_Compile, 1, 0);
            this.tlp_Main.Controls.Add(this.splitContainer_Log, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(2, 28);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp_Main.Size = new System.Drawing.Size(478, 382);
            this.tlp_Main.TabIndex = 22;
            // 
            // splitContainer_Log
            // 
            this.tlp_Main.SetColumnSpan(this.splitContainer_Log, 2);
            this.splitContainer_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Log.Location = new System.Drawing.Point(3, 117);
            this.splitContainer_Log.Name = "splitContainer_Log";
            this.splitContainer_Log.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Log.Panel1
            // 
            this.splitContainer_Log.Panel1.Controls.Add(this.groupBox_BitFlagConverter);
            // 
            // splitContainer_Log.Panel2
            // 
            this.splitContainer_Log.Panel2.Controls.Add(this.rtb_Log);
            this.splitContainer_Log.Size = new System.Drawing.Size(472, 262);
            this.splitContainer_Log.SplitterDistance = 100;
            this.splitContainer_Log.TabIndex = 25;
            // 
            // groupBox_BitFlagConverter
            // 
            this.groupBox_BitFlagConverter.Controls.Add(this.tlp_BitFlagConverter);
            this.groupBox_BitFlagConverter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_BitFlagConverter.Location = new System.Drawing.Point(0, 0);
            this.groupBox_BitFlagConverter.Name = "groupBox_BitFlagConverter";
            this.groupBox_BitFlagConverter.Size = new System.Drawing.Size(472, 100);
            this.groupBox_BitFlagConverter.TabIndex = 24;
            this.groupBox_BitFlagConverter.TabStop = false;
            this.groupBox_BitFlagConverter.Text = "BitFlag Converter";
            // 
            // tlp_BitFlagConverter
            // 
            this.tlp_BitFlagConverter.ColumnCount = 3;
            this.tlp_BitFlagConverter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_BitFlagConverter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_BitFlagConverter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlp_BitFlagConverter.Controls.Add(this.txtBox_Vanilla, 0, 0);
            this.tlp_BitFlagConverter.Controls.Add(this.lbl_Vanilla, 0, 1);
            this.tlp_BitFlagConverter.Controls.Add(this.btn_Convert, 1, 0);
            this.tlp_BitFlagConverter.Controls.Add(this.txtBox_Royal, 2, 0);
            this.tlp_BitFlagConverter.Controls.Add(this.lbl_Royal, 2, 1);
            this.tlp_BitFlagConverter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_BitFlagConverter.Location = new System.Drawing.Point(3, 22);
            this.tlp_BitFlagConverter.Name = "tlp_BitFlagConverter";
            this.tlp_BitFlagConverter.RowCount = 3;
            this.tlp_BitFlagConverter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_BitFlagConverter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_BitFlagConverter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_BitFlagConverter.Size = new System.Drawing.Size(466, 75);
            this.tlp_BitFlagConverter.TabIndex = 23;
            // 
            // rtb_Log
            // 
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.Location = new System.Drawing.Point(0, 0);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(472, 158);
            this.rtb_Log.TabIndex = 0;
            this.rtb_Log.Text = "";
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(482, 412);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.menuStrip_Main);
            this.DropShadowEffect = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.HeaderHeight = -40;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_Main;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.ShowHeader = true;
            this.ShowLeftRect = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AtlusScriptGUI";
            this.TextColor = System.Drawing.Color.White;
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.splitContainer_Log.Panel1.ResumeLayout(false);
            this.splitContainer_Log.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Log)).EndInit();
            this.splitContainer_Log.ResumeLayout(false);
            this.groupBox_BitFlagConverter.ResumeLayout(false);
            this.tlp_BitFlagConverter.ResumeLayout(false);
            this.tlp_BitFlagConverter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Decompile;
        private System.Windows.Forms.Button btn_Compile;
        public System.Windows.Forms.ToolTip tpOverwrite;
        private System.Windows.Forms.Label lbl_Vanilla;
        private System.Windows.Forms.Label lbl_Royal;
        private System.Windows.Forms.TextBox txtBox_Royal;
        private System.Windows.Forms.TextBox txtBox_Vanilla;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chk_Hook;
        private System.Windows.Forms.ToolStripMenuItem chk_Disassemble;
        private System.Windows.Forms.ToolStripMenuItem chk_Overwrite;
        private System.Windows.Forms.ToolStripMenuItem chk_SumBits;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comboBox_Game;
        private System.Windows.Forms.ToolStripMenuItem toggleThemeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.GroupBox groupBox_BitFlagConverter;
        private System.Windows.Forms.TableLayoutPanel tlp_BitFlagConverter;
        private System.Windows.Forms.SplitContainer splitContainer_Log;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.ToolStripMenuItem chk_DeleteHeader;
    }
}

