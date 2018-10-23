using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Core.DbEntities;
using Web.Interfaces.DbEntities;
using Web.Interfaces;

namespace Web.Core.Repositories
{
    public class CustomerService : BaseRepository, ICustomerService
    {
        //public Task<IEnumerable<UserEntity>> GetStringCheckDI()
        //{
        //    //var result = Query(context => context.Teams.FirstOrDefault());
        //    //var result = Search<User, UserEntity>(context => context.Users.AsNoTracking());
        //    //return result;
        //}
        public Task<IEnumerable<UserEntity>> GetStringCheckDI()
        {
            throw new NotImplementedException();
        }
    }
}
