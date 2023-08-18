using OrderManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Test
{
    [TestFixture]
    public class StockTests
    {
        [Test]
        public void CreateStock_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int productId = 1;
            int quantityExpected = 0;

            // Act
            var stock = new Stock(productId);

            // Assert
            Assert.That(stock.ProductId, Is.EqualTo(productId));
            Assert.That(stock.Quantity, Is.EqualTo(quantityExpected));
        }

    }
}
