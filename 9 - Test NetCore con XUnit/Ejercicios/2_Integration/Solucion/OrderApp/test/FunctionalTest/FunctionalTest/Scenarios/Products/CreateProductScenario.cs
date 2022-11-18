using AutoFixture;
using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using OrderApp.Api;
using OrderApp.Models.Products;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Products
{
    [Collection(TestConstants.TestCollection)]
    public class CreateProductScenario
    {
        private readonly TestHostFixture _host;
        private readonly string _url;
        private readonly Fixture _autofixture;
        private readonly Random _random;

        public CreateProductScenario(TestHostFixture host)
        {
            this._host = host;
            this._url = $"/{ApiConstants.BaseUri}/{ApiConstants.ProductsUri}";
            this._autofixture = new Fixture();
            this._random = new Random();
        }

        [Fact]
        public async Task return_preconditionfailed_when_not_customers_exists()
        {
            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, new { });

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public async Task return_preconditionfailed_when_request_name_is_null()
        {
            var request = this._autofixture
                .Build<CreateProductRequest>()
                .Without(product => product.Name)
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public async Task return_ok_when_request_description_is_null()
        {
            var request = this._autofixture
                .Build<CreateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .Without(product => product.Description)
                .With(product => product.Price, _random.Next(0, 50))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.EnsureSuccessStatusCode();

            int.TryParse(await response.Content.ReadAsStringAsync(), out int id);

            var result = await _host.Server
                .CreateClient()
                .GetJsonAsync<ProductResponse>(response.Headers.Location.AbsoluteUri)!;

            result?.Id.Should().Be(id);
            result?.Name.Should().Be(request.Name);
            result?.Description.Should().Be(request.Description);
            result?.Price.Should().Be(request.Price);
        }

        [Fact]
        public async Task return_ok_when_request_price_is_minor_0()
        {
            var request = this._autofixture
                .Build<CreateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, _random.Next(-50, -1))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public async Task return_ok_when_request_price_is_0()
        {
            var request = this._autofixture
                .Build<CreateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, 0)
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.EnsureSuccessStatusCode();

            int.TryParse(await response.Content.ReadAsStringAsync(), out int id);

            var result = await _host.Server
                .CreateClient()
                .GetJsonAsync<ProductResponse>(response.Headers.Location.AbsoluteUri)!;

            result?.Id.Should().Be(id);
            result?.Name.Should().Be(request.Name);
            result?.Description.Should().Be(request.Description);
            result?.Price.Should().Be(request.Price);
        }

        [Fact]
        public async Task return_ok_when_request_is_ok()
        {
            var request = this._autofixture
                .Build<CreateProductRequest>()
                .With(product => product.Name, "NameWith12Characters")
                .With(product => product.Price, _random.Next(0, 50))
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.EnsureSuccessStatusCode();

            int.TryParse(await response.Content.ReadAsStringAsync(), out int id);

            var result = await _host.Server
                .CreateClient()
                .GetJsonAsync<ProductResponse>(response.Headers.Location.AbsoluteUri)!;

            result?.Id.Should().Be(id);
            result?.Name.Should().Be(request.Name);
            result?.Description.Should().Be(request.Description);
            result?.Price.Should().Be(request.Price);
        }
    }
}
