using Degree.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.ViewsModels
{
    public class ShowenItem 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity  { get; set; }
        public decimal TotalPrice { get; set; }
        public ShowenItem(string name,decimal price,int quantity) {
        
        Name= name; Price = price; Quantity = quantity; TotalPrice = price * Quantity;
        } 
    }

    [AddINotifyPropertyChangedInterface]
    public class OrderDetailsPageViewModel
    {
        public Order CurrentOrder { get; set; }
        public List<Product> Products { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<ShowenItem> ShowenItems { get; set; }
        ShowenItem i { get; set; }  
        public OrderDetailsPageViewModel(Order selectedOrder) 
        {
            CurrentOrder = selectedOrder;
            Items = new List<OrderItem>();
            Items = App.OrderItemRepository.GetItems(x => x.OrderId == CurrentOrder.Id );
            ShowenItems = new List<ShowenItem>();
            
            foreach (var item in Items)
            {
                var name = App.ProductRepository.GetItem(x => x.Name == item.ProductName).Name;
                var price = App.ProductRepository.GetItem(x => x.Name == item.ProductName).Price;
                var i = new ShowenItem(name, price, item.Quantity);
                ShowenItems.Add(i);
            }
            

        }

    }
}
