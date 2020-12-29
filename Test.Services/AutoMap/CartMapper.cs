using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.CartModels;



namespace Test.Services.AutoMap
{
    public static class CartMapper
    {
        #region Mapping CartMapper
        public static CartListModels MapToModel(this Cart entity)
        {
            return new CartListModels
            {
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                ProductName = entity.ProductName,
                CookieName = entity.CookieName,
                CustomerId = entity.CustomerId
            };
        }
        public static CartEditModels MapToEditModel(this Cart entity)
        {
            return new CartEditModels
            {
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                ProductName = entity.ProductName,
                CookieName = entity.CookieName,
                CustomerId = entity.CustomerId
            };
        }
        public static CartEditModels MapToModel(this Cart entity, CartEditModels model)
        {

            model.ProductId = entity.ProductId;
            model.Quantity = entity.Quantity;
            model.UnitPrice = entity.UnitPrice;
            model.ProductName = entity.ProductName;
            model.CookieName = entity.CookieName;
            model.CustomerId = entity.CustomerId;
            return model;

        }
        public static Cart MapToEditEntity(this CartEditModels Model)
        {
            return new Cart
            {
                ProductId = Model.ProductId,
                Quantity = Model.Quantity,
                UnitPrice = Model.UnitPrice,
                ProductName = Model.ProductName,
                CookieName = Model.CookieName,
                CustomerId = Model.CustomerId
            };
        }
        public static Cart MapToEntity(this CartListModels Model)
        {
            return new Cart
            {
                ProductId = Model.ProductId,
                Quantity = Model.Quantity,
                UnitPrice = Model.UnitPrice,
                ProductName = Model.ProductName,
                CookieName = Model.CookieName,
                CustomerId = Model.CustomerId
            };
        }
        public static Cart MapToEntity(this CartEditModels Model, Cart entity)
        {

            entity.ProductId = Model.ProductId;
            entity.Quantity = Model.Quantity;
            entity.UnitPrice = Model.UnitPrice;
            entity.ProductName = Model.ProductName;
            entity.CookieName = Model.CookieName;
            entity.CustomerId = Model.CustomerId;
            return entity;
        }
        /// <summary>
        /// update gio hang 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public static List<Cart> MapToEntities(this List<CartListModels> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }

        public static List<CartListModels> MapToModels(this List<Cart> Entities)
        {
            return Entities.Select(x => x.MapToModel()).ToList();
        }


    }
    #endregion
}

