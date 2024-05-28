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
        public static BaseRepository<Inventory> InventoryRepository { get; private set; }

        public App(            
            BaseRepository<User> userRep
            ,BaseRepository<Order> orderRep   
            ,BaseRepository<Product> productRep,
            BaseRepository<OrderItem> orderItemRep,
            BaseRepository<Inventory> inventoryRep
            )
        {
            InitializeComponent();
            SQLitePCL.Batteries_V2.Init();

            UserRepository = userRep;
            OrderRepository = orderRep;
            ProductRepository = productRep;
            OrderItemRepository = orderItemRep;
            InventoryRepository = inventoryRep;
            MainPage = new AppShell();
           
        }


    }
   

}
