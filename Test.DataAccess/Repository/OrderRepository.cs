
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Order getOrder(int OrderId, string customerId, int? employeeId);
        List<Order> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(SalesContext context) : base(context)
        {
        }
        public Order getOrder(int OrderId, string customerId, int? employeeId)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.CustomerId == customerId && x.OrderId == OrderId && x.EmployeeId == employeeId);
            return query.FirstOrDefault();
        }
        public List<Order> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage)
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
                query = query.OrderByDescending(c => c.OrderId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
