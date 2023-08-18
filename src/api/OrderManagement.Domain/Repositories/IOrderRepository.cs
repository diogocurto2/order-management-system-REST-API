using OrderManagement.Domain.Entites;

namespace OrderManagement.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task<int> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int orderId);
    }
}
