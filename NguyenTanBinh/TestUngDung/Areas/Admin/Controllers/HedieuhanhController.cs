using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HedieuhanhController : BaseController
    {
        // GET: Admin/Hedieuhanh
        public ActionResult Index(int page = 1, int pagesize = 4)
        {
            var dao = new HdhDao();
            var model = dao.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {
            var dao = new HdhDao();
            var model = dao.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HeDH model)
        {
            if (ModelState.IsValid)
            {
                var dao = new HdhDao();

                var res = dao.find(model.HeDieuHanh);
                if (res == 1)
                {
                    string result = dao.Insert(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thêm mới thành công", "success");
                        return RedirectToAction("Index", "Hedieuhanh");
                    }
                    else
                    {
                        SetAlert("Thêm mới thất bại", "error");
                        ModelState.AddModelError("", "Tạo mới thất bại");
                    }
                }
                else
                {
                    SetAlert("Hệ điều hành đã tồn tại", "warning");
                    return RedirectToAction("Create", "Hedieuhanh");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new HdhDao();
            var result = dao.Find(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(HeDH hdh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(hdh.HeDieuHanh))
                    {
                        SetAlert("Trống tên HDH", "warning");
                        return View();
                    }

                    var dao = new HdhDao();
                    string result = "";

                    result = dao.Edit(hdh);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Hedieuhanh");
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
            var dao = new HdhDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}