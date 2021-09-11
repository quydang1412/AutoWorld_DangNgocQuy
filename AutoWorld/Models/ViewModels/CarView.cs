using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoWorld.Models.ViewModels
{
    public class CarView
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

        public long Seat { get; set; }

        public string Model { get; set; }

        public string Fuel{ get; set; }

        public string Origin { get; set; }

        public string Other { get; set; }

        public string ImageDetail { get; set; }

        public string ImageDetail1 { get; set; }

        public string ImageDetail2 { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [StringLength(1024)]
        public string Content { get; set; }

        public long? LocationId { get; set; }

    }
}