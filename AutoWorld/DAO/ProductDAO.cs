using AutoWorld.Models;
using AutoWorld.Models.Object;
using AutoWorld.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AutoWorld.DAO
{
    public class ProductDAO
    {

        //public List<Products> ListProduct()

        public Products CarProduct(CarView car)
        {
            Products p = new Products();
            p.Id = car.Id;
            p.Name = car.Name;
            p.Image = car.Image;
            p.CategoryId = car.CategoryId;
            p.Price = car.Price;
            p.Content = car.Content;
            p.LocationId = car.LocationId;
            p.Description = JsonDescription(car.Seat, car.Model, car.Fuel, car.Origin, car.Other, car.ImageDetail, car.ImageDetail1, car.ImageDetail2);
            return p;

        }

        public string JsonDescription(long Seat, string Model, string Fuel, string Origin, string other, string img, string img1, string img2)
        {
            CarDescription car = new CarDescription(Seat, Model, Fuel, Origin, other, img, img1, img2);
            string m = new JavaScriptSerializer().Serialize(car);
            return m;
        }
    }
}
