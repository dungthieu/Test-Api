using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Test.core;
using Test.DataAccess.Models;
using Test.DataAccess.Repository;
using Test.Models.Model.EmployeeModels;
using Test.Services.AutoMap;

namespace Test.Services.Service
{
    public interface IEmployeeService : IEntityService<Employee>
    {

        bool UpdateEmployee(EmployeeEditModels model, out string message);
        EmployeeEditModels CreateEmployee(EmployeeEditModels model, out string message);
        bool Delete(int EmployeeId, out string message);
        List<EmployeeListModels> GetListEmployee();


    }
    public class EmployeeService : EntityService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeService(IUnitOfWork unitofwork, IEmployeeRepository EmployeeRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateEmployee(EmployeeEditModels model, out string message)
        {
            var EmployeeEntity = _EmployeeRepository.GetById(model.EmployeeId);
            if (EmployeeEntity != null)
            {
                var gr = _EmployeeRepository.getEmployee(model.EmployeeId, model.FirstName, model.LastName);
                if (gr != null)
                {
                    message = Constants.EmployeeIsExist;
                    return false;
                }
                EmployeeEntity = model.MapToEditEntity(EmployeeEntity);
                _EmployeeRepository.Update(EmployeeEntity);
                UnitOfwork.SaveChanges();
                message = Constants.UpdateSuccess;
                return true;
            }
            message = Constants.UpdateFail;
            return false;
        }
        public EmployeeEditModels CreateEmployee(EmployeeEditModels model, out string message)
        {
            var ship = _EmployeeRepository.getEmployee(model.EmployeeId, model.FirstName, model.LastName);
            if (ship != null)
            {
                message = Constants.EmployeeIsExist;
                return null;
            }
            var CreateEmployee = _EmployeeRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateEmployee == null)
            {
                message = Constants.CreateFail;
                return null;

            }
            message = Constants.CreateSuccess;
            return CreateEmployee.MapToEditModel();
        }

        public bool Delete(int EmployeeId, out string message)
        {
            try
            {
                var entity = _EmployeeRepository.GetById(EmployeeId);
                if (entity != null)
                {
                    _EmployeeRepository.Delete(EmployeeId);
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
        public List<EmployeeListModels> GetListEmployee()
        {
            return _EmployeeRepository.GetAll().ToList().MapToModels();

        }
    }
}