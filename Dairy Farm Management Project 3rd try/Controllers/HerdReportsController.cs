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
    public class HerdReportsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();

        // GET: HerdReports
        public ActionResult Index()
        {
            return View(db.HerdReports.ToList());
        }

        // GET: HerdReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerdReport herdReport = db.HerdReports.Find(id);
            if (herdReport == null)
            {
                return HttpNotFound();
            }
            return View(herdReport);
        }

        // GET: HerdReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HerdReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagNo,DateOfBirth,LifeStatus,TypesOfBreed,Gender,Age,ReproductionStatus,TagNoOfMother,TagNoOfFather")] HerdReport herdReport)
        {
            if (ModelState.IsValid)
            {
                db.HerdReports.Add(herdReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herdReport);
        }

        // GET: HerdReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerdReport herdReport = db.HerdReports.Find(id);
            if (herdReport == null)
            {
                return HttpNotFound();
            }
            return View(herdReport);
        }

        // POST: HerdReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagNo,DateOfBirth,LifeStatus,TypesOfBreed,Gender,Age,ReproductionStatus,TagNoOfMother,TagNoOfFather")] HerdReport herdReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herdReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herdReport);
        }

        // GET: HerdReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HerdReport herdReport = db.HerdReports.Find(id);
            if (herdReport == null)
            {
                return HttpNotFound();
            }
            return View(herdReport);
        }

        // POST: HerdReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HerdReport herdReport = db.HerdReports.Find(id);
            db.HerdReports.Remove(herdReport);
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
