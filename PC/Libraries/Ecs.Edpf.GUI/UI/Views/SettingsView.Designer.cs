
namespace Ecs.Edpf.GUI.UI.Views
{
    partial class SettingsView
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
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._okBtn = new System.Windows.Forms.Button();
            this._cancelBtn = new System.Windows.Forms.Button();
            this._mainTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 2;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.Controls.Add(this._settingsPpg, 0, 0);
            this._mainTlp.Controls.Add(this._okBtn, 0, 1);
            this._mainTlp.Controls.Add(this._cancelBtn, 1, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this._mainTlp.Size = new System.Drawing.Size(926, 610);
            this._mainTlp.TabIndex = 0;
            // 
            // _settingsPpg
            // 
            this._mainTlp.SetColumnSpan(this._settingsPpg, 2);
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(3, 3);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(920, 504);
            this._settingsPpg.TabIndex = 0;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // _okBtn
            // 
            this._okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._okBtn.Location = new System.Drawing.Point(3, 513);
            this._okBtn.Name = "_okBtn";
            this._okBtn.Size = new System.Drawing.Size(457, 94);
            this._okBtn.TabIndex = 1;
            this._okBtn.Text = "OK";
            this._okBtn.UseVisualStyleBackColor = true;
            // 
            // _cancelBtn
            // 
            this._cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelBtn.Location = new System.Drawing.Point(466, 513);
            this._cancelBtn.Name = "_cancelBtn";
            this._cancelBtn.Size = new System.Drawing.Size(457, 94);
            this._cancelBtn.TabIndex = 2;
            this._cancelBtn.Text = "Cancel";
            this._cancelBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 610);
            this.Controls.Add(this._mainTlp);
            this.Name = "SettingsView";
            this.Text = "SettingsView";
            this._mainTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.Button _okBtn;
        private System.Windows.Forms.Button _cancelBtn;
    }
}