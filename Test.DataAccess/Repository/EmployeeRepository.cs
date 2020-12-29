
using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Extensions;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        List<Employee> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection, out int totalPage);
        List<Employee> GetAll(int currentPage, int pageSize, string sortColumn, string sortDirection,
        out int totalPage);
        Employee getEmployee(int EmployeeId, string FirstName, string lastName);
    }
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SalesContext context) : base(context)
        {
        }
        public Employee getEmployee(int EmployeeId, string FirstName, string lastName)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.EmployeeId == EmployeeId && x.FirstName == FirstName && x.LastName == lastName);
            return query.FirstOrDefault();
        }
        public List<Employee> Search(int currentPage, int pageSize, string textSearch, string sortColumn, string sortDirection,
        out int totalPage)
        {
            currentPage = (currentPage <= 0) ? 1 : currentPage;
            pageSize = (pageSize <= 0) ? 20 : pageSize;

            var query = Dbset.AsQueryable();
            query = query.Where(x => x.FirstName == textSearch);
            totalPage = query.Count();
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = query.OrderByField(sortColumn.Trim(), sortDirection);
            }
            else
                query = query.OrderByDescending(c => c.EmployeeId);

            return query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Employee> GetAll(int currentPage, int pageSize, string sortColumn, string sortDirection,
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
        public Employee GetInfor(int id)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.EmployeeId == id);
            return query.FirstOrDefault();
        }
    }

}
