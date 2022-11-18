using AutoFixture;
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
    public class UpdateProductScenario
    {
        private readonly TestHostFixture _host;
        private readonly Func<int, string> _url;
        private readonly Fixture _autofixture;
        private readonly Random _random;
        private readonly GivenFixture _given;

        public UpdateProductScenario(TestHostFixture host) 
        {
            this._host = host;
            this._url = (int id) => $"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}/{id}";
            this._autofixture = new Fixture();
            this._random = new Random();
            this._given = new GivenFixture(host);
        }


        [Fact]
        public async Task return_notfound_when_not_customers_exists()
        {
            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(1), new { });

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task return_preconditionfailed_when_request_name_is_null()
        {
            var productId = await _given.a_product();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .Without(product => product.Name)
                .With(product => product.Price, _random.Next(0, 100))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_request_description_is_null()
        {
            var productId = await _given.a_product();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .Without(product => product.Description)
                .With(product => product.Price, _random.Next(0, 100))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        [ResetProductsService]
        public async Task return_preconditionfailed_when_request_price_is_negative()
        {
            var productId = await _given.a_product();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, _random.Next(-100, -1))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_request_price_is_0()
        {
            var productId = await _given.a_product();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, 0)
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.EnsureSuccessStatusCode();
        }


        [Fact]
        [ResetProductsService]
        public async Task return_ok_when_request_price_is_ok()
        {
            var productId = await _given.a_product();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, _random.Next(0, 100))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        [ResetProductsService]
        public async Task return_notfound_when_product_is_out_of_catalog()
        {
            var productId = await _given.a_product_out_of_catalog();

            var request = this._autofixture
                .Build<UpdateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, _random.Next(0, 100))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(productId), request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
