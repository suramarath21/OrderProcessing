using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessing.Core.Models
{
    public class Order
    {
        [Required]
        public IEnumerable<Item> Items { get; set; }

        [Required]
        public string BuyerId { get; set; }
    }
}
