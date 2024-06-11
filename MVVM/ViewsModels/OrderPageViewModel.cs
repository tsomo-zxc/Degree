using Degree.MVVM.Abstractions;
using Degree.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Degree.MVVM.Views;

namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class OrderPageViewModel : UserViewModel
    {
       
        public List<Order> Orders { get; set; }       
        public Order _selectedOrder;
        public User CurrentUser { get; set; }
       
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
            }
        }

        public bool IsOrderSelected => SelectedOrder != null;

        public ICommand CreateOrderCommand { get; }
        public ICommand ViewOrderDetailsCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand AcceptOrderCommand { get; }

        public OrderPageViewModel()
        {
            Refresh();
            MessagingCenter.Subscribe<object>(this, "UsernameChanged", (sender) => {
                Refresh();
            });           
            
            CreateOrderCommand = new Command(OnCreateOrder);
            RefreshCommand = new Command(OnRefresh);
            ViewOrderDetailsCommand = new Command(OnViewOrderDetails, () => IsOrderSelected);
            AcceptOrderCommand = new Command(OnAcceptOrder, () => IsOrderSelected);
                      
        }


        private async void OnAcceptOrder()
        {
            if (SelectedOrder == null) return;

            if (SelectedOrder.Status == OrderStatus.InProgress)
            {
                List<OrderItem> orderItems=App.OrderItemRepository.GetItems(x => x.OrderId == SelectedOrder.Id);
                List<Inventory> inventory = App.InventoryRepository.GetItems(x => x.UserId == SelectedOrder.UserId);

                foreach (var item in orderItems)
                {

                    if (inventory.Find(x => x.ProductName == item.ProductName) == null)
                    {
                        App.InventoryRepository.SaveItem(new Inventory { ProductName = item.ProductName, Quantity = item.Quantity, UserId = CurrentUser.Id });
                    }
                    else
                    {
                       Inventory curr = App.InventoryRepository.GetItem(x => x.ProductName == item.ProductName);
                       curr.Quantity += item.Quantity;
                       App.InventoryRepository.SaveItem(curr);
                    }
                }
                SelectedOrder.Status = OrderStatus.Completed;
                App.OrderRepository.SaveItem(SelectedOrder);
                Refresh();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Mistake", "You can accept only Orders in progress", "OK");
            }
        }
        private async void OnCreateOrder()
        {
            Refresh();
            // Navigate to a page where the user can create a new order
           
            await Application.Current.MainPage.Navigation.PushAsync(new CreateOrderPage(CurrentUser));
            Refresh();
        }
        private async void OnRefresh()
        {
            Refresh();
        }
        private async void OnViewOrderDetails()
        {
            if (SelectedOrder == null) return;

            // Navigate to a page showing the order details
            await Application.Current.MainPage.Navigation.PushAsync(new OrderDetailsPage(SelectedOrder));
        }

        private void Refresh()
        {
            IsLoggedIn = Preferences.Get("IsLoggedIn", false);
            var username = Preferences.Get("Username", "NULL");
            CurrentUser = App.UserRepository.GetItem(x => x.Username==username);            
            var orders = App.OrderRepository.GetItems(x => x.UserId == CurrentUser.Id);
            Orders = orders.OrderByDescending(x => x.Id).ToList();
            
        }
    }
}
