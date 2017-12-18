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
            ViewBag.IDTOUR = new SelectList(Core.BUS.QLTOUR_BUS.load(), "ID", "TENTOUR");
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
            ViewBag.IDTOUR = new SelectList(Core.BUS.QLTOUR_BUS.load(), "ID", "TENTOUR");
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.IDTOUR = new SelectList(Core.BUS.QLTOUR_BUS.load(), "ID", "TENTOUR");
            DOAN d = Core.BUS.QLDOAN_BUS.findd(id);
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENDOAN,IDTOUR,NGAYBD,NGAYKT,CHITIET,CHIPHI")] DOAN d)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLDOAN_BUS.sua(d);
                if(t==1)
                return RedirectToAction("Index");
            }
            ViewBag.IDTOUR = new SelectList(Core.BUS.QLTOUR_BUS.load(), "ID", "TENTOUR");
            return View(d);
        }
        public ActionResult List(int id)
        {
            ViewBag.doan = Core.BUS.QLDOAN_BUS.findd(id);
            List<DATTOUR> k = Core.BUS.QLDOAN_BUS.load(id);
            return View(k);
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            ViewBag.IDKH = new SelectList(Core.BUS.QLKHACH_BUS.load(),"ID","HOTEN");
            DATTOUR dt = new DATTOUR();
            dt.IDDOAN = id;
            return View(dt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "ID,IDKH,IDDOAN")] DATTOUR dt)
        {
            if (ModelState.IsValid)
            {
                int t = Core.BUS.QLDOAN_BUS.them(dt);
                if (t == 1)
                    return RedirectToAction("List",new { id = dt.IDDOAN });
            }
            ViewBag.IDKH = new SelectList(Core.BUS.QLKHACH_BUS.load(), "ID", "HOTEN");
            return View(dt);
        }
        public ActionResult Delete(int id)
        {            
            DATTOUR dt = Core.BUS.QLDOAN_BUS.finddt(id);
            ViewBag.id = dt.IDDOAN;
            if (dt == null)
            {
                return HttpNotFound();
            }
            return View(dt);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int dt = Core.BUS.QLDOAN_BUS.finddt(id).IDDOAN;
            Core.BUS.QLDOAN_BUS.xoa(id);
            return RedirectToAction("List", new { id = dt });
        }

    }
}