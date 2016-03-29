using KMS.UnitTestTraining.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.UnitTestTraining.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrderById(int id);
        IList<Order> GetAll();
        Order Insert(Order order);
        void Update(Order order);
    }
}
