using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private NguyenTanBinhContext db;
        public UserDao()
        {
            db = new NguyenTanBinhContext();
        }
        public int login(string username, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username) && x.Password.Contains(pass));

            if (result != null && result.IDStatus == 1)
            {
                return 1;
            }
            else if (result != null && result.IDStatus != 1)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        public string Insert(UserAccount entityUser)
        {
            var user = Find(entityUser.ID);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.ID = entityUser.ID;
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
            }
            db.SaveChanges();
            return entityUser.UserName;
        }

        public string Edit(UserAccount entityUser)
        {
            var user = Find(entityUser.ID);
            if (user == null)
            {
                db.UserAccounts.Add(entityUser);
            }
            else
            {
                user.ID = entityUser.ID;
                user.UserName = entityUser.UserName;                
                user.IDStatus = entityUser.IDStatus;                
                if (!String.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
            }
            db.SaveChanges();
            return entityUser.ID.ToString();
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int find(string userName)
        {
            var query = db.UserAccounts.SingleOrDefault(c => c.UserName.Contains(userName));
            if (query == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public UserAccount Find(int id)
        {
            return db.UserAccounts.Find(id);
        }
        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.UserName.Contains(keysearch));
            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
    }
}
