using OrderManagement.Domain.Entites;
using OrderManagement.Domain.Repositories;
using OrderManagement.UseCases.Orders.Dto;

namespace OrderManagement.UseCases.Orders
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public CreateOrderUseCase(
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreateOrderOutput> Execute(CreateOrderInput input)
        {
            Customer customer = await _customerRepository.GetByIdAsync(input.CustomertId);
            //if (customer == null)
            //{
            //    throw new ArgumentException(
            //        string.Format("CustomertId {0} does not exists", input.CustomertId)
            //        );
            //}

            var order = new Order(input.CustomertId);
            foreach (var item in input.Itens)
            {
                Product product = await _productRepository.GetByIdAsync(item.ProductId);
                //if (product == null)
                //{
                //    throw new ArgumentException(
                //        string.Format("ProductId {0} does not exists", item.ProductId)
                //        );
                //}

                order.AddOrderItem(product, item.Quantity);
            }

            var result = await _orderRepository.AddAsync(order);
            return new CreateOrderOutput(result);
        }
    }
}
