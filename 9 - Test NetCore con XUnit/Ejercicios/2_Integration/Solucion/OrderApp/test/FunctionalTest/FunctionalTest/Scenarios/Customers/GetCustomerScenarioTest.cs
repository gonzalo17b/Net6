using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using FunctionalTest.Given;
using OrderApp.Models.Customers;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollection)]
    public class GetCustomerScenarioTest
    {
        private readonly TestHostFixture _host;
        private readonly Func<int, string> _url;
        private readonly GivenFixture _given;

        public GetCustomerScenarioTest(TestHostFixture host)
        {
            this._host = host;
            this._url = (int id) => $"/api/customers/{id}";
            this._given = new GivenFixture(host);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_notfound_when_not_customers_exists()
        {
            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(1));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_created_a_customer()
        {
            var customerId = await _given.a_customer();

            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(customerId));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_created_a_customer_with_the_same_props()
        {
            var name = "Pepe";
            var surname = "Lopez";
            var age = 23;
            var email = "email@email.com";
            var customerId = await _given.a_customer(name, surname, age, email);

            var customer = await _host.Server
                .CreateClient()
                .GetJsonAsync<CustomerResponse>(_url(customerId));

            customer?.Name.Should().Be(name);
            customer?.Surname.Should().Be(surname);
            customer?.Age.Should().Be(age);
            customer?.Email.Should().Be(email);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_created_a_customer_desactive()
        {
            var customerId = await _given.a_customer_desactive();

            var response = await _host.Server
                .CreateClient()
                .GetAsync(_url(customerId));

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
