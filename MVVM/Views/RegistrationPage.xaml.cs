using Degree.MVVM.ViewsModels;

namespace Degree.MVVM.Views;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
		BindingContext = new RegistrationPageViewModel();
	}
}