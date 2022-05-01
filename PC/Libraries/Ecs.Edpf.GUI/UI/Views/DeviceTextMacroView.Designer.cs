
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
            this._mainTlp.Location = new System.Drawing.Point(0, 39);
            this._mainTlp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._mainTlp.Name = "_mainTlp";
            this._mainTlp.RowCount = 2;
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this._mainTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._mainTlp.Size = new System.Drawing.Size(518, 346);
            this._mainTlp.TabIndex = 0;
            // 
            // _buttonsTlp
            // 
            this._buttonsTlp.ColumnCount = 7;
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99981F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00005F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00007F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this._buttonsTlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00007F));
            this._buttonsTlp.Controls.Add(this._oneShotBtn, 3, 0);
            this._buttonsTlp.Controls.Add(this._loopBtn, 1, 0);
            this._buttonsTlp.Controls.Add(this._stopBtn, 5, 0);
            this._buttonsTlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonsTlp.Location = new System.Drawing.Point(2, 267);
            this._buttonsTlp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._buttonsTlp.Name = "_buttonsTlp";
            this._buttonsTlp.RowCount = 1;
            this._buttonsTlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonsTlp.Size = new System.Drawing.Size(514, 77);
            this._buttonsTlp.TabIndex = 2;
            // 
            // _oneShotBtn
            // 
            this._oneShotBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._oneShotBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this._oneShotBtn.Image = global::Ecs.Edpf.GUI.Properties.Resources.repeat_one_64x64;
            this._oneShotBtn.Location = new System.Drawing.Point(217, 2);
            this._oneShotBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._oneShotBtn.Name = "_oneShotBtn";
            this._oneShotBtn.Size = new System.Drawing.Size(78, 73);
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
            this._loopBtn.Location = new System.Drawing.Point(68, 2);
            this._loopBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._loopBtn.Name = "_loopBtn";
            this._loopBtn.Size = new System.Drawing.Size(78, 73);
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
            this._stopBtn.Location = new System.Drawing.Point(366, 2);
            this._stopBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._stopBtn.Name = "_stopBtn";
            this._stopBtn.Size = new System.Drawing.Size(78, 73);
            this._stopBtn.TabIndex = 2;
            this._stopBtn.Text = "Stop";
            this._stopBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._stopBtn.UseVisualStyleBackColor = true;
            // 
            // _scriptRtb
            // 
            this._scriptRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scriptRtb.Location = new System.Drawing.Point(2, 2);
            this._scriptRtb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this._scriptRtb.Name = "_scriptRtb";
            this._scriptRtb.Size = new System.Drawing.Size(514, 261);
            this._scriptRtb.TabIndex = 3;
            this._scriptRtb.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._uploadScriptTsb,
            this._downloadScriptTsb,
            this._progressTspgbr,
            this._loadDemoScriptTsb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(518, 39);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _uploadScriptTsb
            // 
            this._uploadScriptTsb.Image = ((System.Drawing.Image)(resources.GetObject("_uploadScriptTsb.Image")));
            this._uploadScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._uploadScriptTsb.Name = "_uploadScriptTsb";
            this._uploadScriptTsb.Size = new System.Drawing.Size(123, 36);
            this._uploadScriptTsb.Text = "Upload Script...";
            // 
            // _downloadScriptTsb
            // 
            this._downloadScriptTsb.Image = ((System.Drawing.Image)(resources.GetObject("_downloadScriptTsb.Image")));
            this._downloadScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._downloadScriptTsb.Name = "_downloadScriptTsb";
            this._downloadScriptTsb.Size = new System.Drawing.Size(139, 36);
            this._downloadScriptTsb.Text = "Download Script...";
            // 
            // _progressTspgbr
            // 
            this._progressTspgbr.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._progressTspgbr.Name = "_progressTspgbr";
            this._progressTspgbr.Size = new System.Drawing.Size(50, 36);
            this._progressTspgbr.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // _loadDemoScriptTsb
            // 
            this._loadDemoScriptTsb.Image = global::Ecs.Edpf.GUI.Properties.Resources.reset_96x96;
            this._loadDemoScriptTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadDemoScriptTsb.Name = "_loadDemoScriptTsb";
            this._loadDemoScriptTsb.Size = new System.Drawing.Size(146, 36);
            this._loadDemoScriptTsb.Text = "Load Demo Script...";
            this._loadDemoScriptTsb.Click += new System.EventHandler(this.LoadDemoScriptTsb_Click);
            // 
            // DeviceTextMacroView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainTlp);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DeviceTextMacroView";
            this.Size = new System.Drawing.Size(518, 385);
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
        private System.Windows.Forms.ToolStripButton _loadDemoScriptTsb;
    }
}
