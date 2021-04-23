using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
    public class DetailsView1
    {

        public DetailsView1(Products product)
        {
            if (product == null)
            {
                return;
            }



            string json = product.Description;
            //dynamic ar = JObject.Parse(json);
            array1 dt = JsonConvert.DeserializeObject<array1>(json);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //dynamic ar = js.DeserializeObject(json);

            name = product.Name;
            price = product.Price;
            weight = dt.weight;
            petrolTankCapacity = dt.petrolTankCapacity;
            engineType = dt.engineType;
            maximumPower = dt.maximumPower;
            maximumMoment = dt.maximumMoment;
            cylinderCapacity = dt.cylinderCapacity;
            img = dt.img;
            img1 = dt.img1;
            img2 = dt.img2;
            img3 = dt.img3;
            img4 = dt.img4;
            img5 = dt.img5;



        }

        public string name { get; set; }

        public double price { get; set; }

        public string weight { get; set; }
        public string petrolTankCapacity { get; set; }
        public string engineType { get; set; }
        public string maximumPower { get; set; }
        public string maximumMoment { get; set; }
        public string cylinderCapacity { get; set; }
        public string img { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public string img5 { get; set; }
    }
}