using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using FunctionalTest.Given;
using OrderApp.Api;
using OrderApp.Models.Products;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Products
{
    [Collection(TestConstants.TestCollection)]
    public class GetProductScenario
    {
        private readonly TestHostFixture _host;
        private readonly Func<int, string> _url;
        private readonly GivenFixture _given;

        public GetProductScenario(TestHostFixture host)
        {
            this._host = host;
            this._url = (int id) => $"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}/{id}";
            this._given = new GivenFixture(host);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_notfound_when_product_not_exists()
        {
            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(1));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_notfound_when_product_is_out_of_catalog()
        {
            var product = _given.a_product_out_of_catalog();

            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(product.Id));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_created_a_product()
        {
            var productId = await _given.a_product();

            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(productId));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_created_a_product_with_the_same_props()
        {
            var name = "NameWith12Characters";
            var description = "Description";
            var price = 20;
            var productId = await _given.a_product(name, description, price);

            var productResponse = await _host.Server
                .CreateClient()
                .GetJsonAsync<ProductResponse>(_url(productId));

            productResponse?.Name.Should().Be(name);
            productResponse?.Description.Should().Be(description);
            productResponse?.Price.Should().Be(price);
        }
    }
}
