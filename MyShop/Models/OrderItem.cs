using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orderItemId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
