namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class SalesHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
