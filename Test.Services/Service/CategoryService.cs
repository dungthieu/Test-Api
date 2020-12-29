using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Test.core;
using Test.DataAccess.Models;
using Test.DataAccess.Repository;
using Test.Models.Model.CategoryModels;
using Test.Services.AutoMap;

namespace Test.Services.Service
{
    public interface ICategoryService : IEntityService<Category>
    {

        bool UpdateCategory(CategoryEditModels model, out string message);
        CategoryEditModels CreateCategory(CategoryEditModels model, out string message);
        bool Delete(int CategoryId, out string message);
        CategoryListModels getId(int categoryId);
        List<CategoryListModels> GetListCategory();


    }
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryService(IUnitOfWork unitofwork, ICategoryRepository CategoryRepository, IHttpContextAccessor httpContextAccessor)
            : base(unitofwork, CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public CategoryListModels getId(int categoryId)
        {
            var value = _CategoryRepository.GetById(categoryId);
            return value.MapToModel();
        }
        public bool UpdateCategory(CategoryEditModels model, out string message)
        {
            var CategoryEntity = _CategoryRepository.GetById(model.CategoryId);
            if (CategoryEntity != null)
            {
                var gr = _CategoryRepository.getCategory(model.CategoryId, model.CategoryName);
                if (gr != null)
                {
                    message = Constants.CategoryIsExist;
                    return false;
                }
                CategoryEntity = model.MapToEditEntity(CategoryEntity);
                _CategoryRepository.Update(CategoryEntity);
                UnitOfwork.SaveChanges();
                message = Constants.UpdateSuccess;
                return true;
            }
            message = Constants.UpdateFail;
            return false;
        }
        public CategoryEditModels CreateCategory(CategoryEditModels model, out string message)
        {
            var ship = _CategoryRepository.getCategory(model.CategoryId, model.CategoryName);
            if (ship != null)
            {
                message = Constants.CategoryIsExist;
                return null;
            }
            var CreateCategory = _CategoryRepository.Insert(model.MapToEditEntity());
            UnitOfwork.SaveChanges();
            if (CreateCategory == null)
            {
                message = Constants.CreateFail;
                return null;

            }
            message = Constants.CreateSuccess;
            return CreateCategory.MapToEditModel();
        }

        public bool Delete(int CategoryId, out string message)
        {
            try
            {
                var entity = _CategoryRepository.GetById(CategoryId);
                if (entity != null)
                {
                    _CategoryRepository.Delete(CategoryId);
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
        public List<CategoryListModels> GetListCategory()
        {
            return _CategoryRepository.GetAll().ToList().MapToModels();

        }
    }
}