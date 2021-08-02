using HostApp.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostApp.UI.Views
{
    public partial class SplashScreenToolView : UserControl
    {
        private IToolWindowCohort _cohort;

        public SplashScreenToolView()
        {
            InitializeComponent();
        }

        public void SetToolWindow(IToolWindowCohort cohort)
        {
            _cohort = cohort;
            _toolIconPbx.Image = cohort.Image;
            _toolNameLinkLbl.Text = cohort.Name;
            _descriptionLbl.Text = cohort.Description;
            _upvoteEnhancementLlbl.Visible = (cohort.State != Ecs.Edpf.GUI.ComponentModel.ToolState.Active);
        }

        private void _toolNameLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _cohort.GetToolWindow().Show();
            this.ParentForm.Close();
        }

        private void _upvoteEnhancementLlbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkVisitor.VisitUrl(_cohort.RoadmapIssueUrl);
        }
    }
}
