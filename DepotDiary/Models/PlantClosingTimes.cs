using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotDiary.Models
{
    public class PlantClosingTimes
    {
        public string dayOfWeek { get; set; }
        public string close1 { get; set; }
        public string open1 { get; set; }
        public string? close2 { get; set; }
        public string? open2 { get; set; }
    }
}
