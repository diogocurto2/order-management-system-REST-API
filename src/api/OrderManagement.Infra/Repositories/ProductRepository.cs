using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infra.Data;

namespace ProductManagement.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderManagementDbContext _dbContext;

        public ProductRepository(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<int> AddAsync(Product product)
        {
            _dbContext.Products.Add(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
