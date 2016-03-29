using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }

        public Order(int customerId, string shippingAddress)
        {
            this.CustomerId = customerId;
            this.ShippingAddress = shippingAddress;
        }
    }
}
