using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AutoWorld.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView model)
        {
            AutoWorlDbContext db = new AutoWorlDbContext();
            string returnUrl = Request.Params["ReturnUrl"];
            var userRec = db.Accounts.FirstOrDefault(user => user.LoginName.ToLower() ==
            model.LoginName && user.Password == model.Password);
            if (userRec != null)
            {
                SignInUser(userRec.LoginName, userRec.Users.First().Roles, model.RememberLogin);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("DashBoard", "DashBoard", new { area = "Admin" });

            }

            ModelState.AddModelError("", "Invalid Username or Password");
            
            return View();
        }

        private void SignInUser(string username, string role, bool isPersistent)
        {
            // Initialization.    
            var claims = new List<Claim>();
            try
            {
                // Setting    
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, role));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.    
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
        }

        public ActionResult SignOut()
        {
            try
            {
                // Setting.    
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign Out.    
                authenticationManager.SignOut();
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            return RedirectToAction("Login");
        }

    }
}