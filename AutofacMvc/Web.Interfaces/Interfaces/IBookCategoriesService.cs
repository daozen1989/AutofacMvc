using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Interfaces.Entities;

namespace Web.Interfaces
{
    public interface IBookCategoriesService
    {
        Task<IEnumerable<BookCategoryEntity>> GetAllBookCategory();
    }
}