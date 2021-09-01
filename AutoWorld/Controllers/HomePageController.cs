using AutoWorld.DAO;
using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWorld.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submit Contact from Index
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SubmitContact(string name, string email, string phone, string message)
        {
            Contact contact = new Contact();
            contact.Name = name;
            contact.Email = email;
            contact.Phone = phone;
            contact.Message = message;

            var dao = new ContactDAO();
            if (dao.InsertContactInfor(contact))
            {
                //TempData["Message"] = new NotificationMessage("your action was success","success");
                //SetAlert("your action was success", "success");
                return Json(new
                {
                    status = true
                }); 
            }

            SetAlert("your action was fail", "error");

            return Json(new
            {
                status = false
            });
        }

        protected void SetAlert(string message,string messageType)
        {
            
            TempData["AlertMessage"] = message;
         
            switch (messageType)
            {
                case "success":
                    TempData["AlertType"] = "alert-success";
                    break;
                case "error":
                    TempData["AlertType"] = "alert-danger";
                    break;
                case "warn":
                    TempData["AlertType"] = "alert-warning";
                    break;
                default:
                    TempData["AlertType"] = "alert-info";
                    break;
            }
        }
    }
}