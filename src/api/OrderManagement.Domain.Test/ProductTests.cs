using OrderManagement.Domain.Entites;

namespace OrderManagement.Domain.Test
{
    public class ProductTests
    {
        [Test]
        public void Product_Initialization_Succeeds()
        {
            // Arrange
            var expectedName = "Sample Product";
            decimal expectedPrice = 10.99M;
            var expectedDescription = "A sample product description.";

            // Act 
            var product = new Product(
                expectedName,
                expectedPrice,
                expectedDescription
            );


            // Assert
            Assert.NotNull(product);
            Assert.That(product.Id, Is.EqualTo(0));
            Assert.That(product.Name, Is.EqualTo(expectedName));
            Assert.That(product.Price, Is.EqualTo(expectedPrice));
            Assert.That(product.Description, Is.EqualTo(expectedDescription));
        }
    }
}