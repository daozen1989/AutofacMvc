namespace Web.Core.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookAudio")]
    public partial class BookAudio
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int AudioId { get; set; }
    }
}
