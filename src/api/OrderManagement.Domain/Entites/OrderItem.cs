namespace OrderManagement.Domain.Entites
{
    public class OrderItem
    {
        public int OrderId { get; private set; }
        public int ItemId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Cost { get; private set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }

        private OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            ProductId = product.Id;
            Product = product;
            Quantity = quantity;
            Cost = quantity * product.Price;
        }
    }
}
