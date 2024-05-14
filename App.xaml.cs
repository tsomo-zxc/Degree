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
        public App(BaseRepository<Customer> customerRep, BaseRepository<User> userRep)
        {
            InitializeComponent();
            CustomerRepository = customerRep;
            UserRepository = userRep;

            MainPage = new AppShell();
        }
    }
}
