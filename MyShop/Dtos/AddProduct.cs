namespace MyShop.Dtos
{
    public class AddProduct
    {
        public string Name { get; set; }
        public Guid OrderId { get; set; }
        public int Price { get; set; } = 0;
    }
}
