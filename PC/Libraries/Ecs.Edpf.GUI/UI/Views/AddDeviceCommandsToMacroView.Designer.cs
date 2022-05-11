namespace Ecs.Edpf.GUI.UI.Views
{
    partial class AddDeviceCommandsToMacroView
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
            this._commandsTab = new System.Windows.Forms.TabControl();
            this._executeCmdBtn = new System.Windows.Forms.Button();
            this._mainTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._mainTlp.Controls.Add(this._commandsTab, 0, 0);
            this._mainTlp.Controls.Add(this._executeCmdBtn, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Margin = new System.Windows.Forms.Padding(2);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this._mainTlp.Size = new System.Drawing.Size(547, 397);
            this._mainTlp.TabIndex = 2;
            // 
            // _commandsTab
            // 
            this._commandsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._commandsTab.Location = new System.Drawing.Point(2, 2);
            this._commandsTab.Margin = new System.Windows.Forms.Padding(2);
            this._commandsTab.Name = "_commandsTab";
            this._commandsTab.SelectedIndex = 0;
            this._commandsTab.Size = new System.Drawing.Size(543, 330);
            this._commandsTab.TabIndex = 0;
            // 
            // _executeCmdBtn
            // 
            this._executeCmdBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._executeCmdBtn.Location = new System.Drawing.Point(2, 336);
            this._executeCmdBtn.Margin = new System.Windows.Forms.Padding(2);
            this._executeCmdBtn.Name = "_executeCmdBtn";
            this._executeCmdBtn.Size = new System.Drawing.Size(543, 59);
            this._executeCmdBtn.TabIndex = 1;
            this._executeCmdBtn.Text = "_executeCmdBtn";
            this._executeCmdBtn.UseVisualStyleBackColor = true;
            // 
            // AddDeviceCommandsToMacroView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "AddDeviceCommandsToMacroView";
            this.Size = new System.Drawing.Size(547, 397);
            this._mainTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.TabControl _commandsTab;
        private System.Windows.Forms.Button _executeCmdBtn;
    }
}
