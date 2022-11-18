using OrderApp.Models.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionalTest.Given
{
    public partial class GivenFixture
    {
        private IEnumerable<CreateCustomerRequest> SomeCustomerRequest(int customersNumber) 
        {
            return Enumerable.Range(0, customersNumber)
                      .Select(number =>
                      {
                          return new CreateCustomerRequest
                          {
                              Name = $"Name{number}",
                              Surname = $"Surname{number}",
                              Age = _random.Next(18, 80),
                              Email = $"email{number}@email.com"
                          };
                      });
        }

        public async Task<IEnumerable<CreateCustomerRequest>> some_customers(int customersNumber) 
        {
            var customers = SomeCustomerRequest(customersNumber);

            await Task.WhenAll(
                customers.Select(async customerRequest => await CustomerService.Create(customerRequest)
            ));

            return customers;
        }

        public async Task<IEnumerable<CreateCustomerRequest>> some_customers_desactive(int customersNumber)
        {
            var customers = SomeCustomerRequest(customersNumber);

            await Task.WhenAll(
                customers.Select(
                    async customerRequest => 
                    {
                        var id = await CustomerService.Create(customerRequest);
                        await CustomerService.DesactiveUser(id);
                    } 
                )
            );

            return customers;
        }
    }
}
