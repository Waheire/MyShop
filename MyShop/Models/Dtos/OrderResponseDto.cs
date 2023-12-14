namespace MyShop.Models.Dtos
{
    public class OrderResponseDto
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid orderItemId { get; set; }
    }
}
