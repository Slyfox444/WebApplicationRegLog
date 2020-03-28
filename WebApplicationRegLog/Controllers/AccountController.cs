using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationRegLog.Models;
using WebApplicationRegLog.ModelsDB;

namespace WebApplicationRegLog.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities userDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            UserModel userModel = new UserModel();
            return View(userModel);
        }


        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (!userDBEntities.Users.Any(m => m.Username == userModel.UserName))
                {
                    Users users = new Users();
                    users.Username = userModel.UserName;
                    users.Firstname = userModel.FirstName;
                    users.Lastname = userModel.LastName;
                    users.Password = userModel.Password;
                    userDBEntities.Users.Add(users);
                    userDBEntities.SaveChanges();
                    userModel = new UserModel();
                    ViewBag.Succesmessage = "User is successfully added. ";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Error", "Username already exist!");
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginModel loginModel = new LoginModel();

            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (userDBEntities.Users.Where(m => m.Username == loginModel.Username && m.Password == loginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid Username or Password");
                    return View();
                }
                else
                {
                    Session["Username"] = loginModel.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}