using AutoFixture;
using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using OrderApp.Models.Customers;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollection)]
    public class CreateCustomerScenario
    {
        private readonly TestHostFixture _host;
        private readonly string _url;
        private readonly Fixture _autofixture;

        public CreateCustomerScenario(TestHostFixture host)
        {
            this._host = host;
            this._url = $"/api/customers";
            this._autofixture = new Fixture();
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_not_customers_exists()
        {
            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, new { });

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_name_is_null()
        {
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .Without(customer => customer.Name)
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_surname_is_null()
        {
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .Without(customer => customer.Surname)
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_age_is_smaller_than_18()
        {
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .With(customer => customer.Age, 5)
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_has_wrong_email()
        {
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "emailwitoutarroba")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_customer_is_ok()
        {
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PostJsonAsync(_url, request);

            response.EnsureSuccessStatusCode();

            var result = await _host.Server
                .CreateClient()
                .GetJsonAsync<CustomerResponse>(response.Headers.Location.AbsoluteUri)!;

            result.Name.Should().Be(request.Name);
            result.Surname.Should().Be(request.Surname);
            result.Age.Should().Be(request.Age);
            result.Email.Should().Be(request.Email);
        }
    }
}
