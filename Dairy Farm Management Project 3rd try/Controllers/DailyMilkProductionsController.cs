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
    public class DailyMilkProductionsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();

        // GET: DailyMilkProductions
        public ActionResult Index()
        {
            var dailyMilkProductions = db.DailyMilkProductions.Include(d => d.HerdReport);
            var p = dailyMilkProductions.ToList();
            var q = new List<DailyMilkProduction>();

            DateTime datetime = System.DateTime.Now;
            foreach(var item in p)
            {
                if(item.Date==datetime.Date)
                {
                    q.Add(item);
                }
            }
            return View(dailyMilkProductions.ToList());
        }
        

        // GET: DailyMilkProductions/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyMilkProduction dailyMilkProduction = db.DailyMilkProductions.Find(id);
            if (dailyMilkProduction == null)
            {
                return HttpNotFound();
            }
            return View(dailyMilkProduction);
        }

        // GET: DailyMilkProductions/Create
        public ActionResult Create()
        {
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus");
            return View();
        }

        // POST: DailyMilkProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,TagNo,TotalMilk")] DailyMilkProduction dailyMilkProduction)
        {
            if (ModelState.IsValid)
            {
                db.DailyMilkProductions.Add(dailyMilkProduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", dailyMilkProduction.TagNo);
            return View(dailyMilkProduction);
        }

        // GET: DailyMilkProductions/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyMilkProduction dailyMilkProduction = db.DailyMilkProductions.Find(id);
            if (dailyMilkProduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", dailyMilkProduction.TagNo);
            return View(dailyMilkProduction);
        }

        // POST: DailyMilkProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,TagNo,TotalMilk")] DailyMilkProduction dailyMilkProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyMilkProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagNo = new SelectList(db.HerdReports, "TagNo", "LifeStatus", dailyMilkProduction.TagNo);
            return View(dailyMilkProduction);
        }

        // GET: DailyMilkProductions/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyMilkProduction dailyMilkProduction = db.DailyMilkProductions.Find(id);
            if (dailyMilkProduction == null)
            {
                return HttpNotFound();
            }
            return View(dailyMilkProduction);
        }

        // POST: DailyMilkProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            DailyMilkProduction dailyMilkProduction = db.DailyMilkProductions.Find(id);
            db.DailyMilkProductions.Remove(dailyMilkProduction);
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
