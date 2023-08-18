using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infra.Data;
using System.Data;

namespace OrderManagement.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagementDbContext _dbContext;

        private const string STOREDPROCEDURE_CREATE_NAME = "[dbo].[sp_custom_CreateNewOrder]";
        private const string STOREDPROCEDURE_PARAM_CUSTOMERID = "@CustomerID";
        private const string STOREDPROCEDURE_PARAM_ORDERID = "@OrderID";
        private const string STOREDPROCEDURE_PARAM_ORDERITEMS = "@OrderItems";
        private const string STOREDPROCEDURE_PARAM_ORDERITEMS_TYPENAME = "[dbo].[ProductOrderItem]";

        public OrderRepository(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _dbContext.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<int> AddAsync(Order order)
        {
            var customerIdParameter = new SqlParameter()
            {
                ParameterName = STOREDPROCEDURE_PARAM_CUSTOMERID,
                Direction = ParameterDirection.Input,
                SqlValue = order.CustomerId,
            };

            var productOrderItemItensRecord = new List<SqlDataRecord>();
            var productOrderItemMetaData = new SqlMetaData[]
            {
                new SqlMetaData("ProductID", SqlDbType.Int),
                new SqlMetaData("Quantity", SqlDbType.Int)
            };
            foreach (var oi in order.Items)
            {
                var productOrderItemRecord = new SqlDataRecord(productOrderItemMetaData);
                productOrderItemRecord.SetInt32(0, oi.ProductId);
                productOrderItemRecord.SetInt32(1, oi.Quantity);
                productOrderItemItensRecord.Add(productOrderItemRecord);
            }
            var orderItemsParameter = new SqlParameter() {
                SqlDbType = SqlDbType.Structured,
                TypeName = STOREDPROCEDURE_PARAM_ORDERITEMS_TYPENAME,
                ParameterName = STOREDPROCEDURE_PARAM_ORDERITEMS,
                Direction = ParameterDirection.Input,
                Value = productOrderItemItensRecord.ToArray()
            };

            var returnParameter = new SqlParameter()
            {
                ParameterName = STOREDPROCEDURE_PARAM_ORDERID,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output,
            };

            var paramList = new List<SqlParameter>() {
                customerIdParameter,
                orderItemsParameter,
                returnParameter
            };

            var commandText =
                string.Format("{0} {1}, {2}, {3} OUTPUT",
                    STOREDPROCEDURE_CREATE_NAME,
                    STOREDPROCEDURE_PARAM_CUSTOMERID,
                    STOREDPROCEDURE_PARAM_ORDERITEMS,
                    STOREDPROCEDURE_PARAM_ORDERID);

            var result = await _dbContext.Database
                    .ExecuteSqlRawAsync(commandText, paramList.ToArray());

            if (result > 0)
                return (int)(returnParameter.Value);
            else
                throw new Exception(STOREDPROCEDURE_CREATE_NAME + " execution error.");
        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
