﻿namespace Test.Models.Model.CartModels
{
    public class CartListModels
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string CookieName { get; set; }
        public string CustomerId { get; set; }
    }
}
