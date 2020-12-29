using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.Models;
using Test.Models.Model.CategoryModels;
using Test.Services.Service;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("Category")]

    public class CategoryController : ControllerBase
    {
        private ICategoryService _allType;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService allType)
        {
            _allType = allType;
            _logger = logger;
        }
        [HttpGet]
        [Route("getById")]
        public ApiResponse<CategoryListModels> getById(int categoryId)
        {
            var model = _allType.getId(categoryId);
            return new ApiResponse<CategoryListModels>(model);
        }
    }
}
