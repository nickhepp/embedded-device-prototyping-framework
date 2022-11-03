using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Ecs.Edpf.Devices.ComponentModel;

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

            // there are two sets of tool windows to show, that are done, and those that need votes

            // 1) show those that are done first
            List<IToolWindowCohort> doneCohorts = cohorts.Where(cohort => cohort.State == Ecs.Edpf.GUI.ComponentModel.ToolState.Active).ToList();
            int cohortIdx = 0;
            foreach (IToolWindowCohort doneCohort in doneCohorts)
            {
                SplashScreenToolView splashScreenToolView = new SplashScreenToolView();
                splashScreenToolView.SetToolWindow(doneCohort);
                _toolsTlp.RowStyles.Add(new RowStyle(sizeType: SizeType.Absolute, splashScreenToolView.Height));
                _toolsTlp.Controls.Add(splashScreenToolView, 0, cohortIdx);
                splashScreenToolView.Dock = DockStyle.Fill;
                cohortIdx++;
            }

            // 2) show those that need votes in a random order, they are randomized so t
            List<IToolWindowCohort> notDoneCohorts = cohorts.Except(doneCohorts).ToList();
            notDoneCohorts.Shuffle();
            foreach (IToolWindowCohort notDoneCohort in notDoneCohorts)
            {
                SplashScreenToolView splashScreenToolView = new SplashScreenToolView();
                splashScreenToolView.SetToolWindow(notDoneCohort);
                _toolsTlp.RowStyles.Add(new RowStyle(sizeType: SizeType.Absolute, splashScreenToolView.Height));
                _toolsTlp.Controls.Add(splashScreenToolView, 0, cohortIdx);
                splashScreenToolView.Dock = DockStyle.Fill;
                cohortIdx++;
            }

        }

        private void _ecsLogoPbx_Click(object sender, System.EventArgs e)
        {
            try
            {
                Process.Start(HostAppConstants.ElectronicComputingDotComUrl);
            }
            catch (Exception)
            {
                // do nothing here, the app will work fine even if we cant
                // load the website
            }
        }
    }
}
