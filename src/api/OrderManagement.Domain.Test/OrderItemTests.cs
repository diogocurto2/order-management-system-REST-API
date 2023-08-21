using OrderManagement.Domain.Entites;

namespace OrderManagement.Domain.Test
{
    [TestFixture]
    public class OrderItemTests
    {
        [Test]
        public void OrderItem_Creation_Succeeds()
        {
            // Arrange
            var product = new Product("Product test", 1.9M, "description"); 
            var quantity = 3;

            // Act
            var orderItem = new OrderItem(product, quantity);

            // Assert
            Assert.NotNull(orderItem);
            Assert.That(orderItem.ProductId, Is.EqualTo(product.Id));
            Assert.That(orderItem.Quantity, Is.EqualTo(quantity));
        }

    }
}
