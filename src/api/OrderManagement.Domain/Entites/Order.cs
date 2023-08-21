namespace OrderManagement.Domain.Entites
{
    public class Order
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime Date { get; private set; }
        public decimal TotalCost { get; private set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; private set; }

        private Order() { }

        public Order(int customerId)
        {
            CustomerId = customerId;
            Items = new List<OrderItem>();
        }

        public void AddOrderItem(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var orderItem = new OrderItem(product, quantity);
            Items.Add(orderItem);
        }

    }
}
