
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product getProduct(int productId, string ProductName);
        List<Product> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
    }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SalesContext context) : base(context)
        {
        }
        public Product getProduct(int productId, string ProductName)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.ProductId == productId && x.ProductName == ProductName);
            return query.FirstOrDefault();
        }

        public List<Product> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
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
                query = query.OrderByDescending(c => c.ProductId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }

}
