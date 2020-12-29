//using Microsoft.AspNetCore.Http;

//using Test.DataAccess.Models;
//using Test.DataAccess.Repository;
//using Test.Models.Model.CartModels;
//using Test.Services.AutoMap;
//using System;
//using System.Collections.Generic;

//using System.Text;
//using Test.core;

//namespace Test.Services.Service
//{
//    public interface ICartService : IEntityService<Cart>
//    {
//        List<CartListModels> GetAll();
//        bool Delete(int ProductId, out string message);
//        bool UpdateCart(CartEditModels cartmodel, out string message);
//    }
//    public class CartService : EntityService<Cart>, ICartService
//    {
//        private readonly ICartRepository _cartRepository;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public CartService(UnitOfWork unitofwork, ICartRepository cartRepository, IHttpContextAccessor httpContextAccessor)
//            : base(unitofwork, cartRepository)
//        {
//            _cartRepository = cartRepository;
//            _httpContextAccessor = httpContextAccessor;

//        }
//        public List<CartListModels> GetAll()
//        {
//            var GetList = _cartRepository.GetAllProduct();
//            if (GetList != null)
//            {
//                return GetList.MapToModels();
//            }
//            return null;
//        }
//        public bool Delete(int ProductId, out string message)
//        {
//            try
//            {
//                var entity = _cartRepository.GetById(ProductId);
//                if (entity != null)
//                {
//                    _cartRepository.Delete(ProductId);
//                    UnitOfwork.SaveChanges();
//                    message = Constants.DeleteSucces;
//                    return true;

//                }
//                message = Constants.DeleteFail;
//                return false;

//            }
//            catch
//            {
//                message = Constants.RecordsisUsedCanNotDeleted;
//                return false;
//            }
//        }
//       public bool UpdateCart(CartEditModels cartmodel, out string message)
//        {
//            message = Constants.UpdateSuccess;
//            var CartEntity = _cartRepository.GetById(cartmodel.ProductId);
//            return true;

//        }
//    }
//}
