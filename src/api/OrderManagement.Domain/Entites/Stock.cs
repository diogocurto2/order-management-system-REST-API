using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entites
{
    public class Stock
    {
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }

        // Navigation property
        public Product Product { get; private set; }

        // Private constructor for EF
        private Stock() { }

        public Stock(int productId)
        { 
            ProductId = productId;
        }
    }
}
