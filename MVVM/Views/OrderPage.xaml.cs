using Degree.MVVM.ViewsModels;

namespace Degree.MVVM.Views;

public partial class OrderPage : ContentPage
{
	public OrderPage()
	{
		InitializeComponent();
		BindingContext =  new OrderPageViewModel();
	}
}