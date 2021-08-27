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
        public string Phone { get; set; }
        public string Message { get; set; }
        
    }
}