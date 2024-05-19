using Degree.MVVM.Models;
using Degree.MVVM.Views;
using Degree.Repositories;

namespace Degree
{
    public partial class App : Application
    {
       
        public static BaseRepository<User> UserRepository { get; private set; }
        public static BaseRepository<Order> OrderRepository { get; private set; }
        public static BaseRepository<Product> ProductRepository { get; private set; }
        public static BaseRepository<OrderItem> OrderItemRepository { get; private set; }

        public App(            
            BaseRepository<User> userRep
            ,BaseRepository<Order> orderRep   
            , BaseRepository<Product> productRep,
            BaseRepository<OrderItem> orderItemRep
            )
        {
            InitializeComponent();
          
            UserRepository = userRep;
            OrderRepository = orderRep;
            ProductRepository = productRep;
            OrderItemRepository = orderItemRep;
            MainPage = new AppShell();
           
        }


    }
   

}
