using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using ModelEF.DAO;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private NguyenTanBinhContext db = new NguyenTanBinhContext();
        // GET: Admin/Home
        public ActionResult Index(int page = 1, int pagesize = 6)
        {
            var session = (LoginModel)Session[Constrants.USER_SESSION];
            if (session == null)
                return RedirectToAction("Index", "Login");
            var sp = new HomeDao();
            var model = sp.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 4)
        {
            var sp = new HomeDao();
            var model = sp.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        public ActionResult Details(int id)
        {
            var dt = db.SanPhams.Find(id);
            return View(dt);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdHang = new SelectList(db.HangSXes, "IdHang", "HangSX1");
            ViewBag.IdHDH = new SelectList(db.HeDHs, "IdHdh", "HeDieuHanh");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham model, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var dao = new HomeDao();

                    var res = dao.find(model.TenSP);
                    if (res == 1)
                    {
                        ViewBag.IdHang = new SelectList(db.HangSXes, "IdHang", "HangSX1", model.IdHang);
                        ViewBag.IdHDH = new SelectList(db.HeDHs, "IdHdh", "HeDieuHanh", model.IdHDH);

                        if (image == null)
                        {
                            SetAlert("Vui lòng chọn ảnh", "error");
                        }

                        string fileName = System.IO.Path.GetFileName(image.FileName);
                        string urlImage = Server.MapPath("~/Image/" + fileName);
                        image.SaveAs(urlImage);

                        model.HinhAnh = fileName;


                        string result = dao.Insert(model);

                        if (!string.IsNullOrEmpty(result))
                        {
                            SetAlert("Thêm mới thành công", "success");
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            SetAlert("Thêm mới thất bại", "error");
                            ModelState.AddModelError("", "Tạo mới thất bại");
                        }
                    }
                    else
                    {
                        SetAlert("Điện thoại đã tồn tại", "warning");
                        return RedirectToAction("Create", "Home");
                    }
                }
            }
            catch (Exception) { }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new HomeDao();
            SanPham sanpham = db.SanPhams.Find(id);
            ViewBag.IdHang = new SelectList(db.HangSXes, "IdHang", "HangSX1", sanpham.IdHang);
            ViewBag.IdHdh = new SelectList(db.HeDHs, "IdHdh", "HeDieuHanh", sanpham.IdHDH);
            var result = dao.Find(id);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SanPham sp, HttpPostedFileBase image)
        {
            ViewBag.IdHang = new SelectList(db.HangSXes, "IdHang", "HangSX1");
            ViewBag.IdHdh = new SelectList(db.HeDHs, "IdHdh", "HeDieuHanh");
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new HomeDao();

                    if (image == null)
                    {
                        SetAlert("Vui lòng chọn ảnh", "error");
                    }
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string urlImage = Server.MapPath("~/Image/" + fileName);
                    image.SaveAs(urlImage);
                    sp.HinhAnh = fileName;

                    string result = "";

                    result = dao.Edit(sp);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        SetAlert("Cập nhật thất bại", "error");
                        //ModelState.AddModelError("", "Tạo mới thất bại");
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
            var dao = new HomeDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session[TestUngDung.Common.Constrants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}