using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dairy_Farm_Management_Project_3rd_try.Models;
using System.Data;
using System.Data.Entity;

namespace Dairy_Farm_Management_Project_3rd_try.Controllers
{
    public class DashboardsController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();
        // GET: Dashboards
        public ActionResult Index()
        {
            dashboardInfo d = new dashboardInfo();
            int ans = 0;
            int ans0 = 0;
            d.totalCows = db.HerdReports.Count();
            foreach (var item1 in db.HerdReports.ToList())
            {
                if(item1.LifeStatus=="Alive")
                {
                    ans0++;
                }
            }
            d.numCowsAlive = ans0;

            List<dueVaccination> list1 = new List<dueVaccination>();

            foreach (var item1 in db.HerdReports.ToList())
            {
                foreach (var item2 in db.VaccineDetails.ToList())
                {
                    if (item1.Age < item2.MinimumAge)
                    {

                    }
                    else
                    {
                        var vacci = db.Vaccinations.Find(item1.TagNo);
                        if (vacci == null)
                        {

                            dueVaccination ltemp = new dueVaccination();
                            ltemp.TagNo = item1.TagNo;
                            ltemp.VaccineName = item2.NameOfDisease;
                            ltemp.VaccineNo = item2.VaccineNo;
                            list1.Add(ltemp);
                            ans++;
                        }

                    }
                }
            }
            d.numDuetobeVaccinated = ans;
            DateTime dateTime = DateTime.Now;
            int ans2 = 0;

            foreach (var item1 in db.DailyMilkProductions.ToList())
            {
                if (item1.Date.Month == dateTime.Month)
                {
                    ans2 += item1.TotalMilk;
                }
            }
            d.averageMilkProductionRate = ans2;

            int ans3 = 0;
            foreach (var item1 in db.DailyMilkProductions.ToList())
            {
                if (item1.Date.Month == dateTime.Month && item1.Date.Day == dateTime.Day && item1.Date.Year == dateTime.Year)
                {
                    ans3 += item1.TotalMilk;
                }
            }
            d.totalMilkToday = ans3;

            d.dueTobeVaccinatedlist = list1;

            return View(d);
        }
    }
}