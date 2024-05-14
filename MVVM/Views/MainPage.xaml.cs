using Degree.MVVM.ViewsModels;

namespace Degree.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		//InitializeComponent();
		BindingContext = new MainPageViewModel();
	}
}