using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
    public class MotoView
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        public long CategoryId { get; set; }

        public double Price { get; set; }

        public string Weight { get; set; }

        public string PetrolTankCapacity { get; set; }

        public string EngineType { get; set; }

        public string MaximumPower { get; set; }

        public string MaximumMoment { get; set; }

        public string CylinderCapacity { get; set; }

        public string ImageDetail { get; set; }

        public string ImageDetail1 { get; set; }

        public string ImageDetail2 { get; set; }

        public string ImageDetail3 { get; set; }

        public string ImageDetail4 { get; set; }

        public string ImageDetail5 { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [StringLength(1024)]
        public string Content { get; set; }

        public long? LocationId { get; set; }
    }
}