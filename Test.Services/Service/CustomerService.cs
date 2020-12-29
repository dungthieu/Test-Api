using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Test.core;
using Test.DataAccess.Models;
using Test.DataAccess.Repository;
using Test.Models.Model.CustomerModels;
using Test.Services.AutoMap;

namespace Test.Services.Service
{
    public interface ICustomerService : IEntityService<Customer>
    {

        bool UpdateCustomer(CustomerListModels model, out string message);
        CustomerListModels CreateCustomer(CustomerListModels model, out string message);
        bool Delete(int CustomerId, out string message);
        List<CustomerListModels> GetListCustomer();


    }
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerService(IUnitOfWork unitofwork, ICustomerRepository CustomerRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateCustomer(CustomerListModels model, out string message)
        {
            var CustomerEntity = _CustomerRepository.GetById(model.CustomerId);
            if (CustomerEntity != null)
            {
                var gr = _CustomerRepository.getCustomer(model.CustomerId, model.ContactName, model.CompanyName);
                if (gr != null)
                {
                    message = Constants.CustomerIsExist;
                    return false;
                }
                CustomerEntity = model.MapToEntity(CustomerEntity);
                _CustomerRepository.Update(CustomerEntity);
                UnitOfwork.SaveChanges();
                message = Constants.UpdateSuccess;
                return true;
            }
            message = Constants.UpdateFail;
            return false;
        }
        public CustomerListModels CreateCustomer(CustomerListModels model, out string message)
        {
            var ship = _CustomerRepository.getCustomer(model.CustomerId, model.ContactName, model.CompanyName);
            if (ship != null)
            {
                message = Constants.CustomerIsExist;
                return null;
            }
            var CreateCustomer = _CustomerRepository.Insert(model.MapToEntity());
            UnitOfwork.SaveChanges();
            if (CreateCustomer == null)
            {
                message = Constants.CreateFail;
                return null;

            }
            message = Constants.CreateSuccess;
            return CreateCustomer.MapToModel();
        }

        public bool Delete(int CustomerId, out string message)
        {
            try
            {
                var entity = _CustomerRepository.GetById(CustomerId);
                if (entity != null)
                {
                    _CustomerRepository.Delete(CustomerId);
                    UnitOfwork.SaveChanges();
                    message = Constants.DeleteSuccess;
                    return true;
                }

                message = Constants.DeleteFail;
                return false;
            }
            catch
            {
                message = Constants.RecordsisUsedCanNotDeleted;
                return false;
            }
        }
        public List<CustomerListModels> GetListCustomer()
        {
            return _CustomerRepository.GetAll().ToList().MapToModels();

        }
    }
}