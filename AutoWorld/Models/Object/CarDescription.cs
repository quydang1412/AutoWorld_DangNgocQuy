using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.Object
{
    public class CarDescription
    {
        public long seats { get; set; }

        public string model { get; set; }

        public string fuel { get; set; }

        public string origin { get; set; }

        public string other { get; set; }

        public string img { get; set; }

        public string img1 { get; set; }

        public string img2 { get; set; }

         public CarDescription(long Seat,string Model,string Fuel, string Origin, string Other, string ImageDetail, string ImageDetail1, string ImageDetail2)
        {
            this.seats = Seat;
            this.model = Model;
            this.fuel = Fuel;
            this.origin = Origin;
            this.other = Other;
            this.img = ImageDetail;
            this.img1 = ImageDetail1;
            this.img2 = ImageDetail2;
        }

        

    }
}