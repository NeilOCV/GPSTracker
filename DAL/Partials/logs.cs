using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class logs
    {
        public Int32 Create(logs obj)
        {
            EDM edm = new EDM();
            edm.logs.Add(obj);
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
        public logs Read(Int32 id)
        {
            EDM edm = new EDM();
            var prog = from tb in edm.logs.AsNoTracking()
                       where tb.id == id
                       select tb;
            if (prog.ToList().Count() > 0)
                return prog.ToList()[0];
            return null;
        }
        public List<logs> List()
        {
            EDM edm = new EDM();
            var prog = from tb in edm.logs.AsNoTracking()
                       orderby tb.time_utc
                       select tb;
            return prog.ToList();
        }
        public bool Update(logs obj)
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
        public bool Delete(logs obj)
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
