namespace Ecs.Edpf.GUI.UI.Views
{
    partial class DataStorageStreamView
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
            this._buttonsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._typeNameLbl = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._streamRtb = new System.Windows.Forms.RichTextBox();
            this._settingsBtn = new System.Windows.Forms.Button();
            this._recordPauseBtn = new System.Windows.Forms.Button();
            this._removeBtn = new System.Windows.Forms.Button();
            this._successIndicatorTssl = new System.Windows.Forms.ToolStripStatusLabel();
            this._failIndicatorTssl = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainTlp.SuspendLayout();
            this._buttonsTlp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Controls.Add(this._buttonsTlp, 0, 2);
            this._mainTlp.Controls.Add(this._typeNameLbl, 0, 0);
            this._mainTlp.Controls.Add(this._streamRtb, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 3;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this._mainTlp.Size = new System.Drawing.Size(834, 417);
            this._mainTlp.TabIndex = 0;
            // 
            // _buttonsTlp
            // 
            this._buttonsTlp.ColumnCount = 5;
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._buttonsTlp.Controls.Add(this._recordPauseBtn, 0, 0);
            this._buttonsTlp.Controls.Add(this._removeBtn, 4, 0);
            this._buttonsTlp.Controls.Add(this._settingsBtn, 2, 0);
            this._buttonsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTlp.Location = new System.Drawing.Point(3, 330);
            this._buttonsTlp.Name = "_buttonsTlp";
            this._buttonsTlp.RowCount = 1;
            this._buttonsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsTlp.Size = new System.Drawing.Size(828, 84);
            this._buttonsTlp.TabIndex = 0;
            // 
            // _typeNameLbl
            // 
            this._typeNameLbl.AutoSize = true;
            this._typeNameLbl.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._typeNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._typeNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._typeNameLbl.ForeColor = System.Drawing.Color.White;
            this._typeNameLbl.Location = new System.Drawing.Point(0, 0);
            this._typeNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this._typeNameLbl.Name = "_typeNameLbl";
            this._typeNameLbl.Size = new System.Drawing.Size(834, 51);
            this._typeNameLbl.TabIndex = 1;
            this._typeNameLbl.Text = "<type>: <name>";
            this._typeNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._successIndicatorTssl,
            this._failIndicatorTssl});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 42);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _streamRtb
            // 
            this._streamRtb.BackColor = System.Drawing.Color.Black;
            this._streamRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._streamRtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.85F);
            this._streamRtb.ForeColor = System.Drawing.Color.White;
            this._streamRtb.Location = new System.Drawing.Point(3, 51);
            this._streamRtb.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this._streamRtb.Name = "_streamRtb";
            this._streamRtb.ReadOnly = true;
            this._streamRtb.Size = new System.Drawing.Size(828, 273);
            this._streamRtb.TabIndex = 2;
            this._streamRtb.Text = "$ This is test text";
            // 
            // _settingsBtn
            // 
            this._settingsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.sliders_v_square_64x64;
            this._settingsBtn.Location = new System.Drawing.Point(285, 3);
            this._settingsBtn.Name = "_settingsBtn";
            this._settingsBtn.Size = new System.Drawing.Size(256, 78);
            this._settingsBtn.TabIndex = 2;
            this._settingsBtn.Text = "Settings";
            this._settingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._settingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._settingsBtn.UseVisualStyleBackColor = true;
            this._settingsBtn.Click += new System.EventHandler(this._settingsBtn_Click);
            // 
            // _recordPauseBtn
            // 
            this._recordPauseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._recordPauseBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.record_64x64;
            this._recordPauseBtn.Location = new System.Drawing.Point(3, 3);
            this._recordPauseBtn.Name = "_recordPauseBtn";
            this._recordPauseBtn.Size = new System.Drawing.Size(256, 78);
            this._recordPauseBtn.TabIndex = 0;
            this._recordPauseBtn.Text = "Record";
            this._recordPauseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._recordPauseBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._recordPauseBtn.UseVisualStyleBackColor = true;
            this._recordPauseBtn.Click += new System.EventHandler(this._recordPauseBtn_Click);
            // 
            // _removeBtn
            // 
            this._removeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._removeBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.trash_xmark_64x64;
            this._removeBtn.Location = new System.Drawing.Point(567, 3);
            this._removeBtn.Name = "_removeBtn";
            this._removeBtn.Size = new System.Drawing.Size(258, 78);
            this._removeBtn.TabIndex = 1;
            this._removeBtn.Text = "Remove";
            this._removeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._removeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._removeBtn.UseVisualStyleBackColor = true;
            this._removeBtn.Click += new System.EventHandler(this._removeBtn_Click);
            // 
            // _successIndicatorTssl
            // 
            this._successIndicatorTssl.Image = global::Ecs.Edpf.GUI.Properties.Resources.circle_check_green_black;
            this._successIndicatorTssl.Name = "_successIndicatorTssl";
            this._successIndicatorTssl.Size = new System.Drawing.Size(204, 32);
            this._successIndicatorTssl.Text = "# results saved";
            // 
            // _failIndicatorTssl
            // 
            this._failIndicatorTssl.Image = global::Ecs.Edpf.GUI.Properties.Resources.circle_xmark_red_x_64x64;
            this._failIndicatorTssl.Name = "_failIndicatorTssl";
            this._failIndicatorTssl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._failIndicatorTssl.Size = new System.Drawing.Size(202, 32);
            this._failIndicatorTssl.Text = "# results failed";
            // 
            // DataStorageStreamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DataStorageStreamView";
            this.Size = new System.Drawing.Size(834, 459);
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this._buttonsTlp.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.TableLayoutPanel _buttonsTlp;
        private System.Windows.Forms.Button _recordPauseBtn;
        private System.Windows.Forms.Button _removeBtn;
        private System.Windows.Forms.Label _typeNameLbl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _successIndicatorTssl;
        private System.Windows.Forms.ToolStripStatusLabel _failIndicatorTssl;
        private System.Windows.Forms.Button _settingsBtn;
        private System.Windows.Forms.RichTextBox _streamRtb;
    }
}
