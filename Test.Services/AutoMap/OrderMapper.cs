using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.OrderModels;

namespace Test.Services.AutoMap
{
    public static class OrderMapper
    {
        public static Order MapToEntity(this OrderListModels model)
        {
            return new Order
            {
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipVia = model.ShipVia,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipRegion = model.ShipRegion,
                ShipPostalCode = model.ShipPostalCode,
                ShipCountry = model.ShipCountry
            };
        }
        public static Order MapToEditEntity(this OrderEditModels model)
        {
            return new Order
            {
                OrderId = model.OrderId,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                OrderDate = model.OrderDate,
                RequiredDate = model.RequiredDate,
                ShippedDate = model.ShippedDate,
                ShipVia = model.ShipVia,
                Freight = model.Freight,
                ShipName = model.ShipName,
                ShipAddress = model.ShipAddress,
                ShipCity = model.ShipCity,
                ShipRegion = model.ShipRegion,
                ShipPostalCode = model.ShipPostalCode,
                ShipCountry = model.ShipCountry
            };
        }
        public static Order MapToEditEntity(this OrderEditModels model, Order entity)
        {

            entity.OrderId = model.OrderId;
            entity.CustomerId = model.CustomerId;
            entity.EmployeeId = model.EmployeeId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            return entity;
        }
        public static OrderListModels MapToModel(this Order entity)
        {
            return new OrderListModels
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                OrderDate = entity.OrderDate,
                RequiredDate = entity.RequiredDate,
                ShippedDate = entity.ShippedDate,
                ShipVia = entity.ShipVia,
                Freight = entity.Freight,
                ShipName = entity.ShipName,
                ShipAddress = entity.ShipAddress,
                ShipCity = entity.ShipCity,
                ShipRegion = entity.ShipRegion,
                ShipPostalCode = entity.ShipPostalCode,
                ShipCountry = entity.ShipCountry
            };
        }
        public static OrderEditModels MapToEditModel(this Order entity)
        {
            return new OrderEditModels
            {
                OrderId = entity.OrderId,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                OrderDate = entity.OrderDate,
                RequiredDate = entity.RequiredDate,
                ShippedDate = entity.ShippedDate,
                ShipVia = entity.ShipVia,
                Freight = entity.Freight,
                ShipName = entity.ShipName,
                ShipAddress = entity.ShipAddress,
                ShipCity = entity.ShipCity,
                ShipRegion = entity.ShipRegion,
                ShipPostalCode = entity.ShipPostalCode,
                ShipCountry = entity.ShipCountry
            };
        }
        public static List<OrderListModels> MapToModels(this List<Order> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
