namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? TeamId { get; set; }

        public int RoleId { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual Role Role { get; set; }

        public virtual Team Team { get; set; }
    }
}
