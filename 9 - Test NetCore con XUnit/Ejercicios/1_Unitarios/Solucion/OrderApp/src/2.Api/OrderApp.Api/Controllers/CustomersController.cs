using Microsoft.AspNetCore.Mvc;
using OrderApp.Models;
using OrderApp.Models.Customers;
using OrderApp.Services.Contracts;
using System.Net;

namespace OrderApp.Api.Controllers
{
    [Route($"/{ApiConstants.BaseUri}/{ApiConstants.CustomersUri}")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customersService;

        public CustomersController(ICustomerService customerService)
        {
            _customersService = customerService;
        }

        [HttpGet("", Name = nameof(CustomersController.GetAlls))]
        [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetAlls([FromQuery] GetCustomersRequest request)
        {
            var clients = await _customersService.GetAlls();
            return Ok(clients);
        }

        [HttpGet(ApiConstants.ProductIdParam, Name = nameof(CustomersController.Get))]
        [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get([FromRoute] int customerId)
        {
            var customer = await _customersService.Get(customerId);

            if (customer == null) 
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut(ApiConstants.ProductIdParam, Name = nameof(CustomersController.Put))]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Put([FromRoute] int customerId, [FromBody] UpdateCustomerRequest customerRequest)
        {
            await _customersService.Update(customerId, customerRequest);
            return Ok();
        }

        [HttpPost("", Name = nameof(CustomersController.Post))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Post([FromBody] CreateCustomerRequest customer)
        {
            var id = await _customersService.Create(customer);
            return this.CreatedAtAction(nameof(CustomersController.Get), new { customerId = id }, id);
        }

        [HttpDelete(ApiConstants.ProductIdParam, Name = nameof(CustomersController.Delete))]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int customerId)
        {
            await _customersService.Delete(customerId);

            return NoContent();
        }
    }
}
