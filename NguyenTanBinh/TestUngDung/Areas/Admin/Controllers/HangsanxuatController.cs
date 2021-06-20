using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HangsanxuatController : BaseController
    {
        private NguyenTanBinhContext db = new NguyenTanBinhContext();
        // GET: Admin/Hangsanxuat
        public ActionResult Index(int page = 1, int pagesize = 4)
        {
            var dao = new HangSXDao();
            var model = dao.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {
            var dao = new HangSXDao();
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
        public ActionResult Create(HangSX model)
        {
            if (ModelState.IsValid)
            {
                var dao = new HangSXDao();

                var res = dao.find(model.HangSX1);
                if (res == 1)
                {
                    string result = dao.Insert(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thêm mới thành công", "success");
                        return RedirectToAction("Index", "Hangsanxuat");
                    }
                    else
                    {
                        SetAlert("Thêm mới thất bại", "error");
                        ModelState.AddModelError("", "Tạo mới thất bại");
                    }
                }
                else
                {
                    SetAlert("Hãng sản xuất đã tồn tại", "warning");
                    return RedirectToAction("Create", "Hangsanxuat");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new HangSXDao();
            var result = dao.Find(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(HangSX hsx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(hsx.HangSX1))
                    {
                        SetAlert("Trống tên hãng", "warning");
                        return View();
                    }

                    var dao = new HangSXDao();
                    string result = "";

                    result = dao.Edit(hsx);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Hangsanxuat");
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
            var dao = new HangSXDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}