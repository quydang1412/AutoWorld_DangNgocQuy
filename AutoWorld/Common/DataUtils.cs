using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
//using Microsoft.Build.Framework.XamlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Common
{
    public class DataUtils
    {

		public static IEnumerable<Categories> GetCategories(AutoWorlDbContext db, Categories current = null)
		{
			if (current == null)
			{
				return db.Categories.ToList();
			}

			// Exclude current category and all its children
			List<Categories> categories = db.Categories.ToList();
			categories.RemoveAll(item => item.Id == current.Id );
			return categories;
		}

		public static IDictionary<string, string> GetRolesList()
		{
			return new Dictionary<string, string> {
				{"admin", "Administrator" },
				{"user", "Normal User" }
			};
		}

		public static int GetNumberOfCartItems(object collection)
		{
			if (!(collection is List<CartItem>))
			{
				return 0;
			}
			return (collection as List<CartItem>).Count;
		}
	}
}