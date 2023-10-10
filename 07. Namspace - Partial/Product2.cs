namespace SanPham
{
  /*
  partial: owr file product2.cs class Product cũng là một phần của class Prodcut ở file product1.cs
  - Việc chia nhỏ đê dễ dàng quản lí file
  */
  public partial class Product
  {
    public Manufactory manufactory { get; set; }
    public class Manufactory
    {
      public string name;
      public string year;
    }


    public string description { set; get; }
  }
}