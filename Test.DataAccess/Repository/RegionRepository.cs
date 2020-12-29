
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        List<Region> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(SalesContext context) : base(context)
        {
        }
        public List<Region> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.RegionId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
