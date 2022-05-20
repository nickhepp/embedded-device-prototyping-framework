namespace Ecs.Edpf.GUI.UI.Views
{
    partial class LoggerView
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
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._saveSettingsBtn = new System.Windows.Forms.Button();
            this._mainTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.Controls.Add(this._settingsPpg, 0, 0);
            this._mainTlp.Controls.Add(this._saveSettingsBtn, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this._mainTlp.Size = new System.Drawing.Size(657, 688);
            this._mainTlp.TabIndex = 0;
            // 
            // _settingsPpg
            // 
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(3, 3);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(651, 562);
            this._settingsPpg.TabIndex = 0;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // _saveSettingsBtn
            // 
            this._saveSettingsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveSettingsBtn.Location = new System.Drawing.Point(3, 571);
            this._saveSettingsBtn.Name = "_saveSettingsBtn";
            this._saveSettingsBtn.Size = new System.Drawing.Size(651, 114);
            this._saveSettingsBtn.TabIndex = 1;
            this._saveSettingsBtn.Text = "Save Settings";
            this._saveSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // LoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "LoggerView";
            this.Size = new System.Drawing.Size(657, 688);
            this._mainTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.Button _saveSettingsBtn;
    }
}
