using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
	public class CartItem
	{
		[Key]
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }

		public CartItem(Products product, int quantity)
		{
			ProductId = product.Id;
			ProductName = product.Name;
			ImageUrl = product.Image;
			Quantity = quantity;
			Price = product.Price;
		}
	}
}