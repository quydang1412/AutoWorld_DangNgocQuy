using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoWorld.Common;
using AutoWorld.Models;

namespace AutoWorld.Areas.Admin.Controllers
{
    [Authorize]
    [CustomActionFilter]
    [ExceptionHandlerFilter]

    public class ProductsController : BaseController
    {
        private AutoWorlDbContext db = new AutoWorlDbContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Categories).Include(p => p.Location);
            return View(products.ToList());
        }

        public ActionResult SearchProduct()
        {
            var products = db.Products.Include(p => p.Categories).Include(p => p.Location);
            return View("SearchProduct", products.ToList());
        }

        [HttpPost]
        public ActionResult Search()
        {
            double a = 0;
            double b = 0;
            string category = HttpContext.Request.Form["CategoryID"];
            string model = HttpContext.Request.Form["Model"];

            switch (HttpContext.Request.Form["Price"])
            {
                case "all":
                    {
                        a = 1000000;
                        b = 0;
                        break;
                    }
                case "prl15":
                    {
                        a = 15000;
                        b = 0;
                        break;
                    }
                case "pr15_100":
                    {
                        a = 100000;
                        b = 15000;
                        break;
                    }
                case "pru100":
                    {
                        a = 1000000;
                        b = 100000;
                        break;
                    }

            }

            string location = HttpContext.Request.Form["showRoom"];

            var products = db.Products.Include(p => p.Categories).Include(p => p.Location).AsEnumerable().Where(
                p => p.Categories.Name.Contains(category) &&
                p.Description.Contains(model) &&
                p.Price >= b && p.Price < a &&
                p.Location.LocalName.Contains(location)
                );
            //var products = db.Products.Include(p => p.Categories).Include(p => p.Location).AsEnumerable().Where(p => p.CategoryId == long.Parse(HttpContext.Request.Form["CategoryID"]));
            return View("Index", products);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,CategoryId,Price,Description,Content,LocationId")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName", products.LocationId);
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName", products.LocationId);
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,CategoryId,Price,Description,Content,LocationId")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName", products.LocationId);
            return View(products);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            SetSuccessNotification();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
