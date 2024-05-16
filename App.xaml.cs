using Degree.MVVM.Models;
using Degree.MVVM.Views;
using Degree.Repositories;

namespace Degree
{
    public partial class App : Application
    {
        //public static CustomerRepository CustomerRepository { get; private set; }
        public static BaseRepository<Customer> CustomerRepository { get; private set; }
        public static BaseRepository<User> UserRepository { get; private set; }
        public static BaseRepository<Order> OrderRepository { get; private set; }
        
        public App(
            BaseRepository<Customer> customerRep,
            BaseRepository<User> userRep,
            BaseRepository<Order> orderRep            
            )
        {
            InitializeComponent();
            CustomerRepository = customerRep;
            UserRepository = userRep;
            OrderRepository = orderRep;
            MainPage = new AppShell();
        }


    }

}
