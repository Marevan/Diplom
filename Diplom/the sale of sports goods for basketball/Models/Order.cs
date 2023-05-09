namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}