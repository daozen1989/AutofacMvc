namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        public int? DomainId { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public int? GroupId { get; set; }

        [StringLength(500)]
        public string CoverImage { get; set; }

        [Column(TypeName = "ntext")]
        public string AudioFile { get; set; }

        [Column(TypeName = "ntext")]
        public string VideoFile { get; set; }

        public DateTime? PublishDate { get; set; }

        [StringLength(500)]
        public string Infomation { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string InsertUser { get; set; }

        public DateTime? InsertDate { get; set; }

        [StringLength(50)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
