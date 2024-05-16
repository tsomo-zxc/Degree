using Degree.MVVM.ViewsModels;

namespace Degree.MVVM.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = new ProfilePageViewModel();
    }
      
}