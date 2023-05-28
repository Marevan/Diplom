using System.ComponentModel.DataAnnotations;

namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required, MaxLength(100)]
        public string Category { get; set; }
    }
}