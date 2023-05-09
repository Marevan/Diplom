namespace the_sale_of_sports_goods_for_basketball.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; }
        
    }
}
