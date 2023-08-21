using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.UseCases.Orders.Dto
{
    public class GetOrderOutput
    {
        public GetOrderOutput(
            int orderId,
            int customertId,
            DateTime date,
            decimal totalValue,
            List<GetOrderItemOutput> itens)
        {
            OrdertId = orderId;
            CustomertId = customertId;
            Date = date;
            TotalValue = totalValue;
            Items = itens;
        }

        public int OrdertId { get; private set; }

        public int CustomertId { get; private set; }

        public DateTime Date { get; private set; }

        public decimal TotalValue{ get; private set; }

        public List<GetOrderItemOutput> Items { get; private set; }
    }
}
