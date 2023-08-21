using OrderManagement.Domain.Entites;

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
