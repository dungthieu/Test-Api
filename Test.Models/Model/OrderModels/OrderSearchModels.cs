using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.OrderModels
{
    public class OrderSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColunm { get; set; }
        public string SortDirection { get; set; }
        public List<OrderListModels> OrderModels { get; set; }
    }
}
