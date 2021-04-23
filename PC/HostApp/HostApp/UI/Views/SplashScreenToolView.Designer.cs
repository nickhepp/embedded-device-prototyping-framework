
namespace HostApp.UI.Views
{
    partial class SplashScreenToolView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenToolView));
            this._mainTlp = new System.Windows.Forms.TableLayoutPanel();
            this._toolIconPbx = new System.Windows.Forms.PictureBox();
            this._rightPnl = new System.Windows.Forms.TableLayoutPanel();
            this._toolNameLinkLbl = new System.Windows.Forms.LinkLabel();
            this._descriptionLbl = new System.Windows.Forms.Label();
            this._upvoteEnhancementLlbl = new System.Windows.Forms.LinkLabel();
            this._mainTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._toolIconPbx)).BeginInit();
            this._rightPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this._mainTlp.ColumnCount = 2;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.Controls.Add(this._toolIconPbx, 0, 0);
            this._mainTlp.Controls.Add(this._rightPnl, 1, 0);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 1;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this._mainTlp.Size = new System.Drawing.Size(831, 200);
            this._mainTlp.TabIndex = 0;
            // 
            // _toolIconPbx
            // 
            this._toolIconPbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this._toolIconPbx.Location = new System.Drawing.Point(4, 4);
            this._toolIconPbx.Name = "_toolIconPbx";
            this._toolIconPbx.Size = new System.Drawing.Size(182, 192);
            this._toolIconPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._toolIconPbx.TabIndex = 0;
            this._toolIconPbx.TabStop = false;
            // 
            // _rightPnl
            // 
            this._rightPnl.ColumnCount = 1;
            this._rightPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rightPnl.Controls.Add(this._toolNameLinkLbl, 0, 0);
            this._rightPnl.Controls.Add(this._descriptionLbl, 0, 1);
            this._rightPnl.Controls.Add(this._upvoteEnhancementLlbl, 0, 2);
            this._rightPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightPnl.Location = new System.Drawing.Point(193, 4);
            this._rightPnl.Name = "_rightPnl";
            this._rightPnl.RowCount = 3;
            this._rightPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this._rightPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rightPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this._rightPnl.Size = new System.Drawing.Size(634, 192);
            this._rightPnl.TabIndex = 1;
            // 
            // _toolNameLinkLbl
            // 
            this._toolNameLinkLbl.AutoSize = true;
            this._toolNameLinkLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._toolNameLinkLbl.Location = new System.Drawing.Point(3, 0);
            this._toolNameLinkLbl.Name = "_toolNameLinkLbl";
            this._toolNameLinkLbl.Size = new System.Drawing.Size(365, 37);
            this._toolNameLinkLbl.TabIndex = 0;
            this._toolNameLinkLbl.TabStop = true;
            this._toolNameLinkLbl.Text = "gTool Label (roadmap)";
            this._toolNameLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._toolNameLinkLbl_LinkClicked);
            // 
            // _descriptionLbl
            // 
            this._descriptionLbl.AutoEllipsis = true;
            this._descriptionLbl.AutoSize = true;
            this._descriptionLbl.Location = new System.Drawing.Point(3, 48);
            this._descriptionLbl.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this._descriptionLbl.Name = "_descriptionLbl";
            this._descriptionLbl.Size = new System.Drawing.Size(628, 111);
            this._descriptionLbl.TabIndex = 1;
            this._descriptionLbl.Text = resources.GetString("_descriptionLbl.Text");
            // 
            // _upvoteEnhancementLlbl
            // 
            this._upvoteEnhancementLlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._upvoteEnhancementLlbl.AutoSize = true;
            this._upvoteEnhancementLlbl.BackColor = System.Drawing.Color.Lime;
            this._upvoteEnhancementLlbl.ForeColor = System.Drawing.Color.Black;
            this._upvoteEnhancementLlbl.LinkColor = System.Drawing.Color.Black;
            this._upvoteEnhancementLlbl.Location = new System.Drawing.Point(3, 167);
            this._upvoteEnhancementLlbl.Name = "_upvoteEnhancementLlbl";
            this._upvoteEnhancementLlbl.Size = new System.Drawing.Size(216, 25);
            this._upvoteEnhancementLlbl.TabIndex = 2;
            this._upvoteEnhancementLlbl.TabStop = true;
            this._upvoteEnhancementLlbl.Text = "Upvote enhancement";
            this._upvoteEnhancementLlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._upvoteEnhancementLlbl_LinkClicked);
            // 
            // SplashScreenToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "SplashScreenToolView";
            this.Size = new System.Drawing.Size(831, 200);
            this._mainTlp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._toolIconPbx)).EndInit();
            this._rightPnl.ResumeLayout(false);
            this._rightPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.PictureBox _toolIconPbx;
        private System.Windows.Forms.TableLayoutPanel _rightPnl;
        private System.Windows.Forms.LinkLabel _toolNameLinkLbl;
        private System.Windows.Forms.Label _descriptionLbl;
        private System.Windows.Forms.LinkLabel _upvoteEnhancementLlbl;
    }
}
