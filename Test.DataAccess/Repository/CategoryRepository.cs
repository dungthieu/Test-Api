
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        List<Category> GetListCategory();
        Category getCategory(int categoryId, string categoryName);
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SalesContext context) : base(context)
        {
        }
        public Category getCategory(int categoryId, string categoryName)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.CategoryId == categoryId && x.CategoryName == categoryName);
            return query.FirstOrDefault();

        }
        public List<Category> GetListCategory()
        {


            var query = Dbset.AsQueryable();
            return query.ToList();
        }
    }

}
