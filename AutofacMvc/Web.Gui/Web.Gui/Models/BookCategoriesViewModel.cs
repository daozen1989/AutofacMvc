using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Interfaces.Entities;

namespace Web.Gui.Models
{
    public class BookCategoriesViewModel
    {
        public List<BookCategoryEntity> BookCategoryList { get; set; }
    }
}