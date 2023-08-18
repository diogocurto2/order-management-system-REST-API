using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infra.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly OrderManagementDbContext _dbContext;

        public StockRepository(OrderManagementDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Add(Stock stock)
        {
            _dbContext.Stocks.Add(stock);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Stock stock)
        {
            _dbContext.Entry(stock).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Stock> GetByIdAsync(int productId)
        {
            return await _dbContext.Stocks.FindAsync(productId);
        }
    }
}
