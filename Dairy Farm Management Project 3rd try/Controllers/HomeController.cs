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
    public class HomeController : Controller
    {
        private DairyFarm3rdTryEntities db = new DairyFarm3rdTryEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult form1(string txtName,string txtEmail,string txtPassword)
        {

            //var localdata = db.SignUps.ToList();
            //foreach()

            SignUp signup = db.SignUps.Find(txtEmail);
            SignUp temp  = new SignUp();
            temp.Email = txtEmail;
            temp.Name = txtName;
            temp.Password = txtPassword;

            if(signup == null)
            {
                db.SignUps.Add(temp);
                db.SaveChanges();
                ViewBag.Message = "Sign up complete successfully";
                return RedirectToAction("Index", "Dashboards");
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction(txtName, txtPassword);
        }
        public ActionResult form2(string txtEmail, string txtPassword)
        {

            //var localdata = db.SignUps.ToList();
            //foreach()

            SignUp signup = db.SignUps.Find(txtEmail);
            

            

            if (signup == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if(signup.Password==txtPassword)
            {
                return RedirectToAction("Index", "Dashboards");
            }
            return RedirectToAction("Index", "Home");
            //return RedirectToAction(txtName, txtPassword);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}