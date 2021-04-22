using AutoWorld.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWorld.Models.ViewModels
{
    public class ProductView
    {
        public ProductView()
        {
        }

		public ProductView(Products product)
		{
			if (product == null)
			{
				return;
			}

			Id = product.Id;
			Name = product.Name;
			FeatureImage = product.Image;
			CategoryId = product.CategoryId;
			Price = product.Price;
			Description = product.Description;
			Status = product.Content;
			LocationId = product.LocationId;
			
			
			
		}

		public long Id { get; set; }

		public string Name { get; set; }

		public string FeatureImage { get; set; }

		[Display(Name = "Category")]
		public long CategoryId { get; set; }

		public double Price { get; set; }

		[AllowHtml]
		public string Description { get; set; }

		public string Status { get; set; }

		[Display(Name = "Location")]
		public long? LocationId { get; set; }

	}
}