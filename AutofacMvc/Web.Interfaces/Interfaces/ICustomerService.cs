using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Interfaces.DbEntities;

namespace Web.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<UserEntity>> GetStringCheckDI();
    }
}
