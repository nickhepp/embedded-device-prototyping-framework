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
    public partial class NotImplementedView : UserControl
    {

        private string _upvoteEnhancementUrl;

        //public NotImplementedView()
        //{
        //    InitializeComponent();
        //}

        public NotImplementedView(string upvoteEnhancementUrl)
        {
            InitializeComponent();

            _upvoteEnhancementUrl = upvoteEnhancementUrl;
            _upvoteEnhancementLlbl.LinkClicked += UpvoteEnhancementLbl_LinkClicked;
        }


        public NotImplementedView(Control previewControl, string upvoteEnhancementUrl)
        {
            InitializeComponent();

            _previewPnl.Controls.Clear();
            _previewPnl.Controls.Add(previewControl);
            previewControl.Dock = DockStyle.Fill;

            _upvoteEnhancementUrl = upvoteEnhancementUrl;
            _upvoteEnhancementLlbl.LinkClicked += UpvoteEnhancementLbl_LinkClicked;
        }

        private void UpvoteEnhancementLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkVisitor.VisitUrl(_upvoteEnhancementUrl);
        }

    }
}
