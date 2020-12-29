
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IShipperRepository : IBaseRepository<Shipper>
    {
        List<Shipper> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
        Shipper getshipper(int id, string companyName, string phone);
    }
    public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(SalesContext context) : base(context)
        {
        }
        public Shipper getshipper(int id, string companyName, string phone)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.ShipperId == id && x.CompanyName == companyName && x.Phone == phone);
            return query.FirstOrDefault();

        }
        public List<Shipper> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.ShipperId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
