namespace Ecs.Edpf.GUI.UI.Views
{
    partial class ConnectionView
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
            this.label1 = new System.Windows.Forms.Label();
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._openBtn = new System.Windows.Forms.Button();
            this._closeBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._errMessageTssl = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainTlp.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 2;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._mainTlp.Controls.Add(this.label1, 0, 0);
            this._mainTlp.Controls.Add(this._settingsPpg, 0, 1);
            this._mainTlp.Controls.Add(this._openBtn, 0, 2);
            this._mainTlp.Controls.Add(this._closeBtn, 1, 2);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 3;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this._mainTlp.Size = new System.Drawing.Size(764, 657);
            this._mainTlp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings:";
            // 
            // _settingsPpg
            // 
            this._mainTlp.SetColumnSpan(this._settingsPpg, 2);
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(3, 42);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(758, 535);
            this._settingsPpg.TabIndex = 1;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // _openBtn
            // 
            this._openBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._openBtn.Location = new System.Drawing.Point(3, 583);
            this._openBtn.Name = "_openBtn";
            this._openBtn.Size = new System.Drawing.Size(376, 71);
            this._openBtn.TabIndex = 2;
            this._openBtn.Text = "Open";
            this._openBtn.UseVisualStyleBackColor = true;
            this._openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // _closeBtn
            // 
            this._closeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._closeBtn.Location = new System.Drawing.Point(385, 583);
            this._closeBtn.Name = "_closeBtn";
            this._closeBtn.Size = new System.Drawing.Size(376, 71);
            this._closeBtn.TabIndex = 3;
            this._closeBtn.Text = "Close";
            this._closeBtn.UseVisualStyleBackColor = true;
            this._closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._errMessageTssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 657);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 42);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _errMessageTssl
            // 
            this._errMessageTssl.Name = "_errMessageTssl";
            this._errMessageTssl.Size = new System.Drawing.Size(165, 32);
            this._errMessageTssl.Text = "Error Message";
            // 
            // ConnectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ConnectionView";
            this.Size = new System.Drawing.Size(764, 699);
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.Button _openBtn;
        private System.Windows.Forms.Button _closeBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _errMessageTssl;
    }
}
