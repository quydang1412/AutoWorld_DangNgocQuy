using AutoWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AutoWorld.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
		 //GET: Admin/Base
		protected void SetSuccessNotification()
		{
			//string controller = RouteData.GetRequiredString("controller");
			string action = RouteData.GetRequiredString("action");
			if ("edit" == action?.ToLower())
			{
				TempData.Add("Message", "Item is saved.");
			}
			else if ("deleteconfirmed" == action?.ToLower())
			{
				TempData.Add("Message", "Item is deleted.");
			}
			else
			{
				TempData.Add("Message", "Action is succeed.");
			}

		}

		protected Accounts CurrentAccount
		{
			get
			{
				Accounts account = Session["autoworld:user"] as Accounts;
				if (account != null)
				{
					return account;
				}
				throw new InvalidOperationException("Invalid user state");
			}
		}
	}
}