namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        public int VideoId { get; set; }

        [Required]
        [StringLength(250)]
        public string VideoName { get; set; }

        [Column(TypeName = "ntext")]
        public string Link { get; set; }

        [StringLength(500)]
        public string VideoFile { get; set; }

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
