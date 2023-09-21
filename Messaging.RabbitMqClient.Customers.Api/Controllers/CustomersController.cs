using Messaging.RabbitMqClient.Customers.Api.Bus;
using Messaging.Shared;
using Messaging.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messaging.RabbitMqClient.Customers.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        const string ROUTING_KEY = "customer-created";
        private readonly IBusService _bus;

        public CustomersController(IBusService bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public IActionResult Post(CustomerInputModel model)
        {
            var @event = new CustomerCreated(model.Id, model.FullName, model.Email, model.PhoneNumber, model.BirthDate);

            _bus.Publish(ROUTING_KEY, @event);

            return NoContent();
        }
    }
}

