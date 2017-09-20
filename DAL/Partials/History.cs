using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class History
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        private List<History> ApplyFilter(List<History> lst)
        {
            List<History> result = new List<History>();

            decimal lastLong = 0;
            decimal lastLat = 0;

            foreach (History item in lst)
            {
                decimal decLatDiff = (decimal)Math.Abs(lastLat - item.latitude);
                decimal decLonDiff = (decimal)Math.Abs(lastLong - item.longitude);

                if ((decLatDiff > (decimal)0.001) || (decLonDiff > (decimal)0.001))
                {
                    lastLong = item.longitude;
                    lastLat = item.latitude;
                    History obj = new History();
                    obj.latitude = item.latitude;
                    obj.longitude = item.longitude;
                    result.Add(obj);
                }
            }

            return result;
        }
        public List<History> GetLastHit(Int32 intDeviceID)
        {
            EDM edm = new EDM();
            var prog = (from tr in edm.transactions.AsNoTracking()
                       join lg in edm.logs.AsNoTracking() on tr.logs_id equals lg.id
                       where (tr.devices_id == intDeviceID)
                       orderby tr.date_time descending
                       select new History { latitude = lg.latitude, longitude = lg.longitude }).Take(1);
            if (prog.Count() != 1)
                return null;
            return prog.ToList();
        }
        public List<History> GetHistory(Int32 intDeviceID, DateTime dtStartDate, DateTime dtEndDate, bool booSmartFilter = true)
        {
            EDM edm = new EDM();
            var prog = from tr in edm.transactions.AsNoTracking()
                       join lg in edm.logs.AsNoTracking() on tr.logs_id equals lg.id
                       where ((tr.devices_id == intDeviceID) && (tr.date_time <= dtEndDate) && (tr.date_time >= dtStartDate))
                       orderby tr.date_time
                       select new History { latitude = lg.latitude, longitude = lg.longitude };
            if (prog.Count() > 0)
                if (booSmartFilter)
                    return ApplyFilter(prog.ToList());
                else
                    return prog.ToList();
            return null;
        }
    }
}
