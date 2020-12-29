using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.OrderDetailModels;

namespace Test.Services.AutoMap
{
    public static class OrderDetailMapper
    {
        public static OrderDetail MapToEntity(this OrderDetailListModels model)
        {
            return new OrderDetail
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount
            };

        }
        public static OrderDetail MapToEditEntity(this OrderDetailEditModels model)
        {
            return new OrderDetail
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount
            };

        }
        public static OrderDetail MapToEditEntity(this OrderDetailEditModels model, OrderDetail entity)
        {

            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
            return entity;

        }
        public static OrderDetailListModels MapToModel(this OrderDetail Entity)
        {
            return new OrderDetailListModels
            {
                OrderId = Entity.OrderId,
                ProductId = Entity.ProductId,
                UnitPrice = Entity.UnitPrice,
                Quantity = Entity.Quantity,
                Discount = Entity.Discount
            };

        }
        public static OrderDetailEditModels MapToEditModel(this OrderDetail Entity)
        {
            return new OrderDetailEditModels
            {
                OrderId = Entity.OrderId,
                ProductId = Entity.ProductId,
                UnitPrice = Entity.UnitPrice,
                Quantity = Entity.Quantity,
                Discount = Entity.Discount
            };

        }
        public static List<OrderDetailListModels> MapToModels(this List<OrderDetail> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
