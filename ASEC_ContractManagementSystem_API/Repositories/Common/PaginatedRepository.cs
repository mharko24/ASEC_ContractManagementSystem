using ASEC_ContractManagementSystem_API.Common.Paging;
using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASEC_ContractManagementSystem_API.Repositories.Common
{
    public class PaginatedRepository<T> : IPaginatedRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _table;
        public PaginatedRepository(
            ApplicationDbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }
        public async Task<PaginatedResult<T>> GetPaginated(int page, 
            int pageSize, Expression<Func<T, DateTime>> orderBy,
            Expression<Func<T, int>> orderThen, 
            Expression<Func<T, bool>> condition)
        {
            var count = await _table.Where(condition).CountAsync();
            var records = await _table
                .Where(condition)
                .OrderByDescending(orderBy)
                .ThenByDescending(orderThen)
                .Skip((page - 1) * page)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedResult<T>
            {
                data = records,
                pageCurrent = page,
                numSize = (int)Math.Ceiling(count / (double)pageSize)
            };
        }
    }
}
