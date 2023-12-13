using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> orderItems { get; set;}
    }
}
