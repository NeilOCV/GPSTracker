using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class transactions
    {
        public class transactions_stats
        {
            public DateTime FirstLog { get; set; }
            public DateTime LastLog { get; set; }
            public Int32 NumberOfLogs { get; set; }
            public Int32 TotalNumberOfLogs { get; set; }
            public decimal LastLatitude { get; set; }
            public decimal LastLongitude { get; set; }
            public decimal LastAltitude { get; set; }
            public Int32 Satellites { get; set; }
            public decimal Altitude { get; set; }
            public decimal Speed { get; set; }
            public decimal Accuracy { get; set; }
            public decimal Direction { get; set; }
            public string Provider { get; set; }
            public DateTime Time_UTC { get; set; }
            public decimal Battery { get; set; }
            public string AndroidID { get; set; }
            public string SerialNumber { get; set; }
            public string URL { get; set; }

        }
        public Int32 Create(transactions obj)
        {
            EDM edm = new EDM();
            edm.transactions.Add(obj);
            try
            {
                edm.SaveChanges();
                return obj.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public transactions Read(Int32 id)
        {
            EDM edm = new EDM();
            var prog = from tb in edm.transactions.AsNoTracking()
                       where tb.id == id
                       select tb;
            if (prog.ToList().Count() > 0)
                return prog.ToList()[0];
            return null;
        }
        public List<transactions> List()
        {
            EDM edm = new EDM();
            var prog = from tb in edm.transactions.AsNoTracking()
                       orderby tb.date_time
                       select tb;
            return prog.ToList();
        }
        public bool Update(transactions obj)
        {
            EDM edm = new EDM();
            edm.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            try
            {
                edm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(transactions obj)
        {
            EDM edm = new EDM();
            edm.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            try
            {
                edm.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public transactions_stats GetDisplayStats(Int32 intDeviceID)
        {
            transactions_stats result = new transactions_stats();
            EDM edm = new EDM();

            int intTotalTransactionCount = (from tb in edm.transactions.AsNoTracking()
                                            select tb).Count();

            int intTransactionCount = (from tb in edm.transactions.AsNoTracking()
                                       where tb.devices_id == intDeviceID
                                       select tb).Count();

            transactions transaction = (from tb in edm.transactions.AsNoTracking()
                                        where tb.devices_id == intDeviceID
                                        orderby tb.date_time descending
                                        select tb).FirstOrDefault();

            DateTime dtFirstLog = (from tb in edm.transactions.AsNoTracking()
                                   where tb.devices_id == intDeviceID
                                   orderby tb.date_time ascending
                                   select tb.date_time).FirstOrDefault();

            if (transaction == null)
                return null;

            result.LastLog = transaction.date_time;
            result.FirstLog = dtFirstLog;
            result.NumberOfLogs = intTransactionCount;
            result.TotalNumberOfLogs = intTotalTransactionCount;

            logs logs = new logs();
            logs log = (from tb in edm.logs.AsNoTracking()
                        where tb.id == transaction.logs_id
                        select tb).Single();

            result.Accuracy = log.accuracy;
            result.Altitude = log.altitude;
            result.AndroidID = log.androidid;
            result.Battery = log.battery;
            result.Direction = log.direction;
            result.LastAltitude = log.altitude;
            result.LastLatitude = log.latitude;
            result.LastLongitude = log.longitude;
            result.Provider = log.provider;
            result.Satellites = log.satellites;
            result.SerialNumber = log.serial;
            result.Speed = log.speed;
            result.Time_UTC = log.time_utc;
            result.URL = log.url;

            return result;
        }
    }
}
