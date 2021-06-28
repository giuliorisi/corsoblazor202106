using LibreriaDemo1.Models.Charts;
using LibreriaDemo1.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDemo1.Components.Charts
{
    public class Series: ComponentBase, IDisposable
    {
       [Parameter] public string Name { get; set; }
       [Parameter] public List<double> Values { get; set; }
       [CascadingParameter] public MyChart ChartFather { get; set; }

       private readonly SeriesData data = new SeriesData();

        protected override void OnParametersSet()
        {
            data.Data = Values.ToList();
            data.Name = Name;
        }
        protected override void OnInitialized()
        {
            ChartFather.ChartData.Series.Add(data);
        }

        public void Dispose()
        {
            ChartFather.ChartData.Series.Remove(data);
        }
    }
}
