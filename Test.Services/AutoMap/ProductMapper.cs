using System.Collections.Generic;
using System.Linq;
using Test.DataAccess.Models;
using Test.Models.Model.ProductModels;

namespace Test.Services.AutoMap
{
    public static class ProductMapper
    {
        public static Product MapToEntity(this ProductListModels model)
        {
            return new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                ReorderLevel = model.ReorderLevel,
                Discontinued = model.Discontinued
            };
        }
        public static Product MapToEditEntity(this ProductEditModels model)
        {
            return new Product
            {
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                SupplierId = model.SupplierId,
                CategoryId = model.CategoryId,
                QuantityPerUnit = model.QuantityPerUnit,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock,
                UnitsOnOrder = model.UnitsOnOrder,
                ReorderLevel = model.ReorderLevel,
                Discontinued = model.Discontinued
            };
        }
        public static Product MapToEditEntity(this ProductEditModels model, Product entity)
        {

            entity.ProductId = model.ProductId;
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.QuantityPerUnit = model.QuantityPerUnit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitsInStock = model.UnitsInStock;
            entity.UnitsOnOrder = model.UnitsOnOrder;
            entity.ReorderLevel = model.ReorderLevel;
            entity.Discontinued = model.Discontinued;
            return entity;
        }
        public static ProductListModels MapToModel(this Product entity)
        {
            return new ProductListModels
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                SupplierId = entity.SupplierId,
                CategoryId = entity.CategoryId,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder,
                ReorderLevel = entity.ReorderLevel,
                Discontinued = entity.Discontinued
            };
        }
        public static ProductEditModels MapToEditModel(this Product entity)
        {
            return new ProductEditModels
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                SupplierId = entity.SupplierId,
                CategoryId = entity.CategoryId,
                QuantityPerUnit = entity.QuantityPerUnit,
                UnitPrice = entity.UnitPrice,
                UnitsInStock = entity.UnitsInStock,
                UnitsOnOrder = entity.UnitsOnOrder,
                ReorderLevel = entity.ReorderLevel,
                Discontinued = entity.Discontinued
            };
        }
        public static List<ProductListModels> MapToModels(this List<Product> products)
        {
            return products.Select(x => x.MapToModel()).ToList();
        }
    }
}
