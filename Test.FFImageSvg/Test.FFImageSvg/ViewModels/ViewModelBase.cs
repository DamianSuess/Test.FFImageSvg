using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Test.FFImageSvg.ViewModels
{
  public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
  {
    private string _title;

    public ViewModelBase(INavigationService navigationService)
    {
      NavigationService = navigationService;
    }

    public string Title
    {
      get { return _title; }
      set { SetProperty(ref _title, value); }
    }

    protected INavigationService NavigationService { get; private set; }

    public virtual void Initialize(INavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    public virtual void Destroy()
    {
    }

    public void DisplayAlert(string title, string message)
    {
      string[] values = { title, message };
      MessagingCenter.Send<ViewModelBase, string[]>(this, "DisplayAlert", values);
    }
  }
}
