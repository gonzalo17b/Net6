using OrderApp.Models.Products;
using System.Threading.Tasks;

namespace FunctionalTest.Given
{
    public partial class GivenFixture
    {
        public async Task<int> a_product(
            string name = "ProductWithMoreThan12Characters",
            string description = "Description",
            int price = 20)
        {
            var requestCustomer = new CreateProductRequest
            {
                Name = name,
                Description = description,
                Price = price
            };

            return await ProductService.Create(requestCustomer);
        }

        public async Task<int> a_product_out_of_catalog(
            string name = "ProductWithMoreThan12Characters",
            string description = "Description",
            int price = 20)
        {
            var id = await a_product(name, description, price);

            await ProductService.RemoveFromCatalog(id);

            return id;
        }
    }
}