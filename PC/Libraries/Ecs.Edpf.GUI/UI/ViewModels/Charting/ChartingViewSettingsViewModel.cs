using Ecs.Edpf.Devices.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Ecs.Edpf.Devices.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Ecs.Edpf.GUI.Extensions;
using DataVizCharting = System.Windows.Forms.DataVisualization.Charting;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartingViewSettingsViewModel : BaseViewModel, IChartingViewSettingsViewModel
    {


        #region "Charting"

        private const string ChartingCategoryName = StringExtensions.Tab10 + "Charting";

        [DisplayName("Chart Areas")]
        [Category(ChartingCategoryName)]
        public DataVizCharting.ChartAreaCollection ChartAreas
        {
            get
            {
                return _chart.Value.ChartAreas;
            }
        }

        [DisplayName("Series")]
        [Category(ChartingCategoryName)]
        public DataVizCharting.SeriesCollection SeriesCollection
        {
            get
            {
                return _chart.Value.Series;
            }
        }


        #endregion


        #region "Display"

        private const string DisplayCategoryName = StringExtensions.Tab10 + "Display";

        [Category(DisplayCategoryName)]
        public DataVizCharting.LegendCollection Legends
        {
            get
            {
                return _chart.Value.Legends;
            }
        }

        [Category(DisplayCategoryName)]
        public DataVizCharting.TitleCollection Titles
        {
            get
            {
                return _chart.Value.Titles;
            }
        }

        [Category(DisplayCategoryName)]
        public DataVizCharting.ChartColorPalette Palette
        {
            get
            {
                 return _chart.Value.Palette;
            }
            set
            {
                _chart.Value.Palette = value;
            }
        }

        #endregion


        #region "Axes"


        //private const string AxesCategoryName = StringExtensions.Tab9 + "Axes";

        //[Category(AxesCategoryName)]
        //[DisplayName(StringExtensions.Tab10 + "X Axis Type")]
        //public XAxisType XAxisType
        //{
        //    get
        //    {
        //        return _chartSettings.XAxisType;
        //    }
        //    set
        //    {
        //        _chartSettings.XAxisType = value;
        //        RaiseNotifyPropertyChanged();
        //    }
        //}

        #endregion


        #region Expression

        private const string ExpressionCategoryName = StringExtensions.Tab10 + "Expression";

        [Category(ExpressionCategoryName)]
        [DisplayName("\tExpression")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Expression
        {
            get
            {
                return _chartSettings.Expression;
            }
            set
            {
                _chartSettings.Expression = value;
                RaiseNotifyPropertyChanged();
            }
        }

        #endregion


        #region Errors

        private const string ErrorsCategoryName = StringExtensions.Tab7 + "Errors";

        [Category(ErrorsCategoryName)]
        public string Errors
        {
            get
            {
                List<string> errors = _chartSettings.GetErrors();
                string errStr = "(none)";
                if (errors.Count > 0)
                {
                    errStr = $"!!{errors.Count}: {string.Join(separator: " ", errors)}";
                }
                return errStr;
            }
        }


        #endregion

        private ChartSettings _chartSettings;

        private Lazy<System.Windows.Forms.DataVisualization.Charting.Chart> _chart;

        public ChartingViewSettingsViewModel(IChartProvider chartProvider, ChartSettings chartSettings)
        {
            _chartSettings = chartSettings;
            _chart = new Lazy<DataVizCharting.Chart>(() => chartProvider.GetChart());
        }

    }
}
