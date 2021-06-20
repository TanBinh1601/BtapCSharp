using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class HangSXDao
    {
        private NguyenTanBinhContext db;
        public HangSXDao()
        {
            db = new NguyenTanBinhContext();
        }

        public List<HangSX> ListAll()
        {
            return db.HangSXes.ToList();
        }

        public IEnumerable<HangSX> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<HangSX> model = db.HangSXes;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.HangSX1.Contains(keysearch));
            return model.OrderBy(x => x.HangSX1).ToPagedList(page, pagesize);
        }

        public string Insert(HangSX entityHsx)
        {
            var hsx = Find(entityHsx.IdHang);
            if (hsx == null)
            {
                db.HangSXes.Add(entityHsx);
            }
            else
            {
                hsx.IdHang = entityHsx.IdHang;
            }
            db.SaveChanges();
            return entityHsx.HangSX1;
        }

        public string Edit(HangSX entityHsx)
        {
            var hsx = Find(entityHsx.IdHang);
            if (hsx == null)
            {
                db.HangSXes.Add(entityHsx);
            }
            else
            {
                hsx.IdHang = entityHsx.IdHang;
                hsx.HangSX1 = entityHsx.HangSX1;
            }
            db.SaveChanges();
            return entityHsx.IdHang.ToString();
        }

        public bool Delete(int id)
        {
            try
            {
                var hsx = db.HangSXes.Find(id);
                db.HangSXes.Remove(hsx);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int find(string tenHang)
        {
            var query = db.HangSXes.SingleOrDefault(c => c.HangSX1.Contains(tenHang));
            if (query == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public HangSX Find(int id)
        {
            return db.HangSXes.Find(id);
        }
    }
}
