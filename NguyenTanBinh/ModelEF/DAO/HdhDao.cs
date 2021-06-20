using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class HdhDao
    {
        private NguyenTanBinhContext db;

        public HdhDao()
        {
            db = new NguyenTanBinhContext();
        }

        public List<HeDH> ListAll()
        {
            return db.HeDHs.ToList();
        }

        public IEnumerable<HeDH> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<HeDH> model = db.HeDHs;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.HeDieuHanh.Contains(keysearch));
            return model.OrderBy(x => x.HeDieuHanh).ToPagedList(page, pagesize);
        }

        public string Insert(HeDH entityHdh)
        {
            var hdh = Find(entityHdh.IdHdh);
            if (hdh == null)
            {
                db.HeDHs.Add(entityHdh);
            }
            else
            {
                hdh.IdHdh = entityHdh.IdHdh;
            }
            db.SaveChanges();
            return entityHdh.HeDieuHanh;
        }

        public string Edit(HeDH entityHdh)
        {
            var hdh = Find(entityHdh.IdHdh);
            if (hdh == null)
            {
                db.HeDHs.Add(entityHdh);
            }
            else
            {
                hdh.IdHdh = entityHdh.IdHdh;
                hdh.HeDieuHanh = entityHdh.HeDieuHanh;
            }
            db.SaveChanges();
            return entityHdh.IdHdh.ToString();
        }

        public bool Delete(int id)
        {
            try
            {
                var hdh = db.HeDHs.Find(id);
                db.HeDHs.Remove(hdh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int find(string tenHdh)
        {
            var query = db.HeDHs.SingleOrDefault(c => c.HeDieuHanh.Contains(tenHdh));
            if (query == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public HeDH Find(int id)
        {
            return db.HeDHs.Find(id);
        }
    }
}
