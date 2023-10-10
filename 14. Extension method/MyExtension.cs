using System;

namespace MyExtension
{
  public static class Extension
  {
    public static double BinhPhuong(this double x) => x * x;
    public static double CanBacHai(this double x) => Math.Sqrt(x);
    public static double Sin(this double x) => Math.Sin(x);
  }
}
