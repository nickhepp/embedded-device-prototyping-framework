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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._exitTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._toolsTsm = new System.Windows.Forms.ToolStripMenuItem();
            this._mainPnl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileTsm,
            this._toolsTsm});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1664, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileTsm
            // 
            this._fileTsm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._exitTsm});
            this._fileTsm.Name = "_fileTsm";
            this._fileTsm.Size = new System.Drawing.Size(72, 36);
            this._fileTsm.Text = "File";
            // 
            // _exitTsm
            // 
            this._exitTsm.Name = "_exitTsm";
            this._exitTsm.Size = new System.Drawing.Size(186, 44);
            this._exitTsm.Text = "Exit";
            this._exitTsm.Click += new System.EventHandler(this._exitTsm_Click);
            // 
            // _toolsTsm
            // 
            this._toolsTsm.Name = "_toolsTsm";
            this._toolsTsm.Size = new System.Drawing.Size(90, 36);
            this._toolsTsm.Text = "Tools";
            // 
            // _mainPnl
            // 
            this._mainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPnl.Location = new System.Drawing.Point(0, 40);
            this._mainPnl.Name = "_mainPnl";
            this._mainPnl.Size = new System.Drawing.Size(1664, 931);
            this._mainPnl.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1664, 971);
            this.Controls.Add(this._mainPnl);
            this.Controls.Add(this.menuStrip1);
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
    }
}

