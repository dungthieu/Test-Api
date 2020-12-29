using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.ShipperModels;

namespace Test.Services.AutoMap
{
    public static class ShipperMapper
    {
        public static Shipper MapToEntity(this ShipperListModels model)
        {
            return new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
        }
        public static Shipper MapToEditEntity(this ShipperEditModels model)
        {
            return new Shipper
            {
                ShipperId = model.ShipperId,
                CompanyName = model.CompanyName,
                Phone = model.Phone
            };
        }
        public static Shipper MapToEditEntity(this ShipperEditModels model, Shipper entity)
        {

            entity.ShipperId = model.ShipperId;
            entity.CompanyName = model.CompanyName;
            entity.Phone = model.Phone;
            return entity;

        }
        public static ShipperListModels MapToModel(this Shipper entity)
        {
            return new ShipperListModels
            {
                ShipperId = entity.ShipperId,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
        public static ShipperEditModels MapToEditModel(this Shipper entity)
        {
            return new ShipperEditModels
            {
                ShipperId = entity.ShipperId,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
        public static List<ShipperListModels> MapToModels(this List<Shipper> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }

}