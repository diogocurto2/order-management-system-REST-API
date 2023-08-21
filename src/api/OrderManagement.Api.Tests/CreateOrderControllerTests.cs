using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using OrderManagement.Api.Controllers.Orders;
using OrderManagement.UseCases.Orders;
using OrderManagement.UseCases.Orders.Dto;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Mvc.Routing;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OrderManagement.Api.Tests
{

    [TestFixture]
    public class CreateOrderControllerTests
    {
        private CreateOrderController _controller;
        private Mock<ICreateOrderUseCase> _mockCreateOrderUseCase;
        private const string CONTROLER_URL = @"http://localhost:5000/api/orders/create";

        [SetUp]
        public void Setup()
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(CONTROLER_URL, UriKind.Absolute)
            };
            var httpContext = new DefaultHttpContext();
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock
                .Setup(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns(CONTROLER_URL)
                .Verifiable();

            _mockCreateOrderUseCase = new Mock<ICreateOrderUseCase>();
            _controller = new CreateOrderController(_mockCreateOrderUseCase.Object)
            {
                ControllerContext = controllerContext,
                Url = urlHelperMock.Object
            };
        }

        [Test]
        public async Task Execute_ValidInput_ReturnsCreatedResult()
        {
            // Arrange
            var input = new CreateOrderInput(
                1,
                new List<CreateOrderItemInput>() { new CreateOrderItemInput(1, 1) }
                );
            var expectedResult = new CreateOrderOutput(1);
            _mockCreateOrderUseCase
                .Setup(useCase => useCase.Execute(input))
                .ReturnsAsync(expectedResult);

            // Act
            var response = await _controller.Execute(input) as Created<CreateOrderOutput>;
            var responseValue = response.Value as CreateOrderOutput;

            // Assert
            Assert.That(response.Location, Is.EqualTo(CONTROLER_URL));
            Assert.That(responseValue.OrderId, Is.EqualTo(expectedResult.OrderId));
        }

        [Test]
        public async Task Execute_InvalidInput_ReturnsBadRequest()
        {
            // Arrange
            var input = new CreateOrderInput(1, null); // Set up invalid input
            _mockCreateOrderUseCase.Setup(useCase => useCase.Execute(input))
                                   .ThrowsAsync(new ArgumentException("Invalid input"));

            // Act
            var result = await _controller.Execute(input);

            // Assert
            Assert.IsInstanceOf<BadRequest<string>>(result);
        }

    }
}