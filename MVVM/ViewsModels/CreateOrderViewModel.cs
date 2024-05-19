using Degree.MVVM.Models;

using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Degree.MVVM.ViewsModels
{

    public class AProduct {
        public Product Product { get; set; }
        public int Quantity { get; set; }


    }


    [AddINotifyPropertyChangedInterface]
    public class CreateOrderViewModel
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }
        public Dictionary<Product,int> AddedProducts { get; set; }
        public List<AProduct> AProducts { get; set; }        
        public List<OrderItem> OrderItems { get; set; }        
        public User CurrentUser { get; set; }
        public Product SelectedProduct { get; set; }
        public int Quantity { get; set; }
       

        public CreateOrderViewModel(User currUser)
        {
            CurrentUser = currUser;            
            Order = new Order();
            Order.OrderDate = DateTime.Now;
            Order.Status = OrderStatus.Pending;
            Products = App.ProductRepository.GetItems();
            SelectedProduct = Products[0];
            AProducts = new List<AProduct>();
            
            AddedProducts = new Dictionary<Product, int>();   
            foreach (Product product in Products)
            {
                AddedProducts[product] = 0;
            }
         
            AddProductCommand = new Command(AddProduct);
            AddOrderCommand = new Command(AddOrder);
            
            
        }

        public ICommand AddProductCommand { get; }
        public ICommand AddOrderCommand { get; }

     
        private void AddProduct()
        {   
            if(AddedProducts.ContainsKey(SelectedProduct))
            AddedProducts[SelectedProduct] += Quantity;
            else
            AddedProducts.Add(SelectedProduct, Quantity);
            Refresh();
        }
        private async void AddOrder() 
        { 
            OrderItems=new List<OrderItem>();
            Order.UserId = CurrentUser.Id;
            Order.TotalAmount = AddedProducts.Values.Sum();

            foreach (var item in AddedProducts)
            {
                OrderItem i = new OrderItem
                {
                    OrderId = Order.Id,
                    ProductId = item.Key.Id,
                    Quantity = item.Value
                   
                };
                OrderItems.Add(i);
            }
            Order.OrderItems= OrderItems;
            App.OrderRepository.SaveItemWithChildren(Order);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private void Refresh()
        {
            var test = new List<AProduct>();
            
            foreach (var item in AddedProducts)
            {
                if (item.Value != 0)
                {
                   test.Add(new AProduct { Product = item.Key,Quantity= item.Value});   
                }
            }
            AProducts = test;
        }

        
    }
}
