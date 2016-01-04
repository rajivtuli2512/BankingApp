using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankingApp.Controllers
{
    public class BankAccountsController : Controller
    {
        //create a Entity model instance 
        public BankingAppDB db = new BankingAppDB();

        //Account Summary method to show the Acccount Summary View after a successful Login
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Index(String userid)
        {
            IEnumerable<AccountSummary> rows = db.AccountsSummary
                                                   .Where(a => a.UserID == userid)
                                                   .ToList();
            ViewBag.CustomerName = db.Customer_Detail.Where(o => o.UserID == userid).FirstOrDefault().Name;
            ViewBag.userid = userid;
            ViewBag.curows = rows;
            return View();
        }

        //method to fetch the user info like name, email address etc and show on the view.
        //not completed though as this was not the key point, asked in the test
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult AccountInfo(String userid)
        {
            return View();
        }

        //method responsible to show the accont statement/history.
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Statement(String acct)
        {
            IEnumerable<Statement> statement_rows = db.Statements
                                                      .Where(o => o.Account == acct)
                                                      .OrderByDescending(o => o.Updatedat);
            ViewBag.statement_rows = statement_rows;
            return View();
        }

        //method to create the fund transfer page with drop down list of from and to account infomation.
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult FundTransfer(String userid)
        {
            ViewBag.fromAccount_List = new SelectList(db.customeraccounts.Where(o=>o.UserID==userid).ToList(), "Account", "Account");
            ViewBag.toAccount_List = new SelectList(db.Benefeciries.Where(o => o.UserID == userid).ToList(), "Account", "Account");
            FundTransfer b = new FundTransfer();
            return View(b);
        }

        //post method to evaluate the data posted by fundtransfer view and update the database for both 
        //accounts to reflect the same in account statement.
        [HttpPost, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult FundTransfer(FundTransfer ft)
        {
            Statement s = new Statement();
            int facntbal = db.AccountsSummary.Where(o => o.Account == ft.FromAccount).FirstOrDefault().Balance;
            int tacntbal = db.AccountsSummary.Where(o => o.Account == ft.ToAccount).FirstOrDefault().Balance;
            if (facntbal >= ft.Amount)
            {
                s.Account = ft.FromAccount;
                s.Credit = 0;
                s.Debit = ft.Amount;
                s.Balance = facntbal - ft.Amount;
                s.Updatedat = DateTime.UtcNow;
                s.comment = "Transferred to :" + ft.ToAccount;
                db.Statements.Add(s);

                Statement a = new Statement();
                a.Account = ft.ToAccount;
                a.Credit = ft.Amount;
                a.Debit = 0;
                a.Balance = tacntbal + ft.Amount;
                a.Updatedat = DateTime.UtcNow;
                a.comment = "Transferred from: " + ft.FromAccount;
                db.Statements.Add(a);
                db.SaveChanges();
            }          
            return RedirectToAction("Statement", "BankAccounts", new {acct=ft.FromAccount });
        }

        //method to fetch the current balance against an account. this is being used at the fund transfer screen
        //to show the available balance when selected a from account from drop down list.
        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public int getbalance(String account)
        {
            if (account == "")
            { return 0; }
            else
            {
                int avalbal = db.AccountsSummary.Where(o => o.Account == account).FirstOrDefault().Balance;
                return avalbal;
            }
        }

        //method to dispose the db variable created above.
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

}