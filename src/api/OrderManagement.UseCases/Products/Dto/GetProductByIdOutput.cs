using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Products.Dto
{
    public class GetProductByIdOutput
    {
        public GetProductByIdOutput(
            int productId,
            string productName,
            decimal productPrice,
            string productDescription,
            int productStockQuantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            ProductStockQuantity = productStockQuantity;
        }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }
        public string ProductDescription { get; private set; }
        public int ProductStockQuantity { get; private set; }
    }
}
