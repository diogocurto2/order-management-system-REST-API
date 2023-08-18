namespace ProductManagement.UseCases.Products.Dto
{
    public class CreateProductOutput
    {
        public CreateProductOutput(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; private set; }
    }
}
