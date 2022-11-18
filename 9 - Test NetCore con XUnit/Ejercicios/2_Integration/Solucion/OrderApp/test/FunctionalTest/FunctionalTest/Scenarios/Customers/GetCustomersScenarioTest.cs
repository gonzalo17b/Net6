using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using FunctionalTest.Given;
using OrderApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollection)]
    public class GetCustomersScenarioTest
    {
        private readonly TestHostFixture _host;
        private readonly string _url;
        private readonly GivenFixture _given;

        public GetCustomersScenarioTest(TestHostFixture host)
        {
            this._host = host;
            this._url = "/api/customers";
            this._given = new GivenFixture(host);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_not_customers_exists()
        {
            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<Customer>>(_url);

            customers?.Count().Should().Be(0);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_has_3_customers_in_the_system()
        {
            await _given.some_customers(3);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<Customer>>(_url);

            customers?.Count().Should().Be(3);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_has_6_customers_in_the_system()
        {
            await _given.some_customers(6);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<Customer>>(_url);

            customers?.Count().Should().Be(6);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_has_6_customers_active_and_3_desactive_in_the_system()
        {
            await _given.some_customers(6);
            await _given.some_customers_desactive(3);

            var customers = await _host.Server
                .CreateClient()
                .GetJsonAsync<IEnumerable<Customer>>(_url);

            customers?.Count().Should().Be(6);
        }
    }
}
