using Ecs.Edpf.GUI.UI.ViewModels;
using Ecs.Edpf.GUI.UI.ViewModels.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.UI.Views
{
    public partial class ChartingView : UserControl, IChildView
    {

        private IChartingViewModel _chartingViewModel = null;

        public IChildViewModel ViewModel
        {
            get
            {
                return _chartingViewModel;
            }
            set
            {
                if (_chartingViewModel != null)
                {
                    _chartingViewModel.PropertyChanged -= ChartingViewModel_PropertyChanged;
                }


                _chartingViewModel = value as IChartingViewModel;
                InitializeSubComponents();
                ShowHideSettings();
            }
        }



        public ChartingView()
        {
            InitializeComponent();

            InitializeSubComponents();
            ShowHideSettings();

            _showSettingsTsb.CheckedChanged += _showSettingsTsb_CheckedChanged;

        }

        private void _showSettingsTsb_CheckedChanged(object sender, EventArgs e)
        {
            _chartingViewModel.ShowSettings = _showSettingsTsb.Checked;
        }

        private void InitializeSubComponents()
        {
            if (_chartingViewModel == null)
            {
                _chartSettingsPpg.SelectedObject = null;
            }
            else
            {
                _chartSettingsPpg.SelectedObject = _chartingViewModel.SettingsViewModel;
                _chartingViewModel.PropertyChanged += ChartingViewModel_PropertyChanged;
            }
        }


        private void ShowHideSettings()
        {
            if (_chartingViewModel != null)
            {
                if (_chartingViewModel.ShowSettings && 
                    ((_mainPnl.Controls.Count != 1) || 
                    !object.ReferenceEquals(_mainPnl.Controls[0], _mainSpl)))
                {
                    // set the splitter as the main control
                    _mainPnl.Controls.Clear();
                    _mainPnl.Controls.Add(_mainSpl);
                    _mainSpl.Dock = DockStyle.Fill;

                    // add the chart to the left splitter
                    _mainSpl.Panel1.Controls.Clear();
                    _mainSpl.Panel1.Controls.Add(_chartPnl);
                    _chartPnl.Dock = DockStyle.Fill;
                }
                else if (!_chartingViewModel.ShowSettings &&
                    ((_mainPnl.Controls.Count != 1) ||
                    !object.ReferenceEquals(_mainPnl.Controls[0], _chartPnl)))
                {
                    // remove the chart from the left split panel
                    _mainSpl.Panel1.Controls.Clear();

                    // make the chart the main control
                    _mainPnl.Controls.Clear();
                    _mainPnl.Controls.Add(_chartPnl);
                    _chartPnl.Dock = DockStyle.Fill;
                }
            }
            else
            {
                _mainPnl.Controls.Clear();
            }
        }

        private void ChartingViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IChartingViewModel.ShowSettings))
            {
                ShowHideSettings();
            }
        }

    }
}
