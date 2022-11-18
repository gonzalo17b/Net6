using FunctionalTest.Fixtures;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Services.Contracts;
using System;

namespace FunctionalTest.Given
{
    public partial class GivenFixture
    {
        private readonly Random _random;
        public ICustomerService CustomerService { get; private set; }
        public IProductsService ProductService { get; private set; }


        public GivenFixture(TestHostFixture fixture)
        {
            CustomerService = fixture.Server.Services.GetService<ICustomerService>()!;
            ProductService = fixture.Server.Services.GetService<IProductsService>()!;
            _random = new Random();
        }
    }
}
