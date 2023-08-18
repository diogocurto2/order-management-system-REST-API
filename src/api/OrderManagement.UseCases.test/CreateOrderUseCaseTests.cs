using Moq;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Orders;
using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.test
{
    [TestFixture]
    public class CreateOrderUseCaseTests
    {
        [Test]
        public async Task CreateOrderAsync_Successful()
        {
            // Arrange
            var customerId = 1;
            var product1Id = 2;
            var product2Id = 3;
            var input = new CreateOrderInput
            (
                customerId,
                new List<CreateOrderItemInput>
                {
                    new CreateOrderItemInput(product1Id,2),
                    new CreateOrderItemInput(product2Id,3)
                }
            );

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId))
                .ReturnsAsync(new Customer("test", "test last name", "name@email.com"));

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.GetByIdAsync(product1Id))
                .ReturnsAsync(new Product("Product A", 10.00m, "description"));
            mockProductRepository.Setup(repo => repo.GetByIdAsync(product2Id))
                .ReturnsAsync(new Product("Product B", 20.00m, "description"));

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.AddAsync(It.IsAny<Order>()))
                .ReturnsAsync(1);

            var useCase = new CreateOrderUseCase(
                mockOrderRepository.Object,
                mockProductRepository.Object,
                mockCustomerRepository.Object
            );

            // Act
            var result = await useCase.Execute(input);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.OrderId, Is.EqualTo(1));
        }

        [Test]
        public void CreateOrderAsync_ThrowsArgumentException_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerId = 1;
            var input = new CreateOrderInput
            (
                customerId,
                new List<CreateOrderItemInput>
                {
                    new CreateOrderItemInput(2 ,2),
                }
            );

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var mockOrderRepository = new Mock<IOrderRepository>();

            var useCase = new CreateOrderUseCase(
                mockOrderRepository.Object,
                mockProductRepository.Object,
                mockCustomerRepository.Object
            );

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(input));
        }

        [Test]
        public void CreateOrderAsync_ThrowsArgumentException_WhenProductDoesNotExist()
        {
            // Arrange
            var customerId = 1;
            var input = new CreateOrderInput
            (
                customerId,
                new List<CreateOrderItemInput>
                {
                    new CreateOrderItemInput(2 ,2),
                }
            );

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId))
                .ReturnsAsync(new Customer("test", "test last name", "name@email.com"));

            var mockProductRepository = new Mock<IProductRepository>();
            var mockOrderRepository = new Mock<IOrderRepository>();

            var useCase = new CreateOrderUseCase(
                mockOrderRepository.Object,
                mockProductRepository.Object,
                mockCustomerRepository.Object
            );

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(() => useCase.Execute(input));
        }
    }
}
