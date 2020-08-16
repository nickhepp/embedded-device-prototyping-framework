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
            this._tabCtrl = new System.Windows.Forms.TabControl();
            this._connectionTpg = new System.Windows.Forms.TabPage();
            this._settingsTpg = new System.Windows.Forms.TabPage();
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._mainTlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).BeginInit();
            this._mainSpl.Panel1.SuspendLayout();
            this._mainSpl.Panel2.SuspendLayout();
            this._mainSpl.SuspendLayout();
            this._leftTlp.SuspendLayout();
            this._tabCtrl.SuspendLayout();
            this._settingsTpg.SuspendLayout();
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
            this._mainSpl.Panel1.Controls.Add(this._leftTlp);
            // 
            // _mainSpl.Panel2
            // 
            this._mainSpl.Panel2.Controls.Add(this._tabCtrl);
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
            this._leftTlp.Size = new System.Drawing.Size(930, 1078);
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
            this._ctrlPnl.Size = new System.Drawing.Size(924, 1031);
            this._ctrlPnl.TabIndex = 2;
            // 
            // _tabCtrl
            // 
            this._tabCtrl.Controls.Add(this._connectionTpg);
            this._tabCtrl.Controls.Add(this._settingsTpg);
            this._tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabCtrl.Location = new System.Drawing.Point(0, 0);
            this._tabCtrl.Name = "_tabCtrl";
            this._tabCtrl.SelectedIndex = 0;
            this._tabCtrl.Size = new System.Drawing.Size(855, 1078);
            this._tabCtrl.TabIndex = 2;
            // 
            // _connectionTpg
            // 
            this._connectionTpg.Location = new System.Drawing.Point(8, 39);
            this._connectionTpg.Name = "_connectionTpg";
            this._connectionTpg.Padding = new System.Windows.Forms.Padding(3);
            this._connectionTpg.Size = new System.Drawing.Size(839, 1031);
            this._connectionTpg.TabIndex = 0;
            this._connectionTpg.Text = "Connection";
            this._connectionTpg.UseVisualStyleBackColor = true;
            // 
            // _settingsTpg
            // 
            this._settingsTpg.Controls.Add(this._settingsPpg);
            this._settingsTpg.Location = new System.Drawing.Point(8, 39);
            this._settingsTpg.Name = "_settingsTpg";
            this._settingsTpg.Padding = new System.Windows.Forms.Padding(3);
            this._settingsTpg.Size = new System.Drawing.Size(839, 1031);
            this._settingsTpg.TabIndex = 1;
            this._settingsTpg.Text = "Control Settings";
            this._settingsTpg.UseVisualStyleBackColor = true;
            // 
            // _settingsPpg
            // 
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(3, 3);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(833, 1025);
            this._settingsPpg.TabIndex = 3;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // MainTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 1190);
            this.Controls.Add(this._mainTlp);
            this.Name = "MainTestForm";
            this.Text = "Test Form";
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this._mainSpl.Panel1.ResumeLayout(false);
            this._mainSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).EndInit();
            this._mainSpl.ResumeLayout(false);
            this._leftTlp.ResumeLayout(false);
            this._leftTlp.PerformLayout();
            this._tabCtrl.ResumeLayout(false);
            this._settingsTpg.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl _tabCtrl;
        private System.Windows.Forms.TabPage _connectionTpg;
        private System.Windows.Forms.TabPage _settingsTpg;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
    }
}

