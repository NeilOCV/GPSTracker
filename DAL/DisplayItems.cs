using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DisplayItems
    {
        public Int32 device_id { get; set; }
        public string log_date_time { get; set; }
        public string location_provider { get; set; }
        public Int32 battery { get; set; }
        public string device { get; set; }
        public decimal longitude { get; set; }
        public decimal latitude { get; set; }
    }
}
