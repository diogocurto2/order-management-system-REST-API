using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.UseCases.Products
{
    public class CreateProductUseCase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public CreateProductUseCase(
            //IUnitOfWork unitOfWork, 
            IProductRepository productRepository)
        {
            //_unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<int> Execute(CreateProductInput input)
        {
            //using var transaction = _unitOfWork.BeginTransaction();

            var product = new Product(input.Name, input.Price, input.Description);
            await _productRepository.AddAsync(product);

            // Create a stock entry with initial quantity 0
            var stock = new Stock(product.Id);
            //_unitOfWork.StockRepository.Add(stock);

            //await _unitOfWork.CommitAsync();

            return product.Id;
        }
    }
}
