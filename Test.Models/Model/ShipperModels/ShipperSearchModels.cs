using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.ShipperModels
{
    public class ShipperSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<ShipperListModels> ShipperModels { get; set; }
    }
}
