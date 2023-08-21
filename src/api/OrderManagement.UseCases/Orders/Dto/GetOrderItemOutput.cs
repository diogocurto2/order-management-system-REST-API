﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public class GetOrderItemOutput
    {
        public GetOrderItemOutput(
            int productId, 
            int quantity,
            decimal price
        )
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
