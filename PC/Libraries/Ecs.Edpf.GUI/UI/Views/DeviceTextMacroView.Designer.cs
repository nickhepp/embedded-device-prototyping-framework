
namespace Ecs.Edpf.GUI.UI.Views
{
    partial class DeviceTextMacroView
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
            this._macroProgressPbr = new System.Windows.Forms.ProgressBar();
            this._settingsPpg = new System.Windows.Forms.PropertyGrid();
            this._buttonsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._oneShotBtn = new System.Windows.Forms.Button();
            this._loopBtn = new System.Windows.Forms.Button();
            this._recordPlayBtn = new System.Windows.Forms.Button();
            this._mainTlp.SuspendLayout();
            this._buttonsTlp.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Controls.Add(this._macroProgressPbr, 0, 2);
            this._mainTlp.Controls.Add(this._settingsPpg, 0, 0);
            this._mainTlp.Controls.Add(this._buttonsTlp, 0, 1);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 0);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 3;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this._mainTlp.Size = new System.Drawing.Size(1036, 741);
            this._mainTlp.TabIndex = 0;
            // 
            // _macroProgressPbr
            // 
            this._macroProgressPbr.Dock = System.Windows.Forms.DockStyle.Fill;
            this._macroProgressPbr.Location = new System.Drawing.Point(3, 662);
            this._macroProgressPbr.Name = "_macroProgressPbr";
            this._macroProgressPbr.Size = new System.Drawing.Size(1030, 76);
            this._macroProgressPbr.TabIndex = 0;
            // 
            // _settingsPpg
            // 
            this._settingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._settingsPpg.Location = new System.Drawing.Point(3, 3);
            this._settingsPpg.Name = "_settingsPpg";
            this._settingsPpg.Size = new System.Drawing.Size(1030, 497);
            this._settingsPpg.TabIndex = 1;
            this._settingsPpg.ToolbarVisible = false;
            // 
            // _buttonsTlp
            // 
            this._buttonsTlp.ColumnCount = 7;
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99981F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00005F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00007F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00007F));
            this._buttonsTlp.Controls.Add(this._oneShotBtn, 3, 0);
            this._buttonsTlp.Controls.Add(this._loopBtn, 5, 0);
            this._buttonsTlp.Controls.Add(this._recordPlayBtn, 1, 0);
            this._buttonsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTlp.Location = new System.Drawing.Point(3, 506);
            this._buttonsTlp.Name = "_buttonsTlp";
            this._buttonsTlp.RowCount = 1;
            this._buttonsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsTlp.Size = new System.Drawing.Size(1030, 150);
            this._buttonsTlp.TabIndex = 2;
            // 
            // _oneShotBtn
            // 
            this._oneShotBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._oneShotBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._oneShotBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.repeat_one_64x64;
            this._oneShotBtn.Location = new System.Drawing.Point(434, 3);
            this._oneShotBtn.Name = "_oneShotBtn";
            this._oneShotBtn.Size = new System.Drawing.Size(159, 144);
            this._oneShotBtn.TabIndex = 0;
            this._oneShotBtn.Text = "One Shot";
            this._oneShotBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._oneShotBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._oneShotBtn.UseVisualStyleBackColor = true;
            // 
            // _loopBtn
            // 
            this._loopBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loopBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.repeat_64x64;
            this._loopBtn.Location = new System.Drawing.Point(732, 3);
            this._loopBtn.Name = "_loopBtn";
            this._loopBtn.Size = new System.Drawing.Size(159, 144);
            this._loopBtn.TabIndex = 1;
            this._loopBtn.Text = "Loop";
            this._loopBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._loopBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._loopBtn.UseVisualStyleBackColor = true;
            // 
            // _recordPlayBtn
            // 
            this._recordPlayBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._recordPlayBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.record_64x64;
            this._recordPlayBtn.Location = new System.Drawing.Point(136, 3);
            this._recordPlayBtn.Name = "_recordPlayBtn";
            this._recordPlayBtn.Size = new System.Drawing.Size(159, 144);
            this._recordPlayBtn.TabIndex = 2;
            this._recordPlayBtn.Text = "Record";
            this._recordPlayBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._recordPlayBtn.UseVisualStyleBackColor = true;
            // 
            // DeviceTextMacroView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Name = "DeviceTextMacroView";
            this.Size = new System.Drawing.Size(1036, 741);
            this._mainTlp.ResumeLayout(false);
            this._buttonsTlp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.ProgressBar _macroProgressPbr;
        private System.Windows.Forms.PropertyGrid _settingsPpg;
        private System.Windows.Forms.TableLayoutPanel _buttonsTlp;
        private System.Windows.Forms.Button _oneShotBtn;
        private System.Windows.Forms.Button _loopBtn;
        private System.Windows.Forms.Button _recordPlayBtn;
    }
}
