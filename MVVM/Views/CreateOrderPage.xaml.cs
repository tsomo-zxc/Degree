using Degree.MVVM.Models;
using Degree.MVVM.ViewsModels;
namespace Degree.MVVM.Views;

public partial class CreateOrderPage : ContentPage
{
	public CreateOrderPage(User currUser)
	{
		InitializeComponent();
        BindingContext = new CreateOrderViewModel(currUser);
    }
  
}