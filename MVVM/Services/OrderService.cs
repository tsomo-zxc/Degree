using Degree.MVVM.Abstractions;
using Degree.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.Services
{
    public class OrderService : IOrderService
    {
        public List<Order> GetAllOrders()
        {
            // Retrieve orders from the database
            return App.OrderRepository.GetItems();
        }

        public void CreateOrder(Order order)
        {
            // Save order to the database
            App.OrderRepository.SaveItem(order);
        }
    }
}
