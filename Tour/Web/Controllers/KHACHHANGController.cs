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
    public class KHACHHANGController : Controller
    {

        // GET: KHACHHANG
        public ActionResult Index()
        {
            return View(QLKHACH_BUS.load());
        }

        

        // GET: KHACHHANG/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: KHACHHANG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HOTEN,CMND,GIOITINH,DIACHI,DT")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                int t = QLKHACH_BUS.them(kHACHHANG);
                if(t!=0)
                return RedirectToAction("Index");
            }
            
            return View(kHACHHANG);
        }

        // GET: KHACHHANG/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = QLKHACH_BUS.find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            
            return View(kHACHHANG);
        }

        // POST: KHACHHANG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HOTEN,CMND,GIOITINH,DIACHI,DT")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                int t = QLKHACH_BUS.sua(kHACHHANG);
                if (t != 0) ;
                return RedirectToAction("Index");
            }
            
            return View(kHACHHANG);
        }

        

       
    }
}
