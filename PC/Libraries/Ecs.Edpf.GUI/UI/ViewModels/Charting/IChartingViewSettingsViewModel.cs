﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public interface IChartingViewSettingsViewModel
    {

        List<ChartSettingsViewModel> Charts { get; set; }

    }
}
