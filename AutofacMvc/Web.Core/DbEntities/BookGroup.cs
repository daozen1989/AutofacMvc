namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        [StringLength(150)]
        public string GroupName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(50)]
        public string InsertUser { get; set; }

        public DateTime? InsertDate { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
