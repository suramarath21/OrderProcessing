using OrderProcessing.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessing.Core.Models
{
    public class Item
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ItemType Type { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
