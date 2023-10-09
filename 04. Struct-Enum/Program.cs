using System;

namespace StructEnum
{
  class Program
  {

    public struct Product
    {
      public string name;
      public int price;

      // constructor 
      public Product(string _name, int _price)
      {
        this.name = _name;
        this.price = _price;
      }

      // Phương thức
      public string GetInfo()
      {
        return $"Ten SP: {this.name}, gia SP: {this.price}";
      }

      // Atribute
      public string Info
      {
        get
        {
          return $"{this.name}";
        }
      }
    }

    enum HOCLUC
    {
      yeu = 33,
      trungbinh = 44,
      kha = 55,
      gioi = 66
    }

    static void Main(string[] args)
    {

      /*
      - Struct là kiểu dữ liệu 
      - KHai báo struct tương tự như class như là tham trị thay vì tham chiếu
      - giá trị được luu vào bộ nhớ stack
      
      */
      Product sanpham1;
      Product sanpham2;

      sanpham1.name = "Samsung";
      sanpham1.price = 1000;

      sanpham2 = sanpham1;

      sanpham2.name = "Nokia";
      sanpham2.price = 2300;

      Console.WriteLine(sanpham1.GetInfo());
      Console.WriteLine(sanpham2.GetInfo());


      /*
      Enum:
      - Kiểu dữ liệu gợi nhớ
      - Hình thức dữ liệu liệt kê
      */
      HOCLUC hocluc = HOCLUC.kha;

      // Chuyển enum sang sô
      int number = (int)HOCLUC.kha;

      // Chuyển số sang enum
      var kiemtra = (HOCLUC)(44);
      Console.WriteLine(number);
      Console.WriteLine(kiemtra);

      switch (hocluc)
      {
        case HOCLUC.yeu:
          Console.WriteLine("Hoc luc yeu");
          break;
        case HOCLUC.trungbinh:
          Console.WriteLine("Hoc luc trung binh");
          break;
        case HOCLUC.kha:
          Console.WriteLine("Hoc luc kha");
          break;
        case HOCLUC.gioi:
          Console.WriteLine("Hoc luc gioi");
          break;
        default:
          Console.WriteLine("Không đủ thông tin");
          break;
      }
    }
  }
}




