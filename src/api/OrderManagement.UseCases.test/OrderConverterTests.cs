using OrderManagement.Domain.Entites;
using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.test
{
    [TestFixture]
    public class OrderConverterTests
    {
        [Test]
        public void ToOutputDTO_ConvertsOrderToOutputDTO()
        {
            // Arrange
            var order = new Order(123);
            order.AddOrderItem(new Product("PRD 01", 10.3M, "desc"), 2);

            // Act
            var result = OrderConverter.ToOutputDTO(order);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.OrdertId, Is.EqualTo(order.Id));
            Assert.That(result.CustomertId, Is.EqualTo(order.CustomerId));
            Assert.That(result.Items.Count, Is.EqualTo(1));
        }
    }
}
