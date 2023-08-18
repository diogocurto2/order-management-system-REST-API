using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Products.Dto
{
    public class GetProductByIdInput
    {
        public GetProductByIdInput(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; private set; }
    }
}
