using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
    public class SearchProductView
    {
        public SearchProductView()
        {

        }
        public long CategoryID { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public long? LocationId { get; set; }
    }
}