using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.DTO;
using Core.BUS;

namespace Web.Controllers
{
    public class CTDDController : Controller
    {
        

        // GET: CTDD
        public ActionResult Index()
        {
            return View(Core.BUS.QLDD_BUS.load());
        }

       

        // GET: CTDD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CTDD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TENDIADIEM,MATP,TENTP_NUOC")] CTDD cTDD)
        {
            if (ModelState.IsValid)
            {
                int t = QLDD_BUS.them(cTDD);
                if(t!=0)
                return RedirectToAction("Index");
            }

            return View(cTDD);
        }

        // GET: CTDD/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDD cTDD = QLDD_BUS.findd(id);
            if (cTDD == null)
            {
                return HttpNotFound();
            }
            return View(cTDD);
        }

        // POST: CTDD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENDIADIEM,MATP,TENTP_NUOC")] CTDD cTDD)
        {
            if (ModelState.IsValid)
            {
                int t = QLDD_BUS.sua(cTDD);
                if(t!=0)
                return RedirectToAction("Index");
            }
            return View(cTDD);
        }

        

        
    }
}
