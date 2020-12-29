using System.Linq;
using Test.DataAccess.Models;

namespace Test.DataAccess.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer SignIn(string User, string Pass);
        Customer GetById(string customerId);
        Customer getCustomer(string customerId, string ContactName, string CompanyName);


    }
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesContext context) : base(context)
        {
        }
        public Customer getCustomer(string customerId, string ContactName, string CompanyName)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.CustomerId == customerId && x.ContactName == ContactName && x.CompanyName == CompanyName);
            return query.FirstOrDefault();
        }


        public Customer GetById(string customerId)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.CustomerId == customerId);
            return query.FirstOrDefault();
        }
        public Customer SignIn(string User, string Pass)
        {
            var query = Dbset.AsQueryable();
            query = query.Where(x => x.User == User && x.Password == Pass);
            return query.FirstOrDefault();
        }
    }

}
