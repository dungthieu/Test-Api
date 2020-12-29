using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.CategoryModels
{
    public class CategorySearchModel : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<CategoryListModels> CategoryModels { get; set; }
    }
}
