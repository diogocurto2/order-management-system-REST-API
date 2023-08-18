using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public class CreateOrderInput
    {
        public CreateOrderInput(int customertId, List<CreateOrderItemInput> itens)
        {
            CustomertId = customertId;
            Itens = itens;
        }

        public int CustomertId { get; private set; }

        public List<CreateOrderItemInput> Itens { get; private set; }

    }
}
