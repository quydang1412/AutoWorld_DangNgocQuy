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
                return Json(new
                {
                    status = true
                }); 
            }

            return Json(new
            {
                status = false
            });
        }
    }
}