namespace Ecs.Edpf.GUI.UI.Views
{
    partial class ConsoleView
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
            this._mainTlp = new System.Windows.Forms.TableLayoutPanel();
            this._consoleLbl = new System.Windows.Forms.Label();
            this._deviceHistoryRtb = new System.Windows.Forms.RichTextBox();
            this._consoleInputTlp = new System.Windows.Forms.TableLayoutPanel();
            this._inputTxt = new System.Windows.Forms.TextBox();
            this._inputLbl = new System.Windows.Forms.Label();
            this._previousCommandsPnl = new System.Windows.Forms.Panel();
            this._mainTlp.SuspendLayout();
            this._consoleInputTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.BackColor = System.Drawing.Color.White;
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Controls.Add(this._consoleLbl, 0, 0);
            this._mainTlp.Controls.Add(this._deviceHistoryRtb, 0, 1);
            this._mainTlp.Controls.Add(this._consoleInputTlp, 0, 2);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 3;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this._mainTlp.Size = new System.Drawing.Size(1015, 674);
            this._mainTlp.TabIndex = 1;
            // 
            // _consoleLbl
            // 
            this._consoleLbl.AutoSize = true;
            this._consoleLbl.BackColor = System.Drawing.Color.White;
            this._consoleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._consoleLbl.Location = new System.Drawing.Point(3, 0);
            this._consoleLbl.Name = "_consoleLbl";
            this._consoleLbl.Size = new System.Drawing.Size(174, 42);
            this._consoleLbl.TabIndex = 0;
            this._consoleLbl.Text = "Console:";
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
            this._deviceHistoryRtb.Size = new System.Drawing.Size(1009, 556);
            this._deviceHistoryRtb.TabIndex = 1;
            this._deviceHistoryRtb.Text = "$ This is test text";
            // 
            // _consoleInputTlp
            // 
            this._consoleInputTlp.ColumnCount = 3;
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this._consoleInputTlp.Controls.Add(this._inputTxt, 1, 0);
            this._consoleInputTlp.Controls.Add(this._inputLbl, 0, 0);
            this._consoleInputTlp.Controls.Add(this._previousCommandsPnl, 2, 0);
            this._consoleInputTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._consoleInputTlp.Location = new System.Drawing.Point(3, 612);
            this._consoleInputTlp.Name = "_consoleInputTlp";
            this._consoleInputTlp.RowCount = 1;
            this._consoleInputTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.Size = new System.Drawing.Size(1009, 59);
            this._consoleInputTlp.TabIndex = 2;
            // 
            // _inputTxt
            // 
            this._inputTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._inputTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this._inputTxt.Location = new System.Drawing.Point(123, 3);
            this._inputTxt.Name = "_inputTxt";
            this._inputTxt.Size = new System.Drawing.Size(816, 49);
            this._inputTxt.TabIndex = 1;
            // 
            // _inputLbl
            // 
            this._inputLbl.AutoSize = true;
            this._inputLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._inputLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this._inputLbl.Location = new System.Drawing.Point(3, 0);
            this._inputLbl.Name = "_inputLbl";
            this._inputLbl.Size = new System.Drawing.Size(114, 59);
            this._inputLbl.TabIndex = 0;
            this._inputLbl.Text = "Input:";
            this._inputLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _previousCommandsPnl
            // 
            this._previousCommandsPnl.Location = new System.Drawing.Point(945, 3);
            this._previousCommandsPnl.Name = "_previousCommandsPnl";
            this._previousCommandsPnl.Size = new System.Drawing.Size(61, 53);
            this._previousCommandsPnl.TabIndex = 2;
            // 
            // ConsoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "ConsoleView";
            this.Size = new System.Drawing.Size(1015, 674);
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this._consoleInputTlp.ResumeLayout(false);
            this._consoleInputTlp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.Label _consoleLbl;
        private System.Windows.Forms.RichTextBox _deviceHistoryRtb;
        private System.Windows.Forms.TableLayoutPanel _consoleInputTlp;
        private System.Windows.Forms.Label _inputLbl;
        private System.Windows.Forms.TextBox _inputTxt;
        private System.Windows.Forms.Panel _previousCommandsPnl;
    }
}
