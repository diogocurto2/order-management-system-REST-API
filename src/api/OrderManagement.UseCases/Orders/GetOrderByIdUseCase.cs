using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.Orders
{
    public class GetOrderByIdUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderOutput> Execute(GetOrderByIdInput input)
        {
            var order = await _orderRepository.GetByIdAsync(input.OrderId);

            if (order == null)
            {
                throw new NotFoundException($"Order with ID {input.OrderId} not found.");
            }

            var outputDTO = OrderConverter.ToOutputDTO(order);

            return outputDTO;
        }
    }
}
