namespace AutoWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public long Id { get; set; }

        public string DisplayName { get; set; }

        [Required]
        public string Roles { get; set; }

        public long AccountId { get; set; }

        public virtual Accounts Accounts { get; set; }
    }
}
