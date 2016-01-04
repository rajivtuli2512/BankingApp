using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApp.Controllers
{
    public class AuthenticateController : Controller
    {
        public BankingAppDB db = new BankingAppDB();

        public object LicenseFile { get; private set; }

        //Very first Page to Load
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Login()
        {
            ViewBag.SuccessLogin = false;
            HttpContext.Application["Global_UserId"] = "";
            return View();
        }
        
        //Get the credentials and check against the DB
        [HttpPost, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Login(Login loginmodel)
        {
            String userid=loginmodel.UserID;
            String pass = loginmodel.Password;
            Int32 rows = 0;
            rows = db.Logins.Where(o => o.UserID == userid && o.Password==pass).Count();
            
            if (rows!=0)
            {
                ViewBag.SuccessLogin = true;
                TempData["bSuccessLogin"] = "true";
                HttpContext.Application["Global_UserId"] = userid;
                return RedirectToAction("Index", "BankAccounts",new { userid=userid });
            }
            else
            {
                ViewBag.SuccessLogin = false;
                TempData["bSuccessLogin"] = "false";
                return View();
            }
        }
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        //clear the user infomation and redirect to login page.
        public ActionResult Logout()
        {
            TempData["bSuccessLogin"] = "false";
            HttpContext.Application["Global_UserId"] = "";
            return RedirectToAction("Login", "Authenticate");
            
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
    
    
}