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
    public class ChartingViewSettingsViewModel : BaseViewModel, IChartingViewSettingsViewModel
    {

        #region "Display"

        private const string DisplayCategoryName = StringExtensions.Tab10 + "Display";

        [Category(DisplayCategoryName)]
        [RefreshProperties(RefreshProperties.Repaint)]
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


        private const string AxesCategoryName = StringExtensions.Tab9 + "Axes";

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
        [RefreshProperties(RefreshProperties.Repaint)]
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
        [RefreshProperties(RefreshProperties.Repaint)]
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
        [RefreshProperties(RefreshProperties.Repaint)]
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
        [RefreshProperties(RefreshProperties.Repaint)]
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
        [RefreshProperties(RefreshProperties.Repaint)]
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
        [RefreshProperties(RefreshProperties.Repaint)]
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

        private const string ExpressionCategoryName = StringExtensions.Tab8 + "Expression";

        /// <summary>
        /// The type of expression.
        /// </summary>
        [Category(ExpressionCategoryName)]
        [DisplayName("\t\tExpression Type")]
        [Browsable(browsable: false)]
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

        public ChartingViewSettingsViewModel()
        {
            _chartSettings = new ChartSettings();
            CommonInit();
        }

        public ChartingViewSettingsViewModel(ChartSettings chartSettings)
        {
            _chartSettings = chartSettings;
            CommonInit();
        }

        private void CommonInit()
        {
            RegisterPropertyVisibilityHandlers(new[] { nameof(XRangeMin), nameof(XRangeMax) }, () => XRangeType != RangeType.Auto);
            RegisterPropertyVisibilityHandlers(new[] { nameof(YRangeMin), nameof(YRangeMax) }, () => YRangeType != RangeType.Auto);
        }



        public override string ToString()
        {
            return ChartName;
        }

    }
}
