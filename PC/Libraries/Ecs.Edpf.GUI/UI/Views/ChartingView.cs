using Ecs.Edpf.GUI.UI.ViewModels;
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
    public partial class ChartingView : UserControl
    {

        private IChartingViewModel _chartingViewModel;
        public IChartingViewModel ChartingViewModel
        {
            get
            {
                return _chartingViewModel;
            }
            set
            {
                _chartingViewModel = value;
                SetBindings();
            }
        }



        public ChartingView()
        {
            InitializeComponent();
        }


        private void SetBindings()
        {

        }


    }
}
