﻿namespace Ecs.Edpf.GUI.UI.Views
{
    partial class ConnectionsView
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
            this._connectionsTbctrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._connectionsTbctrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _connectionsTbctrl
            // 
            this._connectionsTbctrl.Controls.Add(this.tabPage1);
            this._connectionsTbctrl.Controls.Add(this.tabPage2);
            this._connectionsTbctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._connectionsTbctrl.Location = new System.Drawing.Point(0, 0);
            this._connectionsTbctrl.Name = "_connectionsTbctrl";
            this._connectionsTbctrl.SelectedIndex = 0;
            this._connectionsTbctrl.Size = new System.Drawing.Size(1047, 857);
            this._connectionsTbctrl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1031, 810);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(184, 53);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ConnectionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._connectionsTbctrl);
            this.Name = "ConnectionsView";
            this.Size = new System.Drawing.Size(1047, 857);
            this._connectionsTbctrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _connectionsTbctrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
