#nullable disable

namespace Test.DataAccess.Models
{
    public partial class Cart
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ProductName { get; set; }
        public string CookieName { get; set; }
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
