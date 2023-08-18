using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entites;
using OrderManagement.UseCases.Products;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.Api.Controllers.Orders
{
    [ApiController]
    [Route("api/orders/getbyid")]
    public class GetOrderByIdController : ControllerBase
    {

        public GetOrderByIdController()
        {
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Execute(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}