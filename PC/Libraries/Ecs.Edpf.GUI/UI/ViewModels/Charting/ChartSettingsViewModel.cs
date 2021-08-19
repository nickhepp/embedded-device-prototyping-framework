using Ecs.Edpf.Devices.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Ecs.Edpf.Devices.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Ecs.Edpf.GUI.Extensions;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public class ChartSettingsViewModel : BaseViewModel
    {

        #region "Display"

        private const string DisplayCategoryName = "\t\tDisplay";

        [Category(DisplayCategoryName)]
        public string ChartName
        {
            get
            {
                return _chartSettings.ChartName;
            }
            set
            {
                _chartSettings.ChartName = value;
                RaiseNotifyPropertyChanged();
            }
        }

        #endregion


        #region "Axes"


        private const string AxesCategoryName = "\tAxes";

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab10 + "X Axis Type")]

        public XAxisType XAxisType
        {
            get
            {
                return _chartSettings.XAxisType;
            }
            set
            {
                _chartSettings.XAxisType = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab9 + "X Range Type")]
        public RangeType XRangeType
        {
            get
            {
                

                return _chartSettings.XRange.RangeType;
            }
            set
            {
                _chartSettings.XRange.RangeType = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab8 + "X Range Min")]
        public int XRangeMin
        {
            get
            {
                return _chartSettings.XRange.Min;
            }
            set
            {
                _chartSettings.XRange.Min = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab7 + "X Range Max")]
        public int XRangeMax
        {
            get
            {
                return _chartSettings.XRange.Max;
            }
            set
            {
                _chartSettings.XRange.Max = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab6 + "Y Axis Scale")]
        public YAxisScale YAxisScale
        {
            get
            {
                return _chartSettings.YAxisScale;
            }
            set
            {
                _chartSettings.YAxisScale = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab5 + "Y Range Type")]
        public RangeType YRangeType
        {
            get
            {


                return _chartSettings.YRange.RangeType;
            }
            set
            {
                _chartSettings.YRange.RangeType = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab4 + "Y Range Min")]
        public int YRangeMin
        {
            get
            {
                return _chartSettings.YRange.Min;
            }
            set
            {
                _chartSettings.YRange.Min = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(AxesCategoryName)]
        [DisplayName(StringExtensions.Tab3 + "Y Range Max")]
        public int YRangeMax
        {
            get
            {
                return _chartSettings.YRange.Max;
            }
            set
            {
                _chartSettings.YRange.Max = value;
                RaiseNotifyPropertyChanged();
            }
        }

        #endregion


        #region Expression

        private const string ExpressionCategoryName = "Expression";

        /// <summary>
        /// The type of expression.
        /// </summary>
        [Category(ExpressionCategoryName)]
        [DisplayName("\t\tExpression Type")]
        public ExpressionType ExpressionType
        {
            get
            {
                return _chartSettings.ExpressionType;
            }
            set
            {
                _chartSettings.ExpressionType = value;
                RaiseNotifyPropertyChanged();
            }
        }

        [Category(ExpressionCategoryName)]
        [DisplayName("\tExpression")]
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



        private ChartSettings _chartSettings;

        public ChartSettingsViewModel()
        {
            _chartSettings = new ChartSettings();
        }

        public ChartSettingsViewModel(ChartSettings chartSettings)
        {
            _chartSettings = chartSettings;
        }


        public override string ToString()
        {
            return ChartName;
        }



    }
}
