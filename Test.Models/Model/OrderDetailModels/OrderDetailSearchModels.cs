using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.OrderDetailModels
{
    public class OrderDetailSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColunm { get; set; }
        public string SortDirection { get; set; }
        public List<OrderDetailListModels> OrderDetail { get; set; }
    }
}
