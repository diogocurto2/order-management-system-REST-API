using Moq;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Orders;
using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.test
{
    [TestFixture]
    public class GetOrderByIdUseCaseTests
    {
        [Test]
        public async Task Execute_OrderExists_ReturnsExpectedOutputDTO()
        {
            // Arrange
            var orderId = 1;
            var expectedOrder = new Order(123);
            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.GetByIdAsync(orderId)).ReturnsAsync(expectedOrder);
            var useCase = new GetOrderByIdUseCase(mockOrderRepository.Object);

            // Act
            var result = await useCase.Execute(new GetOrderByIdInput(orderId));

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.CustomertId, Is.EqualTo(expectedOrder.CustomerId));
        }

        [Test]
        public void Execute_ThrowsArgumentException_WhenOrderDoesNotExist()
        {
            // Arrange
            var orderId = 1;
            var mockOrderRepository = new Mock<IOrderRepository>();

            var useCase = new GetOrderByIdUseCase(mockOrderRepository.Object);

            // Act and Assert
            var input = new GetOrderByIdInput(orderId);
            Assert.ThrowsAsync<NotFoundException>(() => useCase.Execute(input));
        }
    }
}
