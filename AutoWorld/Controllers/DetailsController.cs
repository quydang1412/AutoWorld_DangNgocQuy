using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWorld.Controllers
{
    public class DetailsController : Controller
    {
        AutoWorlDbContext db = new AutoWorlDbContext();
        // GET: Details
        public ActionResult Index()
        {
            return View(Details);
        }

        //public ActionResult Index(DetailsView model)
        //{
        //    AutoWorlDbContext db = new AutoWorlDbContext();
        //    model.seats = db.Products.ElementAt(1).Description;

        //    return View();
        //}

        public ActionResult DetailProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            Details = new DetailsView(product);

            return View("Index");
        }



        public DetailsView Details { get; set; }
    }
}