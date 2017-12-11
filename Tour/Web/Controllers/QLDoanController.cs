using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.BUS;
using Core.DTO;

namespace Web.Controllers
{
    public class QLDoanController : Controller
    {
        public ActionResult Index()
        {
            List<DOAN> doan = Core.BUS.QLDOAN_BUS.load();
            return View(doan);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TOUR = new SelectList(Core.BUS.QLTOUR_BUS.load());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TENDOAN,IDTOUR,NGAYBD,NGAYKT,CHITIET,CHIPHI")] DOAN d)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLDOAN_BUS.them(d);
                if(t==1)
                return RedirectToAction("Index");
            }
            ViewBag.TOUR = new SelectList(Core.BUS.QLTOUR_BUS.load());
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TOUR = new SelectList(Core.BUS.QLTOUR_BUS.load());
            DOAN d = Core.BUS.QLDOAN_BUS.findd(id);
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENDOAN,IDTOUR,NGAYBD,NGAYKT,CHITIET,CHIPHI")] DOAN d)
        {
            if (ModelState.IsValid)
            {
                int t=Core.BUS.QLDOAN_BUS.sua(d);
                if(t==1)
                return RedirectToAction("Index");
            }
            ViewBag.TOUR = new SelectList(Core.BUS.QLTOUR_BUS.load());
            return View(d);
        }
        public ActionResult List(int id)
        {
            List<DATTOUR> k = Core.BUS.QLDOAN_BUS.load(id);
            return View(k);
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            ViewBag.KHACH = new SelectList(Core.BUS.QLKHACH_BUS.load());
            ViewBag.IDDOAN = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,IDKH,IDDOAN")] DATTOUR dt)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLDOAN_BUS.them(dt);
                if (t == 1)
                    return RedirectToAction("List");
            }
            ViewBag.TOUR = new SelectList(Core.BUS.QLTOUR_BUS.load());
            ViewBag.IDDOAN = dt.ID;
            return View(dt);
        }
    }
}