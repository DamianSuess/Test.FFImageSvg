using Prism.Commands;
using Prism.Navigation;

namespace Test.FFImageSvg.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      Title = "Main Page";
    }

    public string Source => "resource://Test.FFImageSvg.Resources.sample.svg";

    public DelegateCommand CmdClicked => new DelegateCommand(OnClicked);

    private void OnClicked()
    {
      DisplayAlert("Clicked", "Yay Clicked it");
    }
  }
}
