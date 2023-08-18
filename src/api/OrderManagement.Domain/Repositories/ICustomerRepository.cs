using OrderManagement.Domain.Entites;

namespace OrderManagement.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int customerId);
        Task<List<Customer>> GetAllAsync();
        Task<int> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int customerId);
    }
}
