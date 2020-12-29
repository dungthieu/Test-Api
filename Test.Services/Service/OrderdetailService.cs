using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Test.core;
using Test.DataAccess.Models;
using Test.DataAccess.Repository;
using Test.Models.Model.OrderDetailModels;
using Test.Services.AutoMap;

namespace Test.Services.Service
{
    public interface IOrderDetailService : IEntityService<OrderDetail>
    {

        bool UpdateOrderDetail(OrderDetailEditModels model, out string message);
        OrderDetailEditModels CreateOrderDetail(OrderDetailEditModels model, out string message);
        bool Delete(int OrderDetailId, out string message);
        List<OrderDetailListModels> GetListOrderDetail();


    }
    public class OrderDetailService : EntityService<OrderDetail>, IOrderDetailService
    {
        private readonly IOrderDetailRepository _OrderDetailRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderDetailService(IUnitOfWork unitofwork, IOrderDetailRepository OrderDetailRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public bool UpdateOrderDetail(OrderDetailEditModels model, out string message)
        {
            var OrderDetailEntity = _OrderDetailRepository.GetById(model.OrderId);
            if (OrderDetailEntity != null)
            {
                var gr = _OrderDetailRepository.getOrderDetail(model.OrderId, model.ProductId);
                if (gr != null)
                {
                    message = Constants.OrderDetailIsExist;
                    return false;
                }
                OrderDetailEntity = model.MapToEditEntity(OrderDetailEntity);
                _OrderDetailRepository.Update(OrderDetailEntity);
                UnitOfwork.SaveChanges();
                message = Constants.UpdateSuccess;
                return true;
            }
            message = Constants.UpdateFail;
            return false;
        }
        public OrderDetailEditModels CreateOrderDetail(OrderDetailEditModels model, out string message)
        {
            var ship = _OrderDetailRepository.getOrderDetail(model.OrderId, model.ProductId);
            if (ship != null)
            {
                message = Constants.OrderDetailIsExist;
                return null;
            }
            var CreateOrderDetail = _OrderDetailRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateOrderDetail == null)
            {
                message = Constants.CreateFail;
                return null;

            }
            message = Constants.CreateSuccess;
            return CreateOrderDetail.MapToEditModel();
        }

        public bool Delete(int OrderDetailId, out string message)
        {
            try
            {
                var entity = _OrderDetailRepository.GetById(OrderDetailId);
                if (entity != null)
                {
                    _OrderDetailRepository.Delete(OrderDetailId);
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
        public List<OrderDetailListModels> GetListOrderDetail()
        {
            return _OrderDetailRepository.GetAll().ToList().MapToModels();

        }
    }
}