﻿using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading;
using FFImageLoading.Forms.Platform;
using Prism;
using Prism.Ioc;

namespace Test.FFImageSvg.Droid
{
  [Activity(Label = "Test FFImageSvg",
            Icon = "@mipmap/ic_launcher",
            Theme = "@style/MainTheme",
            MainLauncher = true,
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

      var config = new FFImageLoading.Config.Configuration()
      {
        VerboseLogging = false,
        VerbosePerformanceLogging = false,
        VerboseMemoryCacheLogging = false,
        VerboseLoadingCancelledLogging = false,
        Logger = new CustomLogger(),
      };
      ImageService.Instance.Initialize(config);

      global::Xamarin.Forms.Forms.Init(this, bundle);

      CachedImageRenderer.Init(true);
      CachedImageRenderer.InitImageViewHandler();

      LoadApplication(new App(new DroidInitializer()));
    }

    public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
    {
      public void Debug(string message)
      {
        Console.WriteLine(message);
      }

      public void Error(string errorMessage)
      {
        Console.WriteLine(errorMessage);
      }

      public void Error(string errorMessage, Exception ex)
      {
        Error(errorMessage + System.Environment.NewLine + ex.ToString());
      }
    }
  }

  public class DroidInitializer : IPlatformInitializer
  {
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // Register any platform specific implementations
    }
  }
}
