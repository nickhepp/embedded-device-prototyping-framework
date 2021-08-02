
namespace HostApp.UI.Views
{
    partial class NotImplementedView
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
            this._upvoteEnhancementLlbl = new System.Windows.Forms.LinkLabel();
            this._mainPnl = new System.Windows.Forms.TableLayoutPanel();
            this._previewPnl = new System.Windows.Forms.Panel();
            this._previewNotAvailableLbl = new System.Windows.Forms.Label();
            this._mainPnl.SuspendLayout();
            this._previewPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _upvoteEnhancementLlbl
            // 
            this._upvoteEnhancementLlbl.AutoSize = true;
            this._upvoteEnhancementLlbl.BackColor = System.Drawing.Color.Lime;
            this._upvoteEnhancementLlbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._upvoteEnhancementLlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._upvoteEnhancementLlbl.ForeColor = System.Drawing.Color.Black;
            this._upvoteEnhancementLlbl.LinkColor = System.Drawing.Color.Black;
            this._upvoteEnhancementLlbl.Location = new System.Drawing.Point(3, 354);
            this._upvoteEnhancementLlbl.Name = "_upvoteEnhancementLlbl";
            this._upvoteEnhancementLlbl.Size = new System.Drawing.Size(675, 50);
            this._upvoteEnhancementLlbl.TabIndex = 3;
            this._upvoteEnhancementLlbl.TabStop = true;
            this._upvoteEnhancementLlbl.Text = "Upvote enhancement";
            this._upvoteEnhancementLlbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _mainPnl
            // 
            this._mainPnl.ColumnCount = 1;
            this._mainPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainPnl.Controls.Add(this._upvoteEnhancementLlbl, 0, 1);
            this._mainPnl.Controls.Add(this._previewPnl, 0, 0);
            this._mainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPnl.Location = new System.Drawing.Point(0, 0);
            this._mainPnl.Name = "_mainPnl";
            this._mainPnl.RowCount = 2;
            this._mainPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._mainPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainPnl.Size = new System.Drawing.Size(681, 404);
            this._mainPnl.TabIndex = 4;
            // 
            // _previewPnl
            // 
            this._previewPnl.Controls.Add(this._previewNotAvailableLbl);
            this._previewPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._previewPnl.Location = new System.Drawing.Point(3, 3);
            this._previewPnl.Name = "_previewPnl";
            this._previewPnl.Size = new System.Drawing.Size(675, 348);
            this._previewPnl.TabIndex = 4;
            // 
            // _previewNotAvailableLbl
            // 
            this._previewNotAvailableLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._previewNotAvailableLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._previewNotAvailableLbl.Location = new System.Drawing.Point(0, 0);
            this._previewNotAvailableLbl.Name = "_previewNotAvailableLbl";
            this._previewNotAvailableLbl.Size = new System.Drawing.Size(675, 348);
            this._previewNotAvailableLbl.TabIndex = 0;
            this._previewNotAvailableLbl.Text = "[Preview not available]";
            this._previewNotAvailableLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NotImplementedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainPnl);
            this.Name = "NotImplementedView";
            this.Size = new System.Drawing.Size(681, 404);
            this._mainPnl.ResumeLayout(false);
            this._mainPnl.PerformLayout();
            this._previewPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel _upvoteEnhancementLlbl;
        private System.Windows.Forms.TableLayoutPanel _mainPnl;
        private System.Windows.Forms.Panel _previewPnl;
        private System.Windows.Forms.Label _previewNotAvailableLbl;
    }
}
