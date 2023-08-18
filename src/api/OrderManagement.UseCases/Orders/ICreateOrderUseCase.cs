using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.Orders
{
    public interface ICreateOrderUseCase
    {
        Task<CreateOrderOutput> Execute(CreateOrderInput input);
    }
}