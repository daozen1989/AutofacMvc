using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DbEntities;
using Web.Interfaces;
using Web.Interfaces.DbEntities;
using Web.Interfaces.Entities;

namespace Web.Core.Repositories
{
    public class BookCategoriesService : BaseRepository, IBookCategoriesService
    {
        public Task<IEnumerable<BookCategoryEntity>> GetAllBookCategory()
         => Search<BookCategory, BookCategoryEntity>(context => context.BookCategories.Where(b => b.CategoryName != null).AsNoTracking());
    }
}
