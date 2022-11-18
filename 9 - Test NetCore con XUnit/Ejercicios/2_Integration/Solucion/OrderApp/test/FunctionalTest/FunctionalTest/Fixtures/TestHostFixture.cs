using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Services.Contracts;
using System;
using System.Linq;

namespace FunctionalTest.Fixtures
{
    public class TestHostFixture : IDisposable
    { 
        private static IServiceProvider Services;

        public TestServer Server { get; set; }

        public TestHostFixture()
        {
            Server = new TestServerBuilder().Build();

            Services = Server.Services;
        }

        public void Reset()
        {
            Server = new TestServerBuilder().Build();
        }

        public static void ResetCustomersService() 
        {
            // Reset Customer Service
            var customerService = Services.GetService<ICustomerService>()!;
            var customersTask = customerService.GetAlls();
            customersTask.Wait();
            var customer = customersTask.Result;
            customer.ToList().ForEach(customer => customerService.Delete(customer.Id));
        }

        public static void ResetProductsService()
        {
            var productsService = Services.GetService<IProductsService>()!;
            var productsTask = productsService.GetAlls();
            productsTask.Wait();
            var products = productsTask.Result;
            products.ToList().ForEach(product => productsService.Delete(product.Id));
        }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}
