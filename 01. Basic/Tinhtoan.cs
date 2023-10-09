using System;

namespace Abc {
  public class Tinhtoan {
    public static int tong(int a, int b)
    {
      return a + b;
    }

    public static int tich(int a, int b = 7)
    {
      return a * b;
    }

    public static int binhPhuong(ref int x)
    {
      x = x * x;
      return x;
    }

    public static int binhPhuong02(ref int x, out int result)
    {
      x = x * x;
      result = x;
      return x;
    }
  }
}
