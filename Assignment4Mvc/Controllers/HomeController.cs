using Assignment4Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Assignment4Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MyDbContext context = new MyDbContext();
            return View(context.Accounts);
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateAccount(Account a)
        {
            MyDbContext context = new MyDbContext();
            context.Accounts.Add(a);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? accno)
        {
            MyDbContext context = new MyDbContext();
            var account_to_edit = (from a in context.Accounts
                                   where a.AccountNumber == accno
                                   select a).SingleOrDefault();
            return View(account_to_edit);
        }
        public ActionResult EditAccount(Account a)
        {
            MyDbContext context = new MyDbContext();
            context.Entry<Account>(a).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? accno)
        {
            MyDbContext context = new MyDbContext();
            var account_to_delete = (from a in context.Accounts
                                     where a.AccountNumber == accno
                                     select a).SingleOrDefault();
            context.Entry<Account>(account_to_delete).State =
                    System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}

