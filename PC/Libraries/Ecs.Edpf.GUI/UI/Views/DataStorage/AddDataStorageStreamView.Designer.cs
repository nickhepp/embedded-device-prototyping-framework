namespace Ecs.Edpf.GUI.UI.Views.DataStorage
{
    partial class AddDataStorageStreamView
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
            this.label1 = new System.Windows.Forms.Label();
            this._buttonsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._okBtn = new System.Windows.Forms.Button();
            this._cancelBtn = new System.Windows.Forms.Button();
            this._comboBoxPnl = new System.Windows.Forms.Panel();
            this._mainTlp.SuspendLayout();
            this._buttonsTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.Controls.Add(this.label1, 0, 0);
            this._mainTlp.Controls.Add(this._buttonsTlp, 0, 3);
            this._mainTlp.Controls.Add(this._comboBoxPnl, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 4;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this._mainTlp.Size = new System.Drawing.Size(1061, 780);
            this._mainTlp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stream Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // _buttonsTlp
            // 
            this._buttonsTlp.ColumnCount = 3;
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonsTlp.Controls.Add(this._okBtn, 0, 0);
            this._buttonsTlp.Controls.Add(this._cancelBtn, 2, 0);
            this._buttonsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTlp.Location = new System.Drawing.Point(3, 698);
            this._buttonsTlp.Name = "_buttonsTlp";
            this._buttonsTlp.RowCount = 1;
            this._buttonsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._buttonsTlp.Size = new System.Drawing.Size(1055, 79);
            this._buttonsTlp.TabIndex = 2;
            // 
            // _okBtn
            // 
            this._okBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._okBtn.Location = new System.Drawing.Point(3, 3);
            this._okBtn.Name = "_okBtn";
            this._okBtn.Size = new System.Drawing.Size(516, 73);
            this._okBtn.TabIndex = 0;
            this._okBtn.Text = "OK";
            this._okBtn.UseVisualStyleBackColor = true;
            // 
            // _cancelBtn
            // 
            this._cancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelBtn.Location = new System.Drawing.Point(535, 3);
            this._cancelBtn.Name = "_cancelBtn";
            this._cancelBtn.Size = new System.Drawing.Size(517, 73);
            this._cancelBtn.TabIndex = 1;
            this._cancelBtn.Text = "Cancel";
            this._cancelBtn.UseVisualStyleBackColor = true;
            // 
            // _comboBoxPnl
            // 
            this._comboBoxPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._comboBoxPnl.Location = new System.Drawing.Point(3, 68);
            this._comboBoxPnl.Name = "_comboBoxPnl";
            this._comboBoxPnl.Size = new System.Drawing.Size(1055, 61);
            this._comboBoxPnl.TabIndex = 3;
            // 
            // AddDataStorageStreamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 780);
            this.Controls.Add(this._mainTlp);
            this.Name = "AddDataStorageStreamView";
            this.Text = "Add Data Storage Stream";
            this._mainTlp.ResumeLayout(false);
            this._mainTlp.PerformLayout();
            this._buttonsTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel _buttonsTlp;
        private System.Windows.Forms.Button _okBtn;
        private System.Windows.Forms.Button _cancelBtn;
        private System.Windows.Forms.Panel _comboBoxPnl;
    }
}