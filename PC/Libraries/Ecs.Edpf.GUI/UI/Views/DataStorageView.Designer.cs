namespace Ecs.Edpf.GUI.UI.Views
{
    partial class DataStorageView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._strmPanelsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._addStreamBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._strmPanelsTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._strmPanelsTlp);
            this.splitContainer1.Size = new System.Drawing.Size(1473, 823);
            this.splitContainer1.SplitterDistance = 801;
            this.splitContainer1.TabIndex = 0;
            // 
            // _strmPanelsTlp
            // 
            this._strmPanelsTlp.ColumnCount = 1;
            this._strmPanelsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._strmPanelsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._strmPanelsTlp.Controls.Add(this._addStreamBtn, 0, 1);
            this._strmPanelsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._strmPanelsTlp.Location = new System.Drawing.Point(0, 0);
            this._strmPanelsTlp.Name = "_strmPanelsTlp";
            this._strmPanelsTlp.RowCount = 2;
            this._strmPanelsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._strmPanelsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this._strmPanelsTlp.Size = new System.Drawing.Size(668, 823);
            this._strmPanelsTlp.TabIndex = 0;
            // 
            // _addStreamBtn
            // 
            this._addStreamBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addStreamBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.database_plus;
            this._addStreamBtn.Location = new System.Drawing.Point(3, 701);
            this._addStreamBtn.Name = "_addStreamBtn";
            this._addStreamBtn.Size = new System.Drawing.Size(662, 119);
            this._addStreamBtn.TabIndex = 0;
            this._addStreamBtn.Text = "Add Stream...";
            this._addStreamBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._addStreamBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._addStreamBtn.UseVisualStyleBackColor = true;
            // 
            // DataStorageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "DataStorageView";
            this.Size = new System.Drawing.Size(1473, 823);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this._strmPanelsTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel _strmPanelsTlp;
        private System.Windows.Forms.Button _addStreamBtn;
    }
}
