using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orderItemId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
