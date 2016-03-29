using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;

namespace KMS.UnitTestTraining.Services
{
    class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        IOrderItemRepository orderItemRepository;
        IProductRepository productRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.productRepository = productRepository;
        }

        public void AddNewOrder(int customerId, string shippingAddress, IDictionary<int, int> product)
        {
            if(customerId <= 0)
            {
                throw new ArgumentException("customerId");
            }
            if(string.IsNullOrEmpty(shippingAddress))
            {
                throw new ArgumentNullException("shippingAddress");
            }
            //TODO: may an order has no product?
            if(product == null || product.Count == 0)
            {
                throw new ArgumentNullException("product");
            }

            Order order = new Order(customerId, shippingAddress);
            orderRepository.Insert(order);

            foreach (var item in product)
            {
                OrderItem orderItem = new OrderItem(order.OrderId, item.Key, item.Value);
                orderItemRepository.Insert(orderItem);
            }
            
        }

        public void UpdateProductQuantity(int orderId, int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProductByOrderId(int orderId)
        {
            Order other = orderRepository.GetOrderById(orderId);
            IList<Product> products = 

            throw new NotImplementedException();
        }

        public decimal CalculateFinalPrice(int orderId)
        {
            throw new NotImplementedException();
        }

        
    }
}
