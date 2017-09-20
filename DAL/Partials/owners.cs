using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class owners
    {
        public Int32 Create(owners obj)
        {
            EDM edm = new EDM();
            edm.owners.Add(obj);
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
        public owners Read(Int32 id)
        {
            EDM edm = new EDM();
            var prog = from tb in edm.owners.AsNoTracking()
                       where tb.id == id
                       select tb;
            if (prog.ToList().Count() > 0)
                return prog.ToList()[0];
            return null;
        }
        public List<owners> List()
        {
            EDM edm = new EDM();
            var prog = from tb in edm.owners.AsNoTracking()
                       orderby tb.owner
                       select tb;
            return prog.ToList();
        }
        public bool Update(owners obj)
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
        public bool Delete(owners obj)
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
