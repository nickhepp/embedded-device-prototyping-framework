
namespace HostApp.UI.Views
{
    partial class ToolBoxView
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
            this._mainLvw = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _mainLvw
            // 
            this._mainLvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainLvw.HideSelection = false;
            this._mainLvw.Location = new System.Drawing.Point(0, 0);
            this._mainLvw.Name = "_mainLvw";
            this._mainLvw.Size = new System.Drawing.Size(325, 445);
            this._mainLvw.TabIndex = 0;
            this._mainLvw.UseCompatibleStateImageBehavior = false;
            // 
            // ToolBoxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainLvw);
            this.Name = "ToolBoxView";
            this.Size = new System.Drawing.Size(325, 445);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _mainLvw;
    }
}
