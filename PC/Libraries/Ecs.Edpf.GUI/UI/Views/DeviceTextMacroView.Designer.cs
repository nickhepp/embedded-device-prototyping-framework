
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceTextMacroView));
            this._mainTlp = new System.Windows.Forms.TableLayoutPanel();
            this._buttonsTlp = new System.Windows.Forms.TableLayoutPanel();
            this._oneShotBtn = new System.Windows.Forms.Button();
            this._loopBtn = new System.Windows.Forms.Button();
            this._stopBtn = new System.Windows.Forms.Button();
            this._scriptRtb = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._uploadScriptTsb = new System.Windows.Forms.ToolStripButton();
            this._downloadScriptTsb = new System.Windows.Forms.ToolStripButton();
            this._lockTsl = new System.Windows.Forms.ToolStripLabel();
            this._unlockTsl = new System.Windows.Forms.ToolStripLabel();
            this._progressTspgbr = new System.Windows.Forms.ToolStripProgressBar();
            this._loadDemoScriptTsb = new System.Windows.Forms.ToolStripButton();
            this._mainTlp.SuspendLayout();
            this._buttonsTlp.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainTlp
            // 
            this._mainTlp.ColumnCount = 1;
            this._mainTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.Controls.Add(this._buttonsTlp, 0, 1);
            this._mainTlp.Controls.Add(this._scriptRtb, 0, 0);
            this._mainTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainTlp.Location = new System.Drawing.Point(0, 50);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._mainTlp.Size = new System.Drawing.Size(1036, 691);
            this._mainTlp.TabIndex = 0;
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
            this._buttonsTlp.Controls.Add(this._loopBtn, 1, 0);
            this._buttonsTlp.Controls.Add(this._stopBtn, 5, 0);
            this._buttonsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTlp.Location = new System.Drawing.Point(3, 538);
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
            this._loopBtn.Location = new System.Drawing.Point(136, 3);
            this._loopBtn.Name = "_loopBtn";
            this._loopBtn.Size = new System.Drawing.Size(159, 144);
            this._loopBtn.TabIndex = 1;
            this._loopBtn.Text = "Loop";
            this._loopBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._loopBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._loopBtn.UseVisualStyleBackColor = true;
            // 
            // _stopBtn
            // 
            this._stopBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._stopBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.pause;
            this._stopBtn.Location = new System.Drawing.Point(732, 3);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(159, 144);
            this._stopBtn.TabIndex = 2;
            this._stopBtn.Text = "Stop";
            this._stopBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._stopBtn.UseVisualStyleBackColor = true;
            // 
            // _scriptRtb
            // 
            this._scriptRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scriptRtb.Location = new System.Drawing.Point(3, 3);
            this._scriptRtb.Name = "_scriptRtb";
            this._scriptRtb.Size = new System.Drawing.Size(1030, 529);
            this._scriptRtb.TabIndex = 3;
            this._scriptRtb.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._uploadScriptTsb,
            this._downloadScriptTsb,
            this._lockTsl,
            this._unlockTsl,
            this._progressTspgbr,
            this._loadDemoScriptTsb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1036, 50);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _uploadScriptTsb
            // 
            this._uploadScriptTsb.Image = ((System.Drawing.Image)(resources.GetObject("_uploadScriptTsb.Image")));
            this._uploadScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._uploadScriptTsb.Name = "_uploadScriptTsb";
            this._uploadScriptTsb.Size = new System.Drawing.Size(209, 44);
            this._uploadScriptTsb.Text = "Upload Script...";
            // 
            // _downloadScriptTsb
            // 
            this._downloadScriptTsb.Image = ((System.Drawing.Image)(resources.GetObject("_downloadScriptTsb.Image")));
            this._downloadScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._downloadScriptTsb.Name = "_downloadScriptTsb";
            this._downloadScriptTsb.Size = new System.Drawing.Size(241, 44);
            this._downloadScriptTsb.Text = "Download Script...";
            // 
            // _lockTsl
            // 
            this._lockTsl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._lockTsl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lockTsl.Image = global::Ecs.Edpf.GUI.Properties.Resources.locked_96x96;
            this._lockTsl.Name = "_lockTsl";
            this._lockTsl.Size = new System.Drawing.Size(32, 44);
            this._lockTsl.Text = "toolStripLabel1";
            // 
            // _unlockTsl
            // 
            this._unlockTsl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._unlockTsl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._unlockTsl.Image = global::Ecs.Edpf.GUI.Properties.Resources.unlocked_96x96;
            this._unlockTsl.Name = "_unlockTsl";
            this._unlockTsl.Size = new System.Drawing.Size(32, 44);
            this._unlockTsl.Text = "toolStripLabel1";
            // 
            // _progressTspgbr
            // 
            this._progressTspgbr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._progressTspgbr.Name = "_progressTspgbr";
            this._progressTspgbr.Size = new System.Drawing.Size(100, 44);
            this._progressTspgbr.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // _loadDemoScriptTsb
            // 
            this._loadDemoScriptTsb.Image = global::Ecs.Edpf.GUI.Properties.Resources.reset_96x96;
            this._loadDemoScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadDemoScriptTsb.Name = "_loadDemoScriptTsb";
            this._loadDemoScriptTsb.Size = new System.Drawing.Size(256, 44);
            this._loadDemoScriptTsb.Text = "Load Demo Script...";
            this._loadDemoScriptTsb.Click += new System.EventHandler(this.LoadDemoScriptTsb_Click);
            // 
            // DeviceTextMacroView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DeviceTextMacroView";
            this.Size = new System.Drawing.Size(1036, 741);
            this._mainTlp.ResumeLayout(false);
            this._buttonsTlp.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainTlp;
        private System.Windows.Forms.TableLayoutPanel _buttonsTlp;
        private System.Windows.Forms.Button _oneShotBtn;
        private System.Windows.Forms.Button _loopBtn;
        private System.Windows.Forms.Button _stopBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _uploadScriptTsb;
        private System.Windows.Forms.ToolStripButton _downloadScriptTsb;
        private System.Windows.Forms.RichTextBox _scriptRtb;
        private System.Windows.Forms.ToolStripProgressBar _progressTspgbr;
        private System.Windows.Forms.ToolStripLabel _lockTsl;
        private System.Windows.Forms.ToolStripLabel _unlockTsl;
        private System.Windows.Forms.ToolStripButton _loadDemoScriptTsb;
    }
}
