﻿using AutoWorld.Common;
using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWorld.Controllers
{
	public class CartController : Controller
	{
		AutoWorlDbContext db = new AutoWorlDbContext();
		// GET: Cart
		public ActionResult Index()
		{
			return View(GetCartItems());
		}

		public ActionResult AddToCart(int id, int quantity = 1) // parameter must named "id" to match name on route
		{
			var product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			// TODO:
			// Check if item already be in cart
			// If not yet, add item to cart
			if (GetCartItems().Any(item => item.ProductId == product.Id))
			{
				TempData["Message"] = new NotificationMessage(
					string.Format("Product \"{0}\" has already been in cart.", product.Name),
					"error");
			}
			else
			{
				GetCartItems().Add(new CartItem(product, quantity));
				TempData["Message"] = new NotificationMessage(
					string.Format("Product \"{0}\" is added to cart.", product.Name),
					"success");
				//ViewBag.CountCart = DataUtils.GetNumberOfCartItems(Session["Cart"]);
			}
			if (Request.UrlReferrer != null)
			{
				return PartialView("_Notification");
				//return Redirect(Request.UrlReferrer.AbsoluteUri);
			}
			return RedirectToAction("Index");
		}


		[HttpPost]
		public ActionResult UpdateCart(long[] productIds, int[] quantities)
		{
			var items = GetCartItems();
			for (int i = 0; i < productIds.Length; i++)
			{
				var cartItem = items.Where(product => product.ProductId == productIds[i]).First();
				cartItem.Quantity = quantities[i];
			}
			return RedirectToAction("Index");
		}

		public ActionResult RemoveFromCart(int id)
		{
			var product = db.Products.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}
			var cartItem = GetCartItems().Where(item => item.ProductId == id).First();
			GetCartItems().Remove(cartItem);
			return RedirectToAction("Index");
		}

		// Display checkout form
		public ActionResult CheckOut()
		{
			return View();
		}

		// Submit check out information
		[HttpPost]
		public ActionResult CheckedOut()
		{
			return View();
		}

		// Display success message after checked out
		public ActionResult CompletedOrder()
		{
			return View();
		}

		private List<CartItem> GetCartItems()
		{
			if (Session["Cart"] == null)
			{
				Session["Cart"] = new List<CartItem>();

			}
			return Session["Cart"] as List<CartItem>;
		}

		public JsonResult UpdateCartNumber()
        {
			var data = DataUtils.GetNumberOfCartItems(Session["Cart"]);
			return Json(new
			{
				data = data,
				status = true
			}, JsonRequestBehavior.AllowGet);
		}
	}
}