using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCluc.Models;

namespace MVCluc.Controllers
{
    public class HomeController : Controller
    {
        ProductDbContext db = new ProductDbContext();
        public ActionResult Index(int? maloai)
        {
            if(maloai==null)
            {
                maloai = db.LoaiSPs.First().MaLoai;
            }
            ViewBag.list_sp = db.SanPhams.Where(x => x.MaLoai == maloai).ToList();
            ViewBag.listcate = db.LoaiSPs.ToList();

            return View();
        }
        [HttpGet]
        public ActionResult ThemSP()
        {
            ViewBag.listcate = db.LoaiSPs.ToList();
            List<LoaiSP> loaisp = db.LoaiSPs.ToList();
            List<SelectListItem> item8 = new List<SelectListItem>();
            foreach (var c in loaisp)
            {
                item8.Add(new SelectListItem
                {
                    Text = c.Ten,
                    Value = c.MaLoai.ToString()
                });
            }

            ViewBag.Ten = item8;
            SanPham sp = new SanPham();
            return View(sp);
        }
        [HttpPost]
        public ActionResult ThemSP(SanPham sp)
        {
            var id = db.SanPhams.Where(x => x.MaSP == sp.MaSP).SingleOrDefault();
            if(id==null)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ViewDetail(int MaSP)
        {
            ViewBag.listcate = db.LoaiSPs.ToList();
            SanPham sp = db.SanPhams.Find(MaSP);
            return View(sp);
        }
        public ActionResult add()
        {
           
            return View();
        }
    }
}