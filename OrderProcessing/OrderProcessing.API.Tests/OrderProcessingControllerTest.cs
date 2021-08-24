using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OrderProcessing.API.Controllers;
using OrderProcessing.Core.Managers;
using OrderProcessing.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderProcessing.API.Tests
{
    public class OrderProcessingControllerTest
    {
        private readonly Mock<IOrderPaymentsManager> _manager;
        private readonly Mock<ILogger<OrderProcessingController>> _logger;
        private readonly OrderProcessingController _controller;

        public OrderProcessingControllerTest()
        {
            _manager = new Mock<IOrderPaymentsManager>();
            _logger = new Mock<ILogger<OrderProcessingController>>();

            _controller = new OrderProcessingController(_logger.Object, _manager.Object);
        }

        [Fact]
        public void Initialization()
        {
            Assert.NotNull(_controller);
        }

        [Fact]
        public async Task Payments_Failed_Test()
        {
            var result = await _controller.Payments(new Order());

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Payments_Success_Test()
        {
            _manager.Setup(q => q.ProcessPayment(It.IsAny<Order>())).Returns(Task.FromResult(true));

            var result = await _controller.Payments(null);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
