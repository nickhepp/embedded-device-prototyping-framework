namespace HostApp.UI.Views
{
    partial class ConsoleControlView
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
            this._tlpBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._deviceHistoryRtb = new System.Windows.Forms.RichTextBox();
            this._consoleInputTlp = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._inputTxt = new System.Windows.Forms.TextBox();
            this._tlpBottomLeft.SuspendLayout();
            this._consoleInputTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tlpBottomLeft
            // 
            this._tlpBottomLeft.BackColor = System.Drawing.Color.White;
            this._tlpBottomLeft.ColumnCount = 1;
            this._tlpBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tlpBottomLeft.Controls.Add(this.label3, 0, 0);
            this._tlpBottomLeft.Controls.Add(this._deviceHistoryRtb, 0, 1);
            this._tlpBottomLeft.Controls.Add(this._consoleInputTlp, 0, 2);
            this._tlpBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tlpBottomLeft.Location = new System.Drawing.Point(0, 0);
            this._tlpBottomLeft.Name = "_tlpBottomLeft";
            this._tlpBottomLeft.RowCount = 3;
            this._tlpBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this._tlpBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tlpBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tlpBottomLeft.Size = new System.Drawing.Size(1015, 674);
            this._tlpBottomLeft.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Console:";
            // 
            // _deviceHistoryRtb
            // 
            this._deviceHistoryRtb.BackColor = System.Drawing.Color.Black;
            this._deviceHistoryRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deviceHistoryRtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this._deviceHistoryRtb.ForeColor = System.Drawing.Color.White;
            this._deviceHistoryRtb.Location = new System.Drawing.Point(3, 50);
            this._deviceHistoryRtb.Name = "_deviceHistoryRtb";
            this._deviceHistoryRtb.ReadOnly = true;
            this._deviceHistoryRtb.Size = new System.Drawing.Size(1009, 571);
            this._deviceHistoryRtb.TabIndex = 1;
            this._deviceHistoryRtb.Text = "$ This is test text";
            // 
            // _consoleInputTlp
            // 
            this._consoleInputTlp.ColumnCount = 2;
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.Controls.Add(this.label4, 0, 0);
            this._consoleInputTlp.Controls.Add(this._inputTxt, 1, 0);
            this._consoleInputTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._consoleInputTlp.Location = new System.Drawing.Point(3, 627);
            this._consoleInputTlp.Name = "_consoleInputTlp";
            this._consoleInputTlp.RowCount = 1;
            this._consoleInputTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._consoleInputTlp.Size = new System.Drawing.Size(1009, 44);
            this._consoleInputTlp.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Input:";
            // 
            // _inputTxt
            // 
            this._inputTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputTxt.Location = new System.Drawing.Point(82, 3);
            this._inputTxt.Name = "_inputTxt";
            this._inputTxt.Size = new System.Drawing.Size(924, 31);
            this._inputTxt.TabIndex = 1;
            // 
            // ConsoleControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tlpBottomLeft);
            this.Name = "ConsoleControlView";
            this.Size = new System.Drawing.Size(1015, 674);
            this._tlpBottomLeft.ResumeLayout(false);
            this._tlpBottomLeft.PerformLayout();
            this._consoleInputTlp.ResumeLayout(false);
            this._consoleInputTlp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tlpBottomLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox _deviceHistoryRtb;
        private System.Windows.Forms.TableLayoutPanel _consoleInputTlp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _inputTxt;
    }
}
