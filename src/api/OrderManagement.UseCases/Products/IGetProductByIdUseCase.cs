using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.UseCases.Orders.Dto;
using OrderManagement.UseCases.Products.Dto;

namespace OrderManagement.UseCases.Products
{
    public interface IGetProductByIdUseCase
    {
        Task<GetProductByIdOutput> Execute(GetProductByIdInput input);
    }
}
