namespace OrderManagement.Domain.Entites
{
    public class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }

        // Navigation property
        public Stock Stock { get; private set; }

        private Product() { }

        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
