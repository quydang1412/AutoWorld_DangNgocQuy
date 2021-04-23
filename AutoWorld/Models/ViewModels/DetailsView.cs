using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AutoWorld.Models.ViewModels
{
    public class DetailsView
    {
        //public DetailsView()
        //{

        //}


     /*   public DetailsView(Products product)
        {
            if (product == null)
            {
                return;
            }

            
            string json = product.Description;
            dynamic ar = JObject.Parse(json);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //dynamic ar = js.DeserializeObject(json);

            seats = ar["seats"];
            model = ar["model"];
            fuel = ar["fuel"];
            origin = ar["origin"];
            other = ar["other"];
            img = ar["img"];
            img1 = ar["img1"];
            img2 = ar["img2"];
            img3 = ar["img3"];
            img4 = ar["img4"];
            img5 = ar["img5"];

            //seats = ar[0].seats;
            //model = ar[0].model;
            //fuel = ar[0].fuel;
            //origin = ar[0].origin;
            //other = ar[0].other;
            //img = ar[0].img;
            //img1 = ar[0].img1;
            //img2 = ar[0].img2;
            //img3 = ar[0].img3;
            //img4 = ar[0].img4;
            //img5 = ar[0].img5;

        }*/

        public DetailsView(Products product)
        {
            if (product == null)
            {
                return;
            }



            string json = product.Description;
            //dynamic ar = JObject.Parse(json);
            array dt = JsonConvert.DeserializeObject<array>(json);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //dynamic ar = js.DeserializeObject(json);

            name = product.Name;
            price = product.Price;
            seats = dt.seats;
            model = dt.model;
            fuel = dt.fuel;
            origin = dt.origin;
            other = dt.other;
            img = dt.img;
            img1 = dt.img1;
            img2 = dt.img2;
            img3 = dt.img3;
            img4 = dt.img4;
            img5 = dt.img5;

            

        }

        public string name { get; set; }

        public double price { get; set; }

        public string seats { get; set; }
        public string model { get; set; }
        public string fuel { get; set; }
        public string origin { get; set; }
        public string other { get; set; }
        public string img { get; set; }
        public string img1 { get; set; }
        public string img2 { get; set; }
        public string img3 { get; set; }
        public string img4 { get; set; }
        public string img5 { get; set; }






    }
}