using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.CustomerModels;

namespace Test.Services.AutoMap
{
    public static class CustomerMapper
    {
        public static Customer MapToEntity(this CustomerListModels model)
        {
            return new Customer
            {
                CustomerId = model.CustomerId,
                CompanyName = model.CompanyName,
                ContactName = model.ContactTitle,
                ContactTitle = model.ContactTitle,
                Address = model.Address,
                City = model.City,
                Region = model.Region,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Phone = model.Phone,
                Fax = model.Fax,
                User = model.User,
                Password = model.Password,

            };

        }
        public static CustomerListModels MapToModel(this Customer entity)
        {
            return new CustomerListModels
            {
                CustomerId = entity.CustomerId,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactTitle,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                Country = entity.Country,
                PostalCode = entity.PostalCode,
                Phone = entity.Phone,
                Fax = entity.Fax,
                User = entity.User,
                Password = entity.Password,
            };

        }
        public static CustomerListModels MapToModel(this Customer entity, CustomerListModels model)
        {
            model.CustomerId = entity.CustomerId;
            model.CompanyName = entity.CompanyName;
            model.ContactName = entity.ContactTitle;
            model.ContactTitle = entity.ContactTitle;
            model.Address = entity.Address;
            model.City = entity.City;
            model.Region = entity.Region;
            model.Country = entity.Country;
            model.PostalCode = entity.PostalCode;
            model.Phone = entity.Phone;
            model.Fax = entity.Fax;
            model.User = entity.User;
            model.Password = entity.Password;
            return model;
        }
        public static Customer MapToEntity(this CustomerListModels model, Customer entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactTitle;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.Country = model.Country;
            entity.PostalCode = model.PostalCode;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            entity.User = model.User;
            entity.Password = model.Password;
            return entity;
        }

        public static List<CustomerListModels> MapToModels(this List<Customer> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
