using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DbEntities;
using Web.Core.Extentions;

namespace Web.Core.Repositories
{
    public class BaseRepository
    {
        protected readonly WebDbContext webDbContext;

        public BaseRepository()
        {
        }

        public BaseRepository(WebDbContext context)
        {
            webDbContext = context;
        }

        protected Task<IEnumerable<TResponse>> Search<TSource, TResponse>(Func<WebDbContext, IEnumerable<TSource>> search)
        {
            using (var context = webDbContext ?? new WebDbContext())
            {
                return Task.FromResult(search(context).ToList().Map<TSource, TResponse>());
            }
        }

        protected Task<TResponse> Search<TSource, TResponse>(Func<WebDbContext, TSource> search)
        {
            using (var context = webDbContext ?? new WebDbContext())
            {
                return Task.FromResult(search(context).ToDataObject<TResponse>());
            }
        }

        protected Task<TResponse> Search<TSource, TResponse, TDbContext>(TDbContext dbContext, Func<TDbContext, TSource> search)
            where TDbContext : DbContext, new()
        {
            using (var context = dbContext ?? new TDbContext())
            {
                return Task.FromResult(search(context).ToDataObject<TResponse>());
            }
        }

        protected TResponse Query<TResponse>(Func<WebDbContext, TResponse> search)
        {
            using (var context = webDbContext ?? new WebDbContext())
            {
                return search(context);
            }
        }

        protected async Task<TResponse> CommitAsync<TResponse>(Func<WebDbContext, TResponse> actionResult)
        {
            using (var context = webDbContext ?? new WebDbContext())
            {
                var result = actionResult(context);
                await context.SaveChangesAsync();
                return result;
            }
        }

        protected async Task<TResponse> CommitAsync<TResponse, TDbContext>(TDbContext dbContext, Func<TDbContext, TResponse> actionResult)
            where TDbContext : DbContext, new()
        {
            using (var context = dbContext ?? new TDbContext())
            {
                var result = actionResult(context);
                await context.SaveChangesAsync();
                return result;
            }
        }
    }
}
