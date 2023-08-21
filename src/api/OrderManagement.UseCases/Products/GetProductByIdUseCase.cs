using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Orders.Dto;
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
                throw new NotFoundException($"Product with ID {input.ProductId} not found.");
            }

            return new GetProductByIdOutput(
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.Stock == null ? 0 :product.Stock.Quantity
            );
        }
    }
}
