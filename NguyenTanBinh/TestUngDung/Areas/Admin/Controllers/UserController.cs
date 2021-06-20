using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private NguyenTanBinhContext db = new NguyenTanBinhContext();
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IDStatus = new SelectList(db.TrangThais, "IDTT", "TrangThai1");
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var res = dao.find(model.UserName);
                if (res == 1)
                {
                    ViewBag.IDStatus = new SelectList(db.TrangThais, "IDTT", "TrangThai1", model.IDStatus);
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;
                    string result = dao.Insert(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thêm mới thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Thêm mới thất bại", "error");
                        ModelState.AddModelError("", "Tạo mới thất bại");
                    }
                }
                else
                {
                    SetAlert("Tài khoản đã tồn tại", "warning");
                    return RedirectToAction("Create", "User");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            UserAccount user = db.UserAccounts.Find(id);
            ViewBag.IDStatus = new SelectList(db.TrangThais, "IDTT", "TrangThai1", user.IDStatus);
            var result = dao.Find(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserAccount user)
        {
            ViewBag.IDStatus = new SelectList(db.TrangThais, "IDTT", "TrangThai1");
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(user.Password))
                    {
                        SetAlert("Mật khẩu trống", "warning");
                        return View();
                    }

                    var dao = new UserDao();
                    var pass = Encryptor.EncryptMD5(user.Password);
                    user.Password = pass;
                    string result = "";

                    result = dao.Edit(user);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Cập nhật thất bại", "error");
                    }
                }

            }
            catch (Exception)
            {
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var dao = new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}