using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class devices
    {
        public Int32 Create(devices obj)
        {
            EDM edm = new EDM();
            edm.devices.Add(obj);
            try
            {
                edm.SaveChanges();
                return obj.id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public devices Read(Int32 id)
        {
            EDM edm = new EDM();
            var prog = from tb in edm.devices.AsNoTracking()
                       where tb.id == id
                       select tb;
            if (prog.ToList().Count() > 0)
                return prog.ToList()[0];
            return null;
        }
        public List<devices> List()
        {
            EDM edm = new EDM();
            var prog = from tb in edm.devices.AsNoTracking()
                       orderby tb.device_name
                       select tb;
            return prog.ToList();
        }
        public bool Update(devices obj)
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
        public bool Delete(devices obj)
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
    }
}
