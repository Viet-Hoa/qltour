using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.BUS;
using Core.DTO;

namespace Web.Controllers
{
    public class QLNVController : Controller
    {
        public ActionResult Index()
        {
            List<NHANVIEN> d = Core.BUS.QLNV_BUS.load();
            return View(d);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,HOTEN,TENDN,MK")] NHANVIEN d)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLNV_BUS.them(d);
                if(t==1)
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            NHANVIEN d = Core.BUS.QLNV_BUS.findnv(id);
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HOTEN,TENDN,MK")] NHANVIEN d)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLNV_BUS.sua(d);
                if(t==1)
                return RedirectToAction("Index");
            }
            return View(d);
        }
        public ActionResult List(int id)
        {
            ViewBag.nv = Core.BUS.QLNV_BUS.findnv(id);
            ViewBag.st = Core.BUS.QLNV_BUS.demtour(id, DateTime.Now.AddDays(-30), DateTime.Now);
            List<PHANCONG> k = Core.BUS.QLNV_BUS.load(id);
            return View(k);
        }
        public ActionResult demtour(int ma,DateTime tu,DateTime den)
        {
            ViewBag.nv = QLNV_BUS.findnv(ma);
            ViewBag.tu = tu;
            ViewBag.den = den;
            ViewBag.st = Core.BUS.QLNV_BUS.demtour(ma, tu, den);
            return RedirectToAction("Thongke");
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            ViewBag.IDDOAN = new SelectList(Core.BUS.QLDOAN_BUS.load(), "ID", "TENDOAN");
            ViewBag.IDNHV = new SelectList(Core.BUS.QLNV_BUS.loadnv(), "ID", "TENNV");
            PHANCONG dt = new PHANCONG();
            dt.IDNV = id;
            return View(dt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,IDDOAN,IDNV,IDNHV")] PHANCONG dt)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLNV_BUS.them(dt);
                if (t == 1)
                    return RedirectToAction("List",new { id = dt.IDNV });
            }
            ViewBag.IDDOAN = new SelectList(Core.BUS.QLDOAN_BUS.load(), "ID", "TENDOAN");
            ViewBag.IDNHV = new SelectList(Core.BUS.QLNV_BUS.loadnv(), "ID", "TENNV");
            return View(dt);
        }
        

    }
}