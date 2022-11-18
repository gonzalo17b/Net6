using AutoFixture;
using FluentAssertions;
using FunctionalTest.Extensions;
using FunctionalTest.Fixtures;
using FunctionalTest.Fixtures.Resets;
using FunctionalTest.Given;
using OrderApp.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollection)]
    public class UpdateCustomerScenario
    {
        private readonly TestHostFixture _host;
        private readonly Func<int, string> _url;
        private readonly GivenFixture _given;
        private readonly Fixture _autofixture;

        public UpdateCustomerScenario(TestHostFixture host)
        {
            this._host = host;
            this._url = (int id) => $"/api/customers/{id}";
            this._given = new GivenFixture(host);
            this._autofixture = new Fixture();
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_notfound_when_not_customers_exists()
        {
            var request = this._autofixture
                .Build<UpdateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(1), request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_notfound_when_not_customers_is_desactive()
        {
            var id = await _given.a_customer_desactive();
            var request = this._autofixture
                .Build<UpdateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_request_name_is_null()
        {
            var id = await _given.a_customer();
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .Without(customer => customer.Name)
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_request_surname_is_null()
        {
            var id = await _given.a_customer();
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .Without(customer => customer.Surname)
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_age_is_smaller_than_18()
        {
            var id = await _given.a_customer();
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .With(customer => customer.Age, 5)
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_preconditionfailed_when_request_has_wrong_email()
        {
            var id = await _given.a_customer();
            var request = this._autofixture
                .Build<CreateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "emailwitoutarroba")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_customer_exists()
        {
            var id = await _given.a_customer();
            var request = this._autofixture
                .Build<UpdateCustomerRequest>()
                .With(customer => customer.Age, new Random().Next(18, 80))
                .With(customer => customer.Email, "email@email.com")
                .Create();

            var response = await _host.Server
                .CreateClient()
                .PutJsonAsync(_url(id), request);

            response.EnsureSuccessStatusCode();
        }
    }
}
