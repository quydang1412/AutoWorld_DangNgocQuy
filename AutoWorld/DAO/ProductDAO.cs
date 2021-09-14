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
            p.Description = JsonDescription(car.Seat, car.Model, car.Fuel, car.Origin, car.Other, car.ImageDetail1, car.ImageDetail2, car.ImageDetail3, car.ImageDetail4, car.ImageDetail5);
            return p;

        }

        public string JsonDescription(long Seat, string Model, string Fuel, string Origin, string other, string img1, string img2, string img3, string img4, string img5)
        {
            CarDescription car = new CarDescription(Seat, Model, Fuel, Origin, other, img1, img2, img3, img4, img5);
            string m = new JavaScriptSerializer().Serialize(car);
            return m;
        }

        public Products MotoProduct(MotoView moto)
        {
            Products p = new Products();
            p.Id = moto.Id;
            p.Name = moto.Name;
            p.Image = moto.Image;
            p.CategoryId = moto.CategoryId;
            p.Price = moto.Price;
            p.Content = moto.Content;
            p.LocationId = moto.LocationId;
            p.Description = JsonDescriptionForMoto(moto.Weight, moto.PetrolTankCapacity, moto.EngineType, moto.MaximumPower, moto.MaximumMoment,moto.CylinderCapacity,moto.ImageDetail, moto.ImageDetail1, moto.ImageDetail2, moto.ImageDetail3, moto.ImageDetail4, moto.ImageDetail5);
            return p;

        }

        public string JsonDescriptionForMoto(string Weight, string PetrolTankCapacity, string EngineType, string MaximumPower, string MaximumMoment, string CylinderCapacity,string img, string img1, string img2, string img3, string img4, string img5)
        {
            MotoDescription moto = new MotoDescription(Weight, PetrolTankCapacity, EngineType, MaximumPower, MaximumMoment, CylinderCapacity, img, img1, img2, img3, img4, img5);
            string m = new JavaScriptSerializer().Serialize(moto);
            return m;
        }

    }
}
