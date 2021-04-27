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
        //public ActionResult Index()
        //{
        //    return View(Details);
        //}

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

            if(product.Content == null)
            {
                Details = new DetailsView(product);

                return View(Details);
            }

            if (product.Content.Equals("car",StringComparison.OrdinalIgnoreCase))
            {
                Details = new DetailsView(product);

                return View(Details);
            }else if (product.Content.Equals("motor",StringComparison.OrdinalIgnoreCase)){
                Details1 = new DetailsView1(product);

                return View("DetailProductMotor", Details1);
            }
            
            
            return View();
            
        }

        //public ActionResult DetailProductMotor(int id)
        //{
        //    var product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    Details1 = new DetailsView1(product);

        //    return View(Details1);
        //}

        public DetailsView Details { get; set; }
        public DetailsView1 Details1 { get; set; }
    }
}