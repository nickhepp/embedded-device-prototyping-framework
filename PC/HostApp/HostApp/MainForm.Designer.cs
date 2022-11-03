namespace HostApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._mainPnl = new System.Windows.Forms.Panel();
            this._fileTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._exitTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._toolsTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._shareTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._shareAnIdeaTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._reportBugTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._visitECDotComTsm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileTsm,
            this._toolsTsm,
            this._shareTsm});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _mainPnl
            // 
            this._mainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPnl.Location = new System.Drawing.Point(0, 42);
            this._mainPnl.Name = "_mainPnl";
            this._mainPnl.Size = new System.Drawing.Size(1370, 707);
            this._mainPnl.TabIndex = 1;
            // 
            // _fileTsm
            // 
            this._fileTsm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._exitTsm});
            this._fileTsm.Image = global::HostApp.Properties.Resources.file;
            this._fileTsm.Name = "_fileTsm";
            this._fileTsm.Size = new System.Drawing.Size(103, 38);
            this._fileTsm.Text = "File";
            // 
            // _exitTsm
            // 
            this._exitTsm.Name = "_exitTsm";
            this._exitTsm.Size = new System.Drawing.Size(184, 44);
            this._exitTsm.Text = "Exit";
            this._exitTsm.Click += new System.EventHandler(this._exitTsm_Click);
            // 
            // _toolsTsm
            // 
            this._toolsTsm.Image = global::HostApp.Properties.Resources.construction;
            this._toolsTsm.Name = "_toolsTsm";
            this._toolsTsm.Size = new System.Drawing.Size(121, 38);
            this._toolsTsm.Text = "Tools";
            // 
            // _shareTsm
            // 
            this._shareTsm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._shareAnIdeaTsm,
            this._reportBugTsm,
            this._visitECDotComTsm});
            this._shareTsm.Image = global::HostApp.Properties.Resources.share_alt;
            this._shareTsm.Name = "_shareTsm";
            this._shareTsm.Size = new System.Drawing.Size(126, 38);
            this._shareTsm.Text = "Share";
            // 
            // _shareAnIdeaTsm
            // 
            this._shareAnIdeaTsm.Image = global::HostApp.Properties.Resources.lightbulb_on;
            this._shareAnIdeaTsm.Name = "_shareAnIdeaTsm";
            this._shareAnIdeaTsm.Size = new System.Drawing.Size(488, 44);
            this._shareAnIdeaTsm.Text = "Share an idea for EDPF...";
            this._shareAnIdeaTsm.Click += new System.EventHandler(this._shareAnIdeaTsm_Click);
            // 
            // _reportBugTsm
            // 
            this._reportBugTsm.Image = global::HostApp.Properties.Resources.bug;
            this._reportBugTsm.Name = "_reportBugTsm";
            this._reportBugTsm.Size = new System.Drawing.Size(488, 44);
            this._reportBugTsm.Text = "Report an EDPF bug...";
            this._reportBugTsm.Click += new System.EventHandler(this._reportBugTsm_Click);
            // 
            // _visitECDotComTsm_Click
            // 
            this._visitECDotComTsm.Image = global::HostApp.Properties.Resources.ecs_favicon;
            this._visitECDotComTsm.Name = "visitElectronicComputingcomToolStripMenuItem";
            this._visitECDotComTsm.Size = new System.Drawing.Size(488, 44);
            this._visitECDotComTsm.Text = "Visit ElectronicComputing.com...";
            this._visitECDotComTsm.Click += new System.EventHandler(this._visitECDotComTsm_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this._mainPnl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileTsm;
        private System.Windows.Forms.ToolStripMenuItem _exitTsm;
        private System.Windows.Forms.ToolStripMenuItem _toolsTsm;
        private System.Windows.Forms.Panel _mainPnl;
        private System.Windows.Forms.ToolStripMenuItem _shareTsm;
        private System.Windows.Forms.ToolStripMenuItem _shareAnIdeaTsm;
        private System.Windows.Forms.ToolStripMenuItem _reportBugTsm;
        private System.Windows.Forms.ToolStripMenuItem _visitECDotComTsm;
    }
}

