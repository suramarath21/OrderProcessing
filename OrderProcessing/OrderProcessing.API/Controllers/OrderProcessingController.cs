using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderProcessing.API.Attributes;
using OrderProcessing.Core;
using OrderProcessing.Core.Managers;
using OrderProcessing.Core.Models;

namespace OrderProcessing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ValidateModel]
    public class OrderProcessingController : ControllerBase
    {
        private readonly ILogger<OrderProcessingController> _logger;
        private readonly IOrderPaymentsManager _manager;

        public OrderProcessingController(ILogger<OrderProcessingController> logger, IOrderPaymentsManager orderPaymentsManager)
        {
            _logger = logger;
            _manager = orderPaymentsManager;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Payments(Order order)
        {
            await _manager.ProcessPayment(order);
            _logger.LogInformation(Constants.PaymentProcessedMessage);
            return NoContent();
        }
    }
}
