
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IEmployeeTerritoryRepository : IBaseRepository<EmployeeTerritory>
    {
        List<EmployeeTerritory> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class EmployeeTerritoryRepository : BaseRepository<EmployeeTerritory>, IEmployeeTerritoryRepository
    {
        public EmployeeTerritoryRepository(SalesContext context) : base(context)
        {
        }
        public List<EmployeeTerritory> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
        out int totalPage)
        {
            currentPage = (currentPage <= 0) ? 1 : currentPage;
            pageSize = (pageSize <= 0) ? 20 : pageSize;

            var query = Dbset.AsQueryable();
            totalPage = query.Count();
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.OrderByField(sortColumn.Trim(), sortDirection);
            }
            else
                query = query.OrderByDescending(c => c.EmployeeId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
