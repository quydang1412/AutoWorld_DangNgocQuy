using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AutoWorld.Models;
using Newtonsoft.Json;
using AutoWorld.Models.ViewModels;

namespace AutoWorld.Controllers
{
    public class ProductsController : Controller
    {
        private AutoWorlDbContext db = new AutoWorlDbContext();

        // GET: Products
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

        public ActionResult FilterCategory(string CategoryID, string Model, string Price, string showRoom, string Name, int pageIndex = 1, int pageSize = 6)
        {
            IEnumerable<Products> products = null;

            double a = 0;
            double b = 0;
            string category = CategoryID;
            string model = Model;
            string price = Price;

            switch (price)
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

            string location = showRoom;
            string name = Name;

            products = db.Products.Include(p => p.Categories).Include(p => p.Location).AsEnumerable().Where(
                p => p.Categories.Name.Contains(category) &&
                p.Description.Contains(model) &&
                p.Price >= b && p.Price < a &&
                p.Location.LocalName.Contains(location) &&
                p.Name.Contains(name)
                );
            //paging for products
            double totalRecord = 0;
            var listProducts = Paging(products, ref totalRecord, pageIndex, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = pageIndex;
            int maxPage = 6;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling(totalRecord / pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            ViewBag.Link = "/Products/FilterCategory?CategoryID=" + CategoryID + "&Model=" + Model + "&Price=" + Price + "&showRoom=" + showRoom + "&Name=" + Name;

            return PartialView("_ProductPartialView", listProducts);
        }

        //GET
        public JsonResult ListName(string keyword)
        {
            var data = db.Products.Where(p => p.Name.Contains(keyword)).Select(p => p.Name).ToList();
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        public IEnumerable<Products> Paging(IEnumerable<Products> p, ref double totalRecord, int pageIndex, int pageSize)
        {
            totalRecord = p.Count();
            IEnumerable<Products> products = p.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return products;
        }

        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName");
            return View();
        }

        // POST: Products/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName", products.LocationId);
            return View(products);
        }

        // GET: Products/Edit/5
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

        // POST: Products/Edit/5
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
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", products.CategoryId);
            ViewBag.LocationId = new SelectList(db.Location, "Id", "LocalName", products.LocationId);
            return View(products);
        }

        // GET: Products/Delete/5
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
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
