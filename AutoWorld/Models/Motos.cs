namespace AutoWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Motos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public double Price { get; set; }

        [StringLength(255)]
        public string Weight { get; set; }

        [StringLength(255)]
        public string PetrolTankCapacity { get; set; }

        [StringLength(255)]
        public string EngineType { get; set; }

        [StringLength(255)]
        public string MaximumPower { get; set; }

        [StringLength(255)]
        public string MaximumMoment { get; set; }

        [StringLength(255)]
        public string CylinderCapacity { get; set; }
    }
}
