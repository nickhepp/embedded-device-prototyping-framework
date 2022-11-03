namespace HostApp.UI.Views
{
    partial class SplashScreen
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
            this._mainTlp = new System.Windows.Forms.TableLayoutPanel();
            this._logoPbx = new System.Windows.Forms.PictureBox();
            this._toolsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._ecsLogoPbx = new System.Windows.Forms.PictureBox();
            this._mainTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._logoPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ecsLogoPbx)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 2;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.Controls.Add(this._logoPbx, 0, 0);
            this._mainTlp.Controls.Add(this._toolsTlp, 1, 0);
            this._mainTlp.Controls.Add(this._ecsLogoPbx, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._mainTlp.Size = new System.Drawing.Size(1203, 671);
            this._mainTlp.TabIndex = 0;
            // 
            // _logoPbx
            // 
            this._logoPbx.BackColor = System.Drawing.Color.Black;
            this._logoPbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logoPbx.Image = global::HostApp.Properties.Resources.logo;
            this._logoPbx.Location = new System.Drawing.Point(3, 3);
            this._logoPbx.Name = "_logoPbx";
            this._logoPbx.Size = new System.Drawing.Size(595, 565);
            this._logoPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._logoPbx.TabIndex = 0;
            this._logoPbx.TabStop = false;
            // 
            // _toolsTlp
            // 
            this._toolsTlp.AutoScroll = true;
            this._toolsTlp.ColumnCount = 1;
            this._toolsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._toolsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolsTlp.Location = new System.Drawing.Point(604, 3);
            this._toolsTlp.Name = "_toolsTlp";
            this._toolsTlp.RowCount = 1;
            this._mainTlp.SetRowSpan(this._toolsTlp, 2);
            this._toolsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._toolsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._toolsTlp.Size = new System.Drawing.Size(596, 665);
            this._toolsTlp.TabIndex = 1;
            // 
            // _ecsLogoPbx
            // 
            this._ecsLogoPbx.BackColor = System.Drawing.Color.White;
            this._ecsLogoPbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ecsLogoPbx.Image = global::HostApp.Properties.Resources.edpf_splash_screen_logo;
            this._ecsLogoPbx.Location = new System.Drawing.Point(3, 574);
            this._ecsLogoPbx.Name = "_ecsLogoPbx";
            this._ecsLogoPbx.Size = new System.Drawing.Size(595, 94);
            this._ecsLogoPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._ecsLogoPbx.TabIndex = 2;
            this._ecsLogoPbx.TabStop = false;
            this._ecsLogoPbx.Click += new System.EventHandler(this._ecsLogoPbx_Click);
            // 
            // SplashScreen
            // 
            this.BackgroundImage = global::HostApp.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1203, 671);
            this.Controls.Add(this._mainTlp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Embedded Device Prototyping Framework";
            this.TopMost = true;
            this._mainTlp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._logoPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ecsLogoPbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.PictureBox _logoPbx;
        private System.Windows.Forms.TableLayoutPanel _toolsTlp;
        private System.Windows.Forms.PictureBox _ecsLogoPbx;
    }
}