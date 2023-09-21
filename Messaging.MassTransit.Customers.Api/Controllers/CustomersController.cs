using Messaging.MassTransit.Customers.Api.Bus;
using Messaging.MassTransit.Customers.Api.Models;
using Messaging.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Messaging.MassTransit.Customers.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IBusService _bus;

        public CustomersController(IBusService bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerInputModel model)
        {
            var @event = new CustomerCreated(model.Id, model.FullName, model.Email, model.PhoneNumber, model.BirthDate);

            await _bus.Publish(@event);

            return NoContent();
        }
    }
}

