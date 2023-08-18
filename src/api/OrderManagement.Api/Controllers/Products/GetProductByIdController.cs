using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Entites;
using OrderManagement.UseCases.Products;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.Api.Controllers.Products
{
    [ApiController]
    [Route("api/products/getbyid")]
    public class GetProductByIdController : ControllerBase
    {
        private readonly IGetProductByIdUseCase _getProductByIdUseCase;

        public GetProductByIdController(IGetProductByIdUseCase getProductByIdUseCase)
        {
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        /// <summary>
        /// Get product data by Id.
        /// </summary>
        /// <param name="productId">
        /// Id of product
        /// </param>
        /// <response code="200">
        /// When productId parameter is valid, the system returns a type With product data.
        /// </response>
        /// <response code="404">
        /// Retorns 404 when productId parameter is not found.
        /// </response>
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductByIdOutput))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Execute(int productId)
        {
            try
            {
                var product = await _getProductByIdUseCase.Execute(new GetProductByIdInput(productId));
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
        }
    }
}