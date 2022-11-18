using OrderApp.Domain;
using OrderApp.Domain.Exceptions;
using OrderApp.Models.Products;
using OrderApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Services.MemoryServices
{
    internal class ProductsMemoryService : IProductsService
    {
        private readonly List<Product> _products = new List<Product>();
        public async Task<int> Create(CreateProductRequest productRequest)
        {
            var newId = 1;
            if (_products.Count() > 0)
            {
                newId = _products.Max(product => product.Id) + 1;
            }

            var product = new Product(newId, productRequest.Name, productRequest.Description, productRequest.Price);
            _products.Add(product);
            return product.Id;
        }

        public async Task<ProductResponse?> Get(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id && !product.OutOfCatalog);
            return product != null ? ProductResponse.ToMapper(product) : null;
        }

        public async Task<IEnumerable<ProductResponse>> GetAlls()
        {
            return _products.Where(product => !product.OutOfCatalog)
                            .Select(product => ProductResponse.ToMapper(product));
        }

        public async Task Update(int id, UpdateProductRequest productRequest)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product != null && !product.OutOfCatalog)
            {
                product.Update(productRequest.Name, productRequest.Description, productRequest.Price);
            }
            else
            {
                throw new NotFoundException("No se ha encontrado el producto");
            }
        }

        public async Task Delete(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product != null && !product.OutOfCatalog)
            {
                _products.Remove(product);
            }
            else
            {
                throw new NotFoundException("No se ha encontrado el producto");
            }
        }

        public async Task Discontinue(int id)
        {
            var product = _products.FirstOrDefault(product => product.Id == id);
            if (product != null && !product.OutOfCatalog)
            {
                product.RemoveFromCatalog();
            }
            else
            {
                throw new NotFoundException("No se ha encontrado el producto");
            }
        }
    }
}
