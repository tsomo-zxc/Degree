using Degree.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Degree.MVVM.ViewsModels
{
    [AddINotifyPropertyChangedInterface]
    public class CreateOrderViewModel
    {
        public Order Order { get; set; }
        public List<Product> Products { get; set; }

        public CreateOrderViewModel()
        {
            Order = new Order();
            Products = new List<Product>();
        }

    }
}
