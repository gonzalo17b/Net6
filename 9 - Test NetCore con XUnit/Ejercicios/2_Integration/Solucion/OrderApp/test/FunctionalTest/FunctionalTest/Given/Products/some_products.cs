using OrderApp.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalTest.Given
{
    public partial class GivenFixture
    {
        private IEnumerable<CreateProductRequest> SomeProductsRequest(int productsNumber)
        {
            return Enumerable.Range(0, productsNumber)
                      .Select(number =>
                      {
                          return new CreateProductRequest
                          {
                              Name = $"NameWith12Characters",
                              Description = $"Description{number}",
                              Price = _random.Next(0, 100)
                          };
                      });
        }

        public async Task<IEnumerable<CreateProductRequest>> some_products(int productsNumber)
        {
            var products = SomeProductsRequest(productsNumber);

            await Task.WhenAll(
                products.Select(async productRequest => await ProductService.Create(productRequest)
            ));

            return products;
        }

        public async Task<IEnumerable<CreateProductRequest>> some_customers_out_of_catalog(int customersNumber)
        {
            var products = SomeProductsRequest(customersNumber);

            await Task.WhenAll(
                products.Select(
                    async customerRequest =>
                    {
                        var id = await ProductService.Create(customerRequest);
                        await ProductService.RemoveFromCatalog(id);
                    }
                )
            );

            return products;
        }
    }
}
