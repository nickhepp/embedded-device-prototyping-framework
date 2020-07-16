namespace HostApp.UI.Views
{
    partial class SimpleMainView
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
            this._mainSpl = new System.Windows.Forms.SplitContainer();
            this._leftSpl = new System.Windows.Forms.SplitContainer();
            this._topLeftTlp = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._errorsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._errorsPbx = new System.Windows.Forms.PictureBox();
            this._errorsLbl = new System.Windows.Forms.Label();
            this._tlpBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._deviceHistoryRtb = new System.Windows.Forms.RichTextBox();
            this._consoleInputTlp = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._inputTxt = new System.Windows.Forms.TextBox();
            this._rightTlp = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._connectTlp = new System.Windows.Forms.TableLayoutPanel();
            this._openBtn = new System.Windows.Forms.Button();
            this._closeBtn = new System.Windows.Forms.Button();
            this._cmdsTlp = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).BeginInit();
            this._mainSpl.Panel1.SuspendLayout();
            this._mainSpl.Panel2.SuspendLayout();
            this._mainSpl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._leftSpl)).BeginInit();
            this._leftSpl.Panel1.SuspendLayout();
            this._leftSpl.Panel2.SuspendLayout();
            this._leftSpl.SuspendLayout();
            this._topLeftTlp.SuspendLayout();
            this._errorsTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorsPbx)).BeginInit();
            this._tlpBottomLeft.SuspendLayout();
            this._consoleInputTlp.SuspendLayout();
            this._rightTlp.SuspendLayout();
            this._connectTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainSpl
            // 
            this._mainSpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._mainSpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainSpl.Location = new System.Drawing.Point(0, 0);
            this._mainSpl.Name = "_mainSpl";
            // 
            // _mainSpl.Panel1
            // 
            this._mainSpl.Panel1.Controls.Add(this._leftSpl);
            // 
            // _mainSpl.Panel2
            // 
            this._mainSpl.Panel2.Controls.Add(this._rightTlp);
            this._mainSpl.Size = new System.Drawing.Size(1999, 1246);
            this._mainSpl.SplitterDistance = 1359;
            this._mainSpl.TabIndex = 1;
            // 
            // _leftSpl
            // 
            this._leftSpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._leftSpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._leftSpl.Location = new System.Drawing.Point(0, 0);
            this._leftSpl.Name = "_leftSpl";
            this._leftSpl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _leftSpl.Panel1
            // 
            this._leftSpl.Panel1.Controls.Add(this._topLeftTlp);
            // 
            // _leftSpl.Panel2
            // 
            this._leftSpl.Panel2.Controls.Add(this._tlpBottomLeft);
            this._leftSpl.Size = new System.Drawing.Size(1359, 1246);
            this._leftSpl.SplitterDistance = 864;
            this._leftSpl.TabIndex = 0;
            // 
            // _topLeftTlp
            // 
            this._topLeftTlp.ColumnCount = 1;
            this._topLeftTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._topLeftTlp.Controls.Add(this.label1, 0, 0);
            this._topLeftTlp.Controls.Add(this._settingsPpg, 0, 1);
            this._topLeftTlp.Controls.Add(this._errorsTlp, 0, 2);
            this._topLeftTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._topLeftTlp.Location = new System.Drawing.Point(0, 0);
            this._topLeftTlp.Name = "_topLeftTlp";
            this._topLeftTlp.RowCount = 3;
            this._topLeftTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this._topLeftTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._topLeftTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this._topLeftTlp.Size = new System.Drawing.Size(1357, 862);
            this._topLeftTlp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings:";
            // 
            // _settingsPpg
            // 
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._settingsPpg.LineColor = System.Drawing.SystemColors.ControlDark;
            this._settingsPpg.Location = new System.Drawing.Point(3, 54);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(1351, 722);
            this._settingsPpg.TabIndex = 1;
            this._settingsPpg.ToolbarVisible = false;
            this._settingsPpg.UseCompatibleTextRendering = true;
            // 
            // _errorsTlp
            // 
            this._errorsTlp.ColumnCount = 2;
            this._errorsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this._errorsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._errorsTlp.Controls.Add(this._errorsPbx, 0, 0);
            this._errorsTlp.Controls.Add(this._errorsLbl, 1, 0);
            this._errorsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._errorsTlp.Location = new System.Drawing.Point(3, 782);
            this._errorsTlp.Name = "_errorsTlp";
            this._errorsTlp.RowCount = 1;
            this._errorsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._errorsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this._errorsTlp.Size = new System.Drawing.Size(1351, 77);
            this._errorsTlp.TabIndex = 2;
            // 
            // _errorsPbx
            // 
            this._errorsPbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this._errorsPbx.Image = global::HostApp.Properties.Resources.warning_icon;
            this._errorsPbx.Location = new System.Drawing.Point(0, 0);
            this._errorsPbx.Margin = new System.Windows.Forms.Padding(0);
            this._errorsPbx.Name = "_errorsPbx";
            this._errorsPbx.Size = new System.Drawing.Size(88, 77);
            this._errorsPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._errorsPbx.TabIndex = 0;
            this._errorsPbx.TabStop = false;
            // 
            // _errorsLbl
            // 
            this._errorsLbl.AutoSize = true;
            this._errorsLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._errorsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this._errorsLbl.Location = new System.Drawing.Point(91, 0);
            this._errorsLbl.Name = "_errorsLbl";
            this._errorsLbl.Size = new System.Drawing.Size(1257, 77);
            this._errorsLbl.TabIndex = 1;
            this._errorsLbl.Text = "_errorsLbl";
            this._errorsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _tlpBottomLeft
            // 
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
            this._tlpBottomLeft.Size = new System.Drawing.Size(1357, 376);
            this._tlpBottomLeft.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Console:";
            // 
            // _deviceHistoryRtb
            // 
            this._deviceHistoryRtb.BackColor = System.Drawing.Color.White;
            this._deviceHistoryRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deviceHistoryRtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this._deviceHistoryRtb.Location = new System.Drawing.Point(3, 50);
            this._deviceHistoryRtb.Name = "_deviceHistoryRtb";
            this._deviceHistoryRtb.ReadOnly = true;
            this._deviceHistoryRtb.Size = new System.Drawing.Size(1351, 273);
            this._deviceHistoryRtb.TabIndex = 1;
            this._deviceHistoryRtb.Text = "";
            // 
            // _consoleInputTlp
            // 
            this._consoleInputTlp.ColumnCount = 2;
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this._consoleInputTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.Controls.Add(this.label4, 0, 0);
            this._consoleInputTlp.Controls.Add(this._inputTxt, 1, 0);
            this._consoleInputTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._consoleInputTlp.Location = new System.Drawing.Point(3, 329);
            this._consoleInputTlp.Name = "_consoleInputTlp";
            this._consoleInputTlp.RowCount = 1;
            this._consoleInputTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._consoleInputTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._consoleInputTlp.Size = new System.Drawing.Size(1351, 44);
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
            this._inputTxt.Size = new System.Drawing.Size(1266, 31);
            this._inputTxt.TabIndex = 1;
            // 
            // _rightTlp
            // 
            this._rightTlp.ColumnCount = 1;
            this._rightTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rightTlp.Controls.Add(this.label5, 0, 2);
            this._rightTlp.Controls.Add(this.label2, 0, 0);
            this._rightTlp.Controls.Add(this._connectTlp, 0, 3);
            this._rightTlp.Controls.Add(this._cmdsTlp, 0, 1);
            this._rightTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rightTlp.Location = new System.Drawing.Point(0, 0);
            this._rightTlp.Name = "_rightTlp";
            this._rightTlp.RowCount = 4;
            this._rightTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this._rightTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._rightTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this._rightTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this._rightTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._rightTlp.Size = new System.Drawing.Size(634, 1244);
            this._rightTlp.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 1124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 42);
            this.label5.TabIndex = 3;
            this.label5.Text = "Connection:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Commands:";
            // 
            // _connectTlp
            // 
            this._connectTlp.ColumnCount = 2;
            this._connectTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._connectTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._connectTlp.Controls.Add(this._openBtn, 0, 0);
            this._connectTlp.Controls.Add(this._closeBtn, 1, 0);
            this._connectTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._connectTlp.Location = new System.Drawing.Point(3, 1171);
            this._connectTlp.Name = "_connectTlp";
            this._connectTlp.RowCount = 1;
            this._connectTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._connectTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this._connectTlp.Size = new System.Drawing.Size(628, 70);
            this._connectTlp.TabIndex = 2;
            // 
            // _openBtn
            // 
            this._openBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._openBtn.Location = new System.Drawing.Point(3, 3);
            this._openBtn.Name = "_openBtn";
            this._openBtn.Size = new System.Drawing.Size(308, 64);
            this._openBtn.TabIndex = 0;
            this._openBtn.Text = "Open";
            this._openBtn.UseVisualStyleBackColor = true;
            // 
            // _closeBtn
            // 
            this._closeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._closeBtn.Location = new System.Drawing.Point(317, 3);
            this._closeBtn.Name = "_closeBtn";
            this._closeBtn.Size = new System.Drawing.Size(308, 64);
            this._closeBtn.TabIndex = 1;
            this._closeBtn.Text = "Close";
            this._closeBtn.UseVisualStyleBackColor = true;
            // 
            // _cmdsTlp
            // 
            this._cmdsTlp.ColumnCount = 1;
            this._cmdsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._cmdsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._cmdsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cmdsTlp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F);
            this._cmdsTlp.Location = new System.Drawing.Point(3, 52);
            this._cmdsTlp.Name = "_cmdsTlp";
            this._cmdsTlp.RowCount = 1;
            this._cmdsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._cmdsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 751F));
            this._cmdsTlp.Size = new System.Drawing.Size(628, 1069);
            this._cmdsTlp.TabIndex = 4;
            // 
            // SimpleMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainSpl);
            this.Name = "SimpleMainView";
            this.Size = new System.Drawing.Size(1999, 1246);
            this._mainSpl.Panel1.ResumeLayout(false);
            this._mainSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).EndInit();
            this._mainSpl.ResumeLayout(false);
            this._leftSpl.Panel1.ResumeLayout(false);
            this._leftSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._leftSpl)).EndInit();
            this._leftSpl.ResumeLayout(false);
            this._topLeftTlp.ResumeLayout(false);
            this._topLeftTlp.PerformLayout();
            this._errorsTlp.ResumeLayout(false);
            this._errorsTlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorsPbx)).EndInit();
            this._tlpBottomLeft.ResumeLayout(false);
            this._tlpBottomLeft.PerformLayout();
            this._consoleInputTlp.ResumeLayout(false);
            this._consoleInputTlp.PerformLayout();
            this._rightTlp.ResumeLayout(false);
            this._rightTlp.PerformLayout();
            this._connectTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _mainSpl;
        private System.Windows.Forms.SplitContainer _leftSpl;
        private System.Windows.Forms.TableLayoutPanel _topLeftTlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.TableLayoutPanel _errorsTlp;
        private System.Windows.Forms.PictureBox _errorsPbx;
        private System.Windows.Forms.Label _errorsLbl;
        private System.Windows.Forms.TableLayoutPanel _tlpBottomLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox _deviceHistoryRtb;
        private System.Windows.Forms.TableLayoutPanel _consoleInputTlp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _inputTxt;
        private System.Windows.Forms.TableLayoutPanel _rightTlp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel _connectTlp;
        private System.Windows.Forms.Button _openBtn;
        private System.Windows.Forms.Button _closeBtn;
        private System.Windows.Forms.TableLayoutPanel _cmdsTlp;
    }
}
