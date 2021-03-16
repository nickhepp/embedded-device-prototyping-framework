using System.Collections.Generic;
using System.Windows.Forms;

namespace HostApp.UI.Views
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }


        public void SetToolWindows(List<IToolWindowCohort> cohorts)
        {

            _toolsTlp.RowStyles.Clear();
            
            for (int k = 0; k < cohorts.Count; k++)
            {
                SplashScreenToolView splashScreenToolView = new SplashScreenToolView();
                splashScreenToolView.SetToolWindow(cohorts[k]);
                _toolsTlp.RowStyles.Add(new RowStyle(sizeType: SizeType.Absolute, splashScreenToolView.Height));
                _toolsTlp.Controls.Add(splashScreenToolView, 0, k);
                splashScreenToolView.Dock = DockStyle.Fill;
            }
        }


    }
}
