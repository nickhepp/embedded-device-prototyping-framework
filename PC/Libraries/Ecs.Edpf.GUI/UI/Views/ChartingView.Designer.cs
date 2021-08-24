
namespace Ecs.Edpf.GUI.UI.Views
{
    partial class ChartingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartingView));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._showSettingsTsb = new System.Windows.Forms.ToolStripButton();
            this._mainSpl = new System.Windows.Forms.SplitContainer();
            this._chartSettingsPpg = new System.Windows.Forms.PropertyGrid();
            this._chartPnl = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._settingsSsl = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainPnl = new System.Windows.Forms.Panel();
            this._mainChrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).BeginInit();
            this._mainSpl.Panel2.SuspendLayout();
            this._mainSpl.SuspendLayout();
            this._chartPnl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this._mainPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainChrt)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._showSettingsTsb});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1963, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _showSettingsTsb
            // 
            this._showSettingsTsb.Checked = true;
            this._showSettingsTsb.CheckOnClick = true;
            this._showSettingsTsb.CheckState = System.Windows.Forms.CheckState.Checked;
            this._showSettingsTsb.Image = ((System.Drawing.Image)(resources.GetObject("_showSettingsTsb.Image")));
            this._showSettingsTsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._showSettingsTsb.Name = "_showSettingsTsb";
            this._showSettingsTsb.Size = new System.Drawing.Size(202, 36);
            this._showSettingsTsb.Text = "Show Settings";
            // 
            // _mainSpl
            // 
            this._mainSpl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._mainSpl.Location = new System.Drawing.Point(1125, 92);
            this._mainSpl.Name = "_mainSpl";
            // 
            // _mainSpl.Panel2
            // 
            this._mainSpl.Panel2.Controls.Add(this._chartSettingsPpg);
            this._mainSpl.Size = new System.Drawing.Size(547, 276);
            this._mainSpl.SplitterDistance = 289;
            this._mainSpl.TabIndex = 1;
            // 
            // _chartSettingsPpg
            // 
            this._chartSettingsPpg.Dock = System.Windows.Forms.DockStyle.Fill;
            this._chartSettingsPpg.Location = new System.Drawing.Point(0, 0);
            this._chartSettingsPpg.Name = "_chartSettingsPpg";
            this._chartSettingsPpg.Size = new System.Drawing.Size(250, 272);
            this._chartSettingsPpg.TabIndex = 0;
            this._chartSettingsPpg.ToolbarVisible = false;
            // 
            // _chartPnl
            // 
            this._chartPnl.Controls.Add(this._mainChrt);
            this._chartPnl.Location = new System.Drawing.Point(101, 65);
            this._chartPnl.Name = "_chartPnl";
            this._chartPnl.Size = new System.Drawing.Size(772, 580);
            this._chartPnl.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingsSsl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 920);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1963, 42);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _settingsSsl
            // 
            this._settingsSsl.Name = "_settingsSsl";
            this._settingsSsl.Size = new System.Drawing.Size(137, 32);
            this._settingsSsl.Text = "_settingsSsl";
            // 
            // _mainPnl
            // 
            this._mainPnl.Controls.Add(this._chartPnl);
            this._mainPnl.Controls.Add(this._mainSpl);
            this._mainPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPnl.Location = new System.Drawing.Point(0, 42);
            this._mainPnl.Name = "_mainPnl";
            this._mainPnl.Size = new System.Drawing.Size(1963, 878);
            this._mainPnl.TabIndex = 4;
            // 
            // _mainChrt
            // 
            chartArea1.Name = "ChartArea1";
            this._mainChrt.ChartAreas.Add(chartArea1);
            this._mainChrt.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this._mainChrt.Legends.Add(legend1);
            this._mainChrt.Location = new System.Drawing.Point(0, 0);
            this._mainChrt.Name = "_mainChrt";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this._mainChrt.Series.Add(series1);
            this._mainChrt.Size = new System.Drawing.Size(772, 580);
            this._mainChrt.TabIndex = 0;
            this._mainChrt.Text = "chart1";
            // 
            // ChartingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._mainPnl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ChartingView";
            this.Size = new System.Drawing.Size(1963, 962);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._mainSpl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainSpl)).EndInit();
            this._mainSpl.ResumeLayout(false);
            this._chartPnl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this._mainPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainChrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _showSettingsTsb;
        private System.Windows.Forms.SplitContainer _mainSpl;
        private System.Windows.Forms.PropertyGrid _chartSettingsPpg;
        private System.Windows.Forms.Panel _chartPnl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _settingsSsl;
        private System.Windows.Forms.Panel _mainPnl;
        private System.Windows.Forms.DataVisualization.Charting.Chart _mainChrt;
    }
}
