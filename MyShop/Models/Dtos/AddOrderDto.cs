namespace MyShop.Models.Dtos
{
    public class AddOrderDto
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid ProductId { get; set; }
    }
}
