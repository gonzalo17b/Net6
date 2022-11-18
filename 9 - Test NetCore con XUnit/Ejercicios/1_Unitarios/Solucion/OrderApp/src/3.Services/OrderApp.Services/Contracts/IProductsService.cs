using OrderApp.Models.Products;

namespace OrderApp.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAlls();
        Task<ProductResponse> Get(int id);
        Task<int> Create(CreateProductRequest product);
        Task Update(int id, UpdateProductRequest product);
        Task Delete(int id);
        Task Discontinue(int id);
    }
}
