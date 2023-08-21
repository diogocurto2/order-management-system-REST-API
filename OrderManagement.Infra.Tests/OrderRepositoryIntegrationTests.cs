using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entites;
using OrderManagement.Infra.Data;
using OrderManagement.Infra.Repositories;

namespace OrderManagement.Infra.Tests
{
    [TestFixture]
    public class OrderRepositoryIntegrationTests
    {
        private string _testDbConnectionString;
        private OrderRepository _orderRepository;
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _testDbConnectionString = "Data Source=localhost,1433;Initial Catalog=OrderManagement;" +
                " MultipleActiveResultSets=true; User ID=sa; Password=P4ssw0rd; TrustServerCertificate=true"; 
            var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
                .UseSqlServer(_testDbConnectionString)
                .Options;

            var dbContext = new OrderManagementDbContext(options);
            _orderRepository = new OrderRepository(dbContext);
            _productRepository = new ProductRepository(dbContext);
        }

        [Test]
        public async Task TestDatabaseConnection()
        {
            // Arrange

            // Act
            using (var connection = new SqlConnection(_testDbConnectionString))
            {
                // Assert
                connection.Open();
                Assert.True(connection.State == System.Data.ConnectionState.Open, "If this test fail, change de string connection.");
            }
        }

        [Test]
        public async Task AddAsync_ValidOrder_ReturnsOrderId()
        {
            // Arrange
            var product = await _productRepository.GetByIdAsync(1);
            var order = new Order(1);
            order.AddOrderItem(product, 1);

            // Act
            var result = await _orderRepository.AddAsync(order);

            // Assert
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public async Task AddAsync_InvalidProduct_RaisesError()
        {
            // Arrange
            var product = new Product("test", 0, "test");
            var order = new Order(1);
            order.AddOrderItem(product, 1);

            // Act and Assert
            Assert.ThrowsAsync<SqlException>(() => _orderRepository.AddAsync(order));
        }
    }
}