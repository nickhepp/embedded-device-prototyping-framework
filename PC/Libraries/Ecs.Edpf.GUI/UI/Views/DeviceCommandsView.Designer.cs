namespace Ecs.Edpf.GUI.UI.Views
{
    partial class DeviceCommandsView
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
            this._commandsTab = new System.Windows.Forms.TabControl();
            this._mainTlp = new System.Windows.Forms.TableLayoutPanel();
            this._executeCmdBtn = new System.Windows.Forms.Button();
            this._mainTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _commandsTab
            // 
            this._commandsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this._commandsTab.Location = new System.Drawing.Point(3, 3);
            this._commandsTab.Name = "_commandsTab";
            this._commandsTab.SelectedIndex = 0;
            this._commandsTab.Size = new System.Drawing.Size(964, 699);
            this._commandsTab.TabIndex = 0;
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Controls.Add(this._commandsTab, 0, 0);
            this._mainTlp.Controls.Add(this._executeCmdBtn, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this._mainTlp.Size = new System.Drawing.Size(970, 826);
            this._mainTlp.TabIndex = 1;
            // 
            // _executeCmdBtn
            // 
            this._executeCmdBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._executeCmdBtn.Location = new System.Drawing.Point(3, 708);
            this._executeCmdBtn.Name = "_executeCmdBtn";
            this._executeCmdBtn.Size = new System.Drawing.Size(964, 115);
            this._executeCmdBtn.TabIndex = 1;
            this._executeCmdBtn.Text = "_executeCmdBtn";
            this._executeCmdBtn.UseVisualStyleBackColor = true;
            this._executeCmdBtn.Click += new System.EventHandler(this._executeCmdBtn_Click);
            // 
            // DeviceCommandsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "DeviceCommandsView";
            this.Size = new System.Drawing.Size(970, 826);
            this._mainTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _commandsTab;
        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.Button _executeCmdBtn;
    }
}
