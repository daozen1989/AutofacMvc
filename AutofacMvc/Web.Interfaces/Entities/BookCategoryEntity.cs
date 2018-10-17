using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Interfaces.Utilities;

namespace Web.Interfaces.Entities
{
    public class BookCategoryEntity : AbstractEntity
    {
        public BookCategoryEntity()
        {
        }
        public BookCategoryEntity(object srcObj, char separator)
            : this()
        {
            ModelMapper.MappingCamelUpper(srcObj, this, separator);
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? DomainId { get; set; }

        public string Description { get; set; }
    }
}
