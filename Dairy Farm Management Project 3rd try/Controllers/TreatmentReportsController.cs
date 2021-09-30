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
    public class TreatmentReportsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();

        // GET: TreatmentReports
        public ActionResult Index()
        {
            var treatmentReports = db.TreatmentReports.Include(t => t.HerdReport);
            return View(treatmentReports.ToList());
        }

        // GET: TreatmentReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentReport treatmentReport = db.TreatmentReports.Find(id);
            if (treatmentReport == null)
            {
                return HttpNotFound();
            }
            return View(treatmentReport);
        }

        // GET: TreatmentReports/Create
        public ActionResult Create()
        {
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus");
            return View();
        }

        // POST: TreatmentReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentNo,TagNo,Date,BodyTemperature,Symptoms,Treatment,Diagnosis,Medicine")] TreatmentReport treatmentReport)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentReports.Add(treatmentReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", treatmentReport.TagNo);
            return View(treatmentReport);
        }

        // GET: TreatmentReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentReport treatmentReport = db.TreatmentReports.Find(id);
            if (treatmentReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", treatmentReport.TagNo);
            return View(treatmentReport);
        }

        // POST: TreatmentReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentNo,TagNo,Date,BodyTemperature,Symptoms,Treatment,Diagnosis,Medicine")] TreatmentReport treatmentReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", treatmentReport.TagNo);
            return View(treatmentReport);
        }

        // GET: TreatmentReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentReport treatmentReport = db.TreatmentReports.Find(id);
            if (treatmentReport == null)
            {
                return HttpNotFound();
            }
            return View(treatmentReport);
        }

        // POST: TreatmentReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentReport treatmentReport = db.TreatmentReports.Find(id);
            db.TreatmentReports.Remove(treatmentReport);
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
