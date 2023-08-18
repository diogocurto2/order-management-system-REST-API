using Moq;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Products;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.UseCases.test
{
    [TestFixture]
    public class GetProductByIdUseCaseTests
    {
        [Test]
        public async Task Execute_ReturnsProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var expectedProductName = "Product A";
            var expectedProductPrice = 10.00M;
            var expectedProductDescription = "Sample product description";
            var expectedProductStockQuantity = 0;
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync(new Product(
                    expectedProductName,
                    expectedProductPrice,
                    expectedProductDescription)
                );

            var useCase = new GetProductByIdUseCase(mockProductRepository.Object);

            // Act
            var input = new GetProductByIdInput (productId);
            var result = await useCase.Execute(input);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.ProductName, Is.EqualTo(expectedProductName));
            Assert.That(result.ProductPrice, Is.EqualTo(expectedProductPrice));
            Assert.That(result.ProductDescription, Is.EqualTo(expectedProductDescription));
            Assert.That(result.ProductStockQuantity, Is.EqualTo(expectedProductStockQuantity));
        }

        [Test]
        public void Execute_ThrowsArgumentException_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            var mockProductRepository = new Mock<IProductRepository>();

            var useCase = new GetProductByIdUseCase(mockProductRepository.Object);

            // Act and Assert
            var input = new GetProductByIdInput(productId);
            Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(input));
        }
    }
}