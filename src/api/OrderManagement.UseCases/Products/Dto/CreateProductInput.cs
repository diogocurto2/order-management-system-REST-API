namespace OrderManagement.UseCases.Products.Dto
{
    public class CreateProductInput
    {
        public CreateProductInput(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
    }
}
