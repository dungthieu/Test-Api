using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.SupplierModels
{
    public class SupplierSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<SupplierListModels> SupplierModels { get; set; }
    }
}
