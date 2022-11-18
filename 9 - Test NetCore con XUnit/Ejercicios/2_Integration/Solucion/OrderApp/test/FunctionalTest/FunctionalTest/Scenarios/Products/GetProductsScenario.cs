using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using FunctionalTest.Given;
using OrderApp.Api;
using OrderApp.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Products
{
    [Collection(TestConstants.TestCollection)]
    public class GetProductsScenario
    {
        private readonly TestHostFixture _host;
        private readonly string _url;
        private readonly GivenFixture _given;

        public GetProductsScenario(TestHostFixture host)
        {
            this._host = host;
            this._url = $"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}";
            this._given = new GivenFixture(host);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_not_products_exists()
        {
            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<ProductResponse>>(_url);

            customers?.Count().Should().Be(0);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_has_3_customers_in_the_system()
        {
            await _given.some_products(3);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<ProductResponse>>(_url);

            customers?.Count().Should().Be(3);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_has_6_customers_in_the_system()
        {
            await _given.some_products(6);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<ProductResponse>>(_url);

            customers?.Count().Should().Be(6);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_has_6_customers_active_and_3_desactive_in_the_system()
        {
            await _given.some_products(6);
            await _given.some_customers_out_of_catalog(3);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<ProductResponse>>(_url);

            customers?.Count().Should().Be(6);
        }
    }
}
