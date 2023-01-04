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
            this._strmPanelsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._btnsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._recordPauseAllBtn = new System.Windows.Forms.Button();
            this._addStreamBtn = new System.Windows.Forms.Button();
            this._removeStreamsBtn = new System.Windows.Forms.Button();
            this._streamsFlp = new System.Windows.Forms.FlowLayoutPanel();
            this._strmPanelsTlp.SuspendLayout();
            this._btnsTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _strmPanelsTlp
            // 
            this._strmPanelsTlp.ColumnCount = 1;
            this._strmPanelsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._strmPanelsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._strmPanelsTlp.Controls.Add(this._btnsTlp, 0, 1);
            this._strmPanelsTlp.Controls.Add(this._streamsFlp, 0, 0);
            this._strmPanelsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._strmPanelsTlp.Location = new System.Drawing.Point(0, 0);
            this._strmPanelsTlp.Name = "_strmPanelsTlp";
            this._strmPanelsTlp.RowCount = 2;
            this._strmPanelsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._strmPanelsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this._strmPanelsTlp.Size = new System.Drawing.Size(1473, 823);
            this._strmPanelsTlp.TabIndex = 0;
            // 
            // _btnsTlp
            // 
            this._btnsTlp.ColumnCount = 5;
            this._btnsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._btnsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._btnsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._btnsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._btnsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this._btnsTlp.Controls.Add(this._addStreamBtn, 2, 0);
            this._btnsTlp.Controls.Add(this._recordPauseAllBtn, 0, 0);
            this._btnsTlp.Controls.Add(this._removeStreamsBtn, 4, 0);
            this._btnsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._btnsTlp.Location = new System.Drawing.Point(3, 666);
            this._btnsTlp.Name = "_btnsTlp";
            this._btnsTlp.RowCount = 1;
            this._btnsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._btnsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this._btnsTlp.Size = new System.Drawing.Size(1467, 154);
            this._btnsTlp.TabIndex = 0;
            // 
            // _recordPauseAllBtn
            // 
            this._recordPauseAllBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._recordPauseAllBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.record_64x64;
            this._recordPauseAllBtn.Location = new System.Drawing.Point(3, 3);
            this._recordPauseAllBtn.Name = "_recordPauseAllBtn";
            this._recordPauseAllBtn.Size = new System.Drawing.Size(469, 148);
            this._recordPauseAllBtn.TabIndex = 1;
            this._recordPauseAllBtn.Text = "Record All";
            this._recordPauseAllBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._recordPauseAllBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._recordPauseAllBtn.UseVisualStyleBackColor = true;
            this._recordPauseAllBtn.Click += new System.EventHandler(this._recordPauseAllBtn_Click);
            // 
            // _addStreamBtn
            // 
            this._addStreamBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addStreamBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.database_plus_64x64;
            this._addStreamBtn.Location = new System.Drawing.Point(498, 3);
            this._addStreamBtn.Name = "_addStreamBtn";
            this._addStreamBtn.Size = new System.Drawing.Size(469, 148);
            this._addStreamBtn.TabIndex = 0;
            this._addStreamBtn.Text = "Add Stream...";
            this._addStreamBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._addStreamBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._addStreamBtn.UseVisualStyleBackColor = true;
            this._addStreamBtn.Click += new System.EventHandler(this._addStreamBtn_Click);
            // 
            // _removeStreamsBtn
            // 
            this._removeStreamsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._removeStreamsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._removeStreamsBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.trash_xmark_64x64;
            this._removeStreamsBtn.Location = new System.Drawing.Point(993, 3);
            this._removeStreamsBtn.Name = "_removeStreamsBtn";
            this._removeStreamsBtn.Size = new System.Drawing.Size(471, 148);
            this._removeStreamsBtn.TabIndex = 2;
            this._removeStreamsBtn.Text = "Remove Streams...";
            this._removeStreamsBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._removeStreamsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._removeStreamsBtn.UseVisualStyleBackColor = true;
            this._removeStreamsBtn.Click += new System.EventHandler(this._removeStreamsBtn_Click);
            // 
            // _streamsFlp
            // 
            this._streamsFlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._streamsFlp.Location = new System.Drawing.Point(3, 3);
            this._streamsFlp.Name = "_streamsFlp";
            this._streamsFlp.Size = new System.Drawing.Size(1467, 657);
            this._streamsFlp.TabIndex = 1;
            // 
            // DataStorageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._strmPanelsTlp);
            this.Name = "DataStorageView";
            this.Size = new System.Drawing.Size(1473, 823);
            this._strmPanelsTlp.ResumeLayout(false);
            this._btnsTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _strmPanelsTlp;
        private System.Windows.Forms.Button _addStreamBtn;
        private System.Windows.Forms.TableLayoutPanel _btnsTlp;
        private System.Windows.Forms.Button _recordPauseAllBtn;
        private System.Windows.Forms.Button _removeStreamsBtn;
        private System.Windows.Forms.FlowLayoutPanel _streamsFlp;
    }
}
