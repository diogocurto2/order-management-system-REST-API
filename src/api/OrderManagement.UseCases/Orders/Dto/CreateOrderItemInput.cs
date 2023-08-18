using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public class CreateOrderItemInput
    {
        public CreateOrderItemInput(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
    }
}
