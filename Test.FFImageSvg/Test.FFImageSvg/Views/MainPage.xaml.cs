using Test.FFImageSvg.ViewModels;
using Xamarin.Forms;

namespace Test.FFImageSvg.Views
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

      MessagingCenter.Subscribe<ViewModelBase, string[]>(this, "DisplayAlert", (sender, values) =>
      {
        DisplayAlert(values[0], values[1], "Ok");
      });
    }
  }
}