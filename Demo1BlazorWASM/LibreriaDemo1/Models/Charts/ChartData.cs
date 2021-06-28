using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDemo1.Models.Charts
{
    public class ChartData
    {
        public List<string> Labels { get; set; }
        public List<SeriesData> Series { get; set; }
    }


    public class SeriesData
    {
        public string Name { get; set; }
        public List<double> Data { get; set; }
    }

    public enum ChartType
    {
        Bar, Line
    }


}
