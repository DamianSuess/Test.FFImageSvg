using System.Collections.Generic;
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

      OnColorBlack();
    }

    public string Source => "resource://Test.FFImageSvg.Resources.sample.svg";

    public DelegateCommand CmdClicked => new DelegateCommand(OnClicked);

    public DelegateCommand CmdColorBlack => new DelegateCommand(OnColorBlack);

    public DelegateCommand CmdColorRed => new DelegateCommand(OnColorRed);

    public Dictionary<string, string> SvgColorMap { get; set; }

    private void OnColorBlack()
    {
      string oldColorHex = "#FF0000";
      string newColorHex = "#1D1D1D";

      SvgColorMap = GetReplacementStringMap(oldColorHex, newColorHex);
      RaisePropertyChanged(nameof(SvgColorMap));
    }

    private void OnColorRed()
    {
      string oldColorHex = "#1D1D1D";
      string newColorHex = "#FF0000";

      SvgColorMap = GetReplacementStringMap(oldColorHex, newColorHex);
      RaisePropertyChanged(nameof(SvgColorMap));
    }

    private void OnClicked()
    {
      DisplayAlert("Clicked", "Yay Clicked it");
    }

    /// <summary>SVG ReplacementStringMap used to change our Path's fill color.</summary>
    /// <param name="oldColorHex">Old hex color.</param>
    /// <param name="newColorHex">New hex color.</param>
    /// <returns></returns>
    private Dictionary<string, string> GetReplacementStringMap(string oldColorHex, string newColorHex)
    {
      // NOTE:
      // The dictionary 'key' is the string to search and 'value' is our replacement in our SVG
      // Here, our SVG's "<path ... fill="#1D1D1D" />" is what is being replaced.
      var replaceStringMap = new Dictionary<string, string>
      {
        { $"fill=\"{oldColorHex}\"", $"fill=\"{newColorHex}\""}
      };

      return replaceStringMap;
    }
  }
}
