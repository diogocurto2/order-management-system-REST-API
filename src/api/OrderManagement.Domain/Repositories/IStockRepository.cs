using OrderManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Repositories
{
    public interface IStockRepository
    {
        Task Add(Stock stock);
        Task Update(Stock stock);
        Task<Stock> GetByIdAsync(int productId);
    }
}
