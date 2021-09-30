using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dairy_Farm_Management_Project_3rd_try.Models;

namespace Dairy_Farm_Management_Project_3rd_try.Controllers
{
    public class VaccineDetailsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();

        // GET: VaccineDetails
        public ActionResult Index()
        {
            return View(db.VaccineDetails.ToList());
        }

        // GET: VaccineDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineDetail vaccineDetail = db.VaccineDetails.Find(id);
            if (vaccineDetail == null)
            {
                return HttpNotFound();
            }
            return View(vaccineDetail);
        }

        // GET: VaccineDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccineDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VaccineNo,NameOfDisease,MinimumAge")] VaccineDetail vaccineDetail)
        {
            if (ModelState.IsValid)
            {
                db.VaccineDetails.Add(vaccineDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccineDetail);
        }

        // GET: VaccineDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineDetail vaccineDetail = db.VaccineDetails.Find(id);
            if (vaccineDetail == null)
            {
                return HttpNotFound();
            }
            return View(vaccineDetail);
        }

        // POST: VaccineDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VaccineNo,NameOfDisease,MinimumAge")] VaccineDetail vaccineDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccineDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccineDetail);
        }

        // GET: VaccineDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccineDetail vaccineDetail = db.VaccineDetails.Find(id);
            if (vaccineDetail == null)
            {
                return HttpNotFound();
            }
            return View(vaccineDetail);
        }

        // POST: VaccineDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccineDetail vaccineDetail = db.VaccineDetails.Find(id);
            db.VaccineDetails.Remove(vaccineDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
