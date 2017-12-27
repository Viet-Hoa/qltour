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
    public class NHIEMVUController : Controller
    {
        

        // GET: NHIEMVU
        public ActionResult Index()
        {
            return View(QLNVU_BUS.load());
        }

        

        // GET: NHIEMVU/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHIEMVU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TENNV,NOIDUNG")] NHIEMVU nHIEMVU)
        {
            if (ModelState.IsValid)
            {
                int t = QLNVU_BUS.them(nHIEMVU);
                if(t!=0)
                return RedirectToAction("Index");
            }

            return View(nHIEMVU);
        }

        // GET: NHIEMVU/Edit/5
        public ActionResult Edit(int id)
        {
            
            
            NHIEMVU nHIEMVU = QLNVU_BUS.find(id);
            if (nHIEMVU == null)
            {
                return HttpNotFound();
            }
            return View(nHIEMVU);
        }

        // POST: NHIEMVU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TENNV,NOIDUNG")] NHIEMVU nHIEMVU)
        {
            if (ModelState.IsValid)
            {
                int t = QLNVU_BUS.sua(nHIEMVU);
                if(t!=0)
                return RedirectToAction("Index");
            }
            return View(nHIEMVU);
        }

        
    }
}
