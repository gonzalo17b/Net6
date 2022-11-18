namespace OrderApp.Models.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
