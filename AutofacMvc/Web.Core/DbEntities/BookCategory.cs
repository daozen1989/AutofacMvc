namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookCategory")]
    public partial class BookCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; }

        public int? DomainId { get; set; }

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
