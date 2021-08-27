using AutoWorld.Models;
using AutoWorld.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.DAO
{
    public class ContactDAO
    {
        private AutoWorlDbContext db = new AutoWorlDbContext();

        public ContactDAO()
        {

        }

        public bool InsertContactInfor(Contact contact)
        {
            if (contact == null) return false;
            try
            {
                db.Contact.Add(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}