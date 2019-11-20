using System;

namespace Test.FFImageSvg
{
  public static class Helpers
  {
    public static string GetImageUrl(int key, int width = 600, int height = 600)
    {
      return $"https://loremflickr.com/{width}/{height}/nature?random={key}";
    }

    public static string GetRandomImageUrl(int width = 600, int height = 600)
    {
      return $"https://loremflickr.com/{width}/{height}/nature?random={Guid.NewGuid()}";
    }
  }
}