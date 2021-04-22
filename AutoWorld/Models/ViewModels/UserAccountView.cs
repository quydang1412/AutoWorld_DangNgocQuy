using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
	public class UserAccountView
	{
		public long Id { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string DisplayName { get; set; }
		public string Roles { get; set; }
		public short Locked { get; set; }

		public UserAccountView() { }
		public UserAccountView(Users user)
		{
			Id = user.Id;
			LoginName = user.Accounts.LoginName;
			Password = string.Empty;
			Email = user.Accounts.Email;
			DisplayName = user.DisplayName;
			Roles = user.Roles;
			Locked = user.Accounts.Locked;
		}

		public void CopyToUser(ref Users user)
		{
			if (user.Accounts == null)
			{
				user.Accounts = new Accounts();
			}
			user.Accounts.LoginName = LoginName;
			user.Accounts.Password = Password;
			user.DisplayName = DisplayName;
			user.Accounts.Email = Email;
			user.Accounts.Locked = Locked;
			user.Roles = Roles;
		}


	}
}