using OrderManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Test
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void Order_Constructor_InitializesProperties()
        {
            // Arrange
            var customerId = 1;

            // Act
            var order = new Order(customerId);

            // Assert
            Assert.That(order.CustomerId, Is.EqualTo(customerId));
            Assert.NotNull(order.Items);
            Assert.IsEmpty(order.Items);
        }

        [Test]
        public void Order_AddOrderItem_AddsItemToOrderItems()
        {
            // Arrange
            var order = new Order(1);
            var product = new Product("Product test", 1.9M, "description");
            var quantity = 3;

            // Act
            order.AddOrderItem(product, quantity);

            // Assert
            Assert.That(order.Items.Count, Is.EqualTo(1));
            var orderItem = order.Items.First();
            Assert.That(orderItem.ProductId, Is.EqualTo(product.Id));
            Assert.That(orderItem.Quantity, Is.EqualTo(quantity));
        }

        [Test]
        public void Order_AddOrderItem_ThrowsArgumentNullExceptionForNullProduct()
        {
            // Arrange
            var order = new Order(1);
            Product? product = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => order.AddOrderItem(product, 3));
        }

        [Test]
        public void Order_AddOrderItem_ThrowsArgumentExceptionForInvalidQuantity()
        {
            // Arrange
            var order = new Order(1);
            var product = new Product("Product test", 1.9M, "description");

            // Act and Assert
            Assert.Throws<ArgumentException>(() => order.AddOrderItem(product, 0));
        }

    }
}
