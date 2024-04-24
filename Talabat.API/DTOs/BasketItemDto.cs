using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be Greater than zero")]
        public decimal Price { get; set; } // Not the price of product but this price in basket [after Quantity or discount]

        [Required]
        public string Category { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage ="Quatity Must be at least one item")]
        public int Quantity { get; set; }
    }
}