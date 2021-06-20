using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class HomeDao
    {
        private NguyenTanBinhContext db;

        public HomeDao()
        {
            db = new NguyenTanBinhContext();
        }

        public List<SanPham> ListAll()
        {
            return db.SanPhams.OrderByDescending(x=>x.GiaTien).ToList();
        }

        public IEnumerable<SanPham> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<SanPham> model = db.SanPhams;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.TenSP.Contains(keysearch));
            return model.OrderBy(x => x.TenSP).ToPagedList(page, pagesize);
        }

        public string Insert(SanPham entity)
        {
            var sp = Find(entity.IdSP);
            if (sp == null)
            {
                db.SanPhams.Add(entity);
            }
            else
            {
                sp.IdSP = entity.IdSP;
            }
            db.SaveChanges();
            return entity.TenSP;
        }

        public string Edit(SanPham entity)
        {
            var sp = Find(entity.IdSP);
            if (sp == null)
            {
                db.SanPhams.Add(entity);
            }
            else
            {
                sp.IdSP = entity.IdSP;
                sp.TenSP = entity.TenSP;                
                sp.SoLuong = entity.SoLuong;
                sp.GiaTien = entity.GiaTien;
                sp.BoNho = entity.BoNho;
                sp.Ram = entity.Ram;
                sp.HinhAnh = entity.HinhAnh;
                sp.MoTa = entity.MoTa;
                sp.Ram = entity.Ram;                
                sp.IdHang = entity.IdHang;
                sp.IdHDH = entity.IdHDH;
            }
            db.SaveChanges();
            return entity.IdSP.ToString();
        }

        public bool Delete(int id)
        {
            try
            {
                var sp = db.SanPhams.Find(id);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int find(string tenSp)
        {
            var query = db.SanPhams.SingleOrDefault(c => c.TenSP.Contains(tenSp));
            if (query == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public SanPham Find(int id)
        {
            return db.SanPhams.Find(id);
        }
    }
}
