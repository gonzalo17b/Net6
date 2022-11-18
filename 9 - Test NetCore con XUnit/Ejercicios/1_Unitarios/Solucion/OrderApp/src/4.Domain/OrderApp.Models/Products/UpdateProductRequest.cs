namespace OrderApp.Models.Products
{
    public class UpdateProductRequest
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
    }
}
