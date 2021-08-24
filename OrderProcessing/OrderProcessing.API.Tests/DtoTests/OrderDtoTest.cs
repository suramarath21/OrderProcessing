using OrderProcessing.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderProcessing.API.Tests.DtoTests
{
    public class OrderDtoTest : DtoTest
    {
        private Order order =
            new Order() { BuyerId = "test" };

        [Fact]
        public void InvalidOrder()
        {
            var result = ValidateModel(order);
            Assert.True(result.Count > 0);
            Assert.Contains(result, e => e.ErrorMessage.Contains("The Items field is required."));
        }
    }
}
