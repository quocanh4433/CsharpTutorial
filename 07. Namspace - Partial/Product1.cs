namespace SanPham
{
  public partial class Product
  {
    public string name { set; get; }
    public decimal price { set; get; }

    public void GetInfo()
    {
      Console.WriteLine($"Ten SP: {this.name}. Gia SP: {this.price}. Mo ta: {this.description}");
    }
  }
}