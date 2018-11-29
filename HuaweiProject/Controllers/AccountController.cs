using HuaweiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HuaweiProject.Controllers
{
    public class AccountController : Controller
    {
      static  List<Users> users = new List<Users>();
        // GET: Account
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user, string Password,string ConfirmPassword)
        {
            if (Password == ConfirmPassword) {
            
            if (ModelState.IsValid)
            {
                user.ID = Guid.NewGuid();
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
            }
            else
                return RedirectToAction("Register", "Account");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var result = users.Find(w => w.UserName == username && w.Password == password);
            if (result!=null)
            {
                Session["ID"] = result.ID;
                Session["name"] = result.Name + " " + result.Surname;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult LogOut()
        {
           // Session.Abandon();
            Session.Clear();
           // FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");

            //    Session.Abandon();
            //    Session.Clear();
            //    return RedirectToAction("Login","Account");
            //
        }
    }
}