using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entites;
using OrderManagement.UseCases.Orders;
using OrderManagement.UseCases.Orders.Dto;
using System.Net.Mime;

namespace OrderManagement.Api.Controllers.Orders
{
    [ApiController]
    [Route("api/orders/create")]
    public class CreateOrderController : ControllerBase
    {
        private readonly ICreateOrderUseCase _createOrderUseCase;

        public CreateOrderController(ICreateOrderUseCase createOrderUseCase)
        {
            _createOrderUseCase = createOrderUseCase;
        }

        /// <summary>
        /// Use this function to create a Order with customer id, and a list with product id and quantity.
        /// </summary>
        /// <param name="input">
        /// For this example, pass data like the example.
        /// </param>
        /// <returns code="200">
        /// Returns Bearer when user and password is valid
        /// </returns>
        /// <return code="400">
        /// Returns code 400 when parameters is null, or customer id, product id is inavlid.
        /// </return>
        /// <returns code="401">
        /// Returns 401 when user is not authorized.
        /// </returns>
        [Authorize]
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateOrderOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IResult> Execute(CreateOrderInput input)
        {
            try
            {
                var result = await _createOrderUseCase.Execute(input);

                var location = Url.Action(nameof(GetOrderByIdController.Execute), new { id = result.OrderId });
                return Results.Created(location, result);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}