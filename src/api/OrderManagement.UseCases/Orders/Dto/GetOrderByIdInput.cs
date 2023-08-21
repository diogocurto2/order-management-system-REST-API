using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public class GetOrderByIdInput
    {
        public GetOrderByIdInput(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; private set; }
    }
}
