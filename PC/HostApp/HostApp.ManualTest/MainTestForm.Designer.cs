namespace HostApp.ManualTest
{
    partial class MainTestForm
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
            this._controlLbl = new System.Windows.Forms.Label();
            this._ctrlSelectionCbx = new System.Windows.Forms.ComboBox();
            this._mainSpl = new System.Windows.Forms.SplitContainer();
            this._leftTlp = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._ctrlPnl = new System.Windows.Forms.Panel();
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._ctrlSpl = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._connSettingsSpl = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this._deviceCmdsPnl = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this._connectionPnl = new System.Windows.Forms.Panel();
            this._mainTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).BeginInit();
            this._mainSpl.Panel1.SuspendLayout();
            this._mainSpl.Panel2.SuspendLayout();
            this._mainSpl.SuspendLayout();
            this._leftTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlSpl)).BeginInit();
            this._ctrlSpl.Panel1.SuspendLayout();
            this._ctrlSpl.Panel2.SuspendLayout();
            this._ctrlSpl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._connSettingsSpl)).BeginInit();
            this._connSettingsSpl.Panel1.SuspendLayout();
            this._connSettingsSpl.Panel2.SuspendLayout();
            this._connSettingsSpl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.Controls.Add(this._controlLbl, 0, 0);
            this._mainTlp.Controls.Add(this._ctrlSelectionCbx, 0, 1);
            this._mainTlp.Controls.Add(this._mainSpl, 0, 2);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 3;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Size = new System.Drawing.Size(1803, 1190);
            this._mainTlp.TabIndex = 0;
            // 
            // _controlLbl
            // 
            this._controlLbl.AutoSize = true;
            this._controlLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._controlLbl.Location = new System.Drawing.Point(3, 0);
            this._controlLbl.Name = "_controlLbl";
            this._controlLbl.Size = new System.Drawing.Size(200, 25);
            this._controlLbl.TabIndex = 0;
            this._controlLbl.Text = "Control Selection:";
            // 
            // _ctrlSelectionCbx
            // 
            this._ctrlSelectionCbx.FormattingEnabled = true;
            this._ctrlSelectionCbx.Location = new System.Drawing.Point(3, 40);
            this._ctrlSelectionCbx.Name = "_ctrlSelectionCbx";
            this._ctrlSelectionCbx.Size = new System.Drawing.Size(646, 33);
            this._ctrlSelectionCbx.TabIndex = 1;
            // 
            // _mainSpl
            // 
            this._mainSpl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._mainSpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainSpl.Location = new System.Drawing.Point(3, 105);
            this._mainSpl.Name = "_mainSpl";
            // 
            // _mainSpl.Panel1
            // 
            this._mainSpl.Panel1.Controls.Add(this._ctrlSpl);
            // 
            // _mainSpl.Panel2
            // 
            this._mainSpl.Panel2.Controls.Add(this._connSettingsSpl);
            this._mainSpl.Size = new System.Drawing.Size(1797, 1082);
            this._mainSpl.SplitterDistance = 934;
            this._mainSpl.TabIndex = 2;
            // 
            // _leftTlp
            // 
            this._leftTlp.ColumnCount = 1;
            this._leftTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._leftTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._leftTlp.Controls.Add(this.label1, 0, 0);
            this._leftTlp.Controls.Add(this._ctrlPnl, 0, 1);
            this._leftTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._leftTlp.Location = new System.Drawing.Point(0, 0);
            this._leftTlp.Name = "_leftTlp";
            this._leftTlp.RowCount = 2;
            this._leftTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this._leftTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._leftTlp.Size = new System.Drawing.Size(930, 481);
            this._leftTlp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control:";
            // 
            // _ctrlPnl
            // 
            this._ctrlPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlPnl.Location = new System.Drawing.Point(3, 44);
            this._ctrlPnl.Name = "_ctrlPnl";
            this._ctrlPnl.Size = new System.Drawing.Size(924, 434);
            this._ctrlPnl.TabIndex = 2;
            // 
            // _settingsPpg
            // 
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(0, 0);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(924, 546);
            this._settingsPpg.TabIndex = 3;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // _ctrlSpl
            // 
            this._ctrlSpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ctrlSpl.Location = new System.Drawing.Point(0, 0);
            this._ctrlSpl.Name = "_ctrlSpl";
            this._ctrlSpl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _ctrlSpl.Panel1
            // 
            this._ctrlSpl.Panel1.Controls.Add(this._leftTlp);
            // 
            // _ctrlSpl.Panel2
            // 
            this._ctrlSpl.Panel2.Controls.Add(this.tableLayoutPanel1);
            this._ctrlSpl.Size = new System.Drawing.Size(930, 1078);
            this._ctrlSpl.SplitterDistance = 481;
            this._ctrlSpl.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(930, 593);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Control Settings:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._settingsPpg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 546);
            this.panel1.TabIndex = 2;
            // 
            // _connSettingsSpl
            // 
            this._connSettingsSpl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._connSettingsSpl.Location = new System.Drawing.Point(0, 0);
            this._connSettingsSpl.Name = "_connSettingsSpl";
            this._connSettingsSpl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _connSettingsSpl.Panel1
            // 
            this._connSettingsSpl.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // _connSettingsSpl.Panel2
            // 
            this._connSettingsSpl.Panel2.Controls.Add(this.tableLayoutPanel3);
            this._connSettingsSpl.Size = new System.Drawing.Size(855, 1078);
            this._connSettingsSpl.SplitterDistance = 616;
            this._connSettingsSpl.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this._deviceCmdsPnl, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(855, 616);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device Commands:";
            // 
            // _deviceCmdsPnl
            // 
            this._deviceCmdsPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deviceCmdsPnl.Location = new System.Drawing.Point(3, 44);
            this._deviceCmdsPnl.Name = "_deviceCmdsPnl";
            this._deviceCmdsPnl.Size = new System.Drawing.Size(849, 569);
            this._deviceCmdsPnl.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this._connectionPnl, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(855, 458);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Connection:";
            // 
            // _connectionPnl
            // 
            this._connectionPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._connectionPnl.Location = new System.Drawing.Point(3, 44);
            this._connectionPnl.Name = "_connectionPnl";
            this._connectionPnl.Size = new System.Drawing.Size(849, 411);
            this._connectionPnl.TabIndex = 2;
            // 
            // MainTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 1190);
            this.Controls.Add(this._mainTlp);
            this.Name = "MainTestForm";
            this.Text = "Test Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this._mainSpl.Panel1.ResumeLayout(false);
            this._mainSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).EndInit();
            this._mainSpl.ResumeLayout(false);
            this._leftTlp.ResumeLayout(false);
            this._leftTlp.PerformLayout();
            this._ctrlSpl.Panel1.ResumeLayout(false);
            this._ctrlSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ctrlSpl)).EndInit();
            this._ctrlSpl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this._connSettingsSpl.Panel1.ResumeLayout(false);
            this._connSettingsSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._connSettingsSpl)).EndInit();
            this._connSettingsSpl.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.Label _controlLbl;
        private System.Windows.Forms.ComboBox _ctrlSelectionCbx;
        private System.Windows.Forms.SplitContainer _mainSpl;
        private System.Windows.Forms.TableLayoutPanel _leftTlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _ctrlPnl;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.SplitContainer _ctrlSpl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer _connSettingsSpl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel _deviceCmdsPnl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel _connectionPnl;
    }
}

