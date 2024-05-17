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

        public OrderPageViewModel()
        {
            Refresh();
            MessagingCenter.Subscribe<object>(this, "UsernameChanged", (sender) => {
                Refresh();
            });           
            
            CreateOrderCommand = new Command(OnCreateOrder);
            ViewOrderDetailsCommand = new Command(OnViewOrderDetails, () => IsOrderSelected);
                      
        }

        

        private async void OnCreateOrder()
        {
            Refresh();
            await Application.Current.MainPage.DisplayAlert("Error", Preferences.Get("Username", "NULL"), "OK");
            // Navigate to a page where the user can create a new order
            await Application.Current.MainPage.Navigation.PushAsync(new CreateOrderPage());
        }

        private async void OnViewOrderDetails()
        {
            if (SelectedOrder == null) return;

            // Navigate to a page showing the order details
            //await Application.Current.MainPage.Navigation.PushAsync(new OrderDetailsPage(SelectedOrder));
        }

        private void Refresh()
        {
            IsLoggedIn = Preferences.Get("IsLoggedIn", false);
            CurrentUser = App.UserRepository.GetItem(x => x.Username == Preferences.Get("Username", "NULL"));
            Orders = App.OrderRepository.GetItems(/*x => x.UserId == CurrentUser.Id*/);  
        }
    }
}
