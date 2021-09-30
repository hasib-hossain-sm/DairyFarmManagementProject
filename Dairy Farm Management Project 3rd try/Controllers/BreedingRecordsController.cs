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
    public class BreedingRecordsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();

        // GET: BreedingRecords
        public ActionResult Index()
        {
            var breedingRecords = db.BreedingRecords.Include(b => b.HerdReport);
            return View(breedingRecords.ToList());
        }

        // GET: BreedingRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingRecord breedingRecord = db.BreedingRecords.Find(id);
            if (breedingRecord == null)
            {
                return HttpNotFound();
            }
            return View(breedingRecord);
        }

        // GET: BreedingRecords/Create
        public ActionResult Create()
        {
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus");
            return View();
        }

        // POST: BreedingRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreedingNo,TagNo,PreviousCalvingDate,SuccessfulSemen,PregnancyTestDate,PregnancyStatus,ExpectedCalvingDate,ActualCalvingDate")] BreedingRecord breedingRecord)
        {
            if (ModelState.IsValid)
            {
                db.BreedingRecords.Add(breedingRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", breedingRecord.TagNo);
            return View(breedingRecord);
        }

        // GET: BreedingRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingRecord breedingRecord = db.BreedingRecords.Find(id);
            if (breedingRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", breedingRecord.TagNo);
            return View(breedingRecord);
        }

        // POST: BreedingRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreedingNo,TagNo,PreviousCalvingDate,SuccessfulSemen,PregnancyTestDate,PregnancyStatus,ExpectedCalvingDate,ActualCalvingDate")] BreedingRecord breedingRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breedingRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", breedingRecord.TagNo);
            return View(breedingRecord);
        }

        // GET: BreedingRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreedingRecord breedingRecord = db.BreedingRecords.Find(id);
            if (breedingRecord == null)
            {
                return HttpNotFound();
            }
            return View(breedingRecord);
        }

        // POST: BreedingRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BreedingRecord breedingRecord = db.BreedingRecords.Find(id);
            db.BreedingRecords.Remove(breedingRecord);
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
