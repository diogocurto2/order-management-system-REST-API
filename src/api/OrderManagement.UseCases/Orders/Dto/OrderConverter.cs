using OrderManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public static class OrderConverter
    {
        public static GetOrderOutput ToOutputDTO(Order order)
        {
            var outputDTO = new GetOrderOutput
            (
                order.Id,
                order.CustomerId,
                order.Date,
                order.TotalCost,
                order.Items.Select(orderItem => ToOrderItemDTO(orderItem)).ToList()
            );

            return outputDTO;
        }

        private static GetOrderItemOutput ToOrderItemDTO(OrderItem orderItem)
        {
            return new GetOrderItemOutput
            (
                orderItem.ProductId,
                orderItem.Quantity,
                orderItem.Cost
            );
        }
    }
}
