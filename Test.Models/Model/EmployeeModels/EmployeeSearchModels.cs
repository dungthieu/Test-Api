using System.Collections.Generic;
using Test.Models.Common;

namespace Test.Models.Model.EmployeeModels
{
    public class EmployeeSearchModels : Pagging
    {
        public string TextSearch { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public List<EmployeeListModels> EmployeeModel { get; set; }
    }
}
