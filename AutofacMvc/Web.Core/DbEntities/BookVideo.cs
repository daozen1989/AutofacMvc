namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookVideo")]
    public partial class BookVideo
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int VideoId { get; set; }
    }
}
