using Degree.MVVM.Models;
using Degree.MVVM.ViewsModels;

namespace Degree.MVVM.Views;

public partial class OrderDetailsPage : ContentPage
{
	public OrderDetailsPage(Order selectedOrder)
	{
		InitializeComponent();
		BindingContext = new OrderDetailsPageViewModel(selectedOrder);

    }
}