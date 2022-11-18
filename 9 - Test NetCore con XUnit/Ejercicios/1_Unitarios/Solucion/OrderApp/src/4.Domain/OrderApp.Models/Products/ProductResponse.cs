using OrderApp.Domain;

namespace OrderApp.Models.Products
{
    public class ProductResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int Price { get; private set; }

        public static ProductResponse ToMapper(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
