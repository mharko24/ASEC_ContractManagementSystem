using ASEC_ContractManagementSystem_API.Common.Paging;
using System.Linq.Expressions;

namespace ASEC_ContractManagementSystem_API.Interfaces.Common
{
    public interface IPaginatedRepository<T> where T : class
    {
        Task<PaginatedResult<T>> GetPaginated(int page, int pageSize, Expression<Func<T, DateTime>> orderBy, Expression<Func<T, int>> orderThen, Expression<Func<T, bool>> condition);
    }
}
