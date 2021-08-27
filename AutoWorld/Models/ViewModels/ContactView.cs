using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
    public class ContactView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        //public ContactView(string name, string email, string phone, string message)
        //{
        //    Name = name;
        //    Email = email;
        //    Phone = phone;
        //    Message = message;
        //}
        
    }
}