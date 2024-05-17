using Degree.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Abstractions
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        void CreateOrder(Order order);
        // Additional methods as needed
    }
}
