using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using OnlineGame.Filters;
using OnlineGame.Models;
using Models;
using Models.Repositories;

namespace OnlineGame.Controllers
{
    public class LoginController : Controller
    {
        private AccountRepository ar = new AccountRepository();

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid && ar.UserIsValid(login.Email, login.Password))
            {
                Session["CurrentUser"] = ar.GetUserByEmail(login.Email);
                return RedirectToAction("Index", "Game");
            }
            else
                return View("Index", login);
        }

        public ActionResult Register()
        {
            //var salt = Encrypting.CreateSalt(8);
            //var passwordHash = Encrypting.GetMd5Hash(collection["Password"], salt); 

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel regform)
        {
            if (ModelState.IsValid)
            {
                User u = new User();    
                var salt = Encrypting.CreateSalt(8);
                var passwordHash = Encrypting.GetMd5Hash(regform.Password, salt);

                u.Email = regform.Email;
                u.Password = passwordHash;
                u.Salt = salt;
                u.Created = DateTime.Now;
                u.RoleId = -1;
                u.Verified = true;//fix this

                ar.Add(u);
                ar.Save(); 

                return RedirectToAction("Index", "Game");
            }
            else
                return View("Register", regform);
        }
    }
}
