using OrderManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Test
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void Customer_Initialization_Succeeds()
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var email = "john.doe@example.com";

            // Act
            var customer = new Customer(firstName, lastName, email);

            // Assert
            Assert.NotNull(customer);
            Assert.That(customer.FirstName, Is.EqualTo(firstName));
            Assert.That(customer.LastName, Is.EqualTo(lastName));
            Assert.That(customer.Email, Is.EqualTo(email));
        }
    }
}
