using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.UseCases.Products
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {

        private readonly IProductRepository _productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByIdOutput> Execute(GetProductByIdInput input)
        {
            var product = await _productRepository.GetByIdAsync(input.ProductId);
            if (product == null)
            {
                throw new ArgumentException(
                    string.Format("ProductId {0} does not exists", input.ProductId)
                    );
            }

            return new GetProductByIdOutput(
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.Stock.Quantity
            );
        }
    }
}
