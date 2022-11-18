

using Microsoft.AspNetCore.Mvc;
using OrderApp.Models.Products;
using OrderApp.Services.Contracts;
using System.Net;

namespace OrderApp.Api.Controllers
{
    [Route($"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet("", Name = nameof(ProductsController.GetProducts))]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetAlls();
            return Ok(products);
        }

        [HttpGet(ApiConstants.ProductIdParam, Name = nameof(ProductsController.GetProduct))]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProduct([FromRoute] int productId)
        {
            var product = await _productService.Get(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut(ApiConstants.ProductIdParam, Name = nameof(ProductsController.PutProduct))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> PutProduct([FromRoute] int productId, [FromBody] UpdateProductRequest productRequest)
        {
            await _productService.Update(productId, productRequest);
            return Ok();
        }

        [HttpPost("", Name = nameof(ProductsController.PostProduct))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostProduct([FromBody] CreateProductRequest product)
        {
            var id = await _productService.Create(product);
            return this.CreatedAtAction(nameof(ProductsController.GetProduct), new { productId = id }, id);
        }

        [HttpDelete(ApiConstants.ProductIdParam, Name = nameof(ProductsController.DeleteProduct))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int productId)
        {
            await _productService.Delete(productId);

            return NoContent();
        }
    }
}
