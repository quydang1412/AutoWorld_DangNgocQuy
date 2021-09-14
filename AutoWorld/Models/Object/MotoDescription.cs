using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.Object
{
    public class MotoDescription
    {
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

        public MotoDescription(string Weight, string PetrolTankCapacity, string EngineType, string MaximumPower, string MaximumMoment, string CylinderCapacity, string ImageDetail, string ImageDetail1, string ImageDetail2, string ImageDetail3, string ImageDetail4, string ImageDetail5)
        {
            this.weight = Weight;
            this.petrolTankCapacity = PetrolTankCapacity;
            this.engineType = EngineType;
            this.maximumPower = MaximumPower;
            this.maximumMoment = MaximumMoment;
            this.cylinderCapacity = CylinderCapacity;
            this.img = ImageDetail;
            this.img1 = ImageDetail1;
            this.img2 = ImageDetail2;
            this.img3 = ImageDetail3;
            this.img4 = ImageDetail4;
            this.img5 = ImageDetail5;
        }

    }
}