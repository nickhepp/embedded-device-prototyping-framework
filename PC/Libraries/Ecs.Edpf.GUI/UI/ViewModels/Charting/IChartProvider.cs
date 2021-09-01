using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVizCharting = System.Windows.Forms.DataVisualization.Charting;



namespace Ecs.Edpf.GUI.UI.ViewModels.Charting
{
    public interface IChartProvider
    {

        DataVizCharting.Chart GetChart();


    }
}
