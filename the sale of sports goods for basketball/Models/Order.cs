using System.ComponentModel.DataAnnotations;

namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Id_client { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
    }
}