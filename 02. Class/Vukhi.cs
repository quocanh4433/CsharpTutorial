/*
<Access Modifiers> class Class_Name {................}

- <Access Modifiers>: public, internal
- Mặc định: internal
*/

public class VuKhi : IDisposable
{


  // 01. DU LIEU
  // Khai bao du lieu:  <Access Modifiers> keiuDuLieu tenDuLieu
  // <Access Modifiers>: public, private, internal, protectad internal, private protected
  // mặc định: private chỉ truy cap ben trong class

  public string name;
  private string secret = "Bien nay chi duoc try cap tu ben trong class";
  int doSatThuong;

  // 02. PHUONG THUC KHOI TAO
  // Khai báo phương thức mặc định
  // Phương thức này chạy đâu tiên khi đối đượng được khởi tạo
  // Tên phương thức khởi tạo phải cùng tên với tên class
  public VuKhi()
  {
    Console.WriteLine($"KHOITAO Vu khi: {name}, Do sat thuong: {doSatThuong}");
  }

  public VuKhi(string name, int doSatThuong)
  {
    this.name = name;
    this.doSatThuong = doSatThuong;
    Console.WriteLine($"KHOITAO Vu khi: {name}, Do sat thuong: {doSatThuong}");
  }

  // 03. THUOC TINH
  public int SatThuong
  {
    // phep gan
    set
    {
      doSatThuong = value;
    }
    // truy cap
    get
    {
      return doSatThuong;
    }
  }




  // 04. PHUONG THUC
  public void ThietLapDoSatThuong(int doSatThuong)
  {
    // this.doSatThuong: của class
    // doSatThuong: tham so truyen vao cua phuong thuc ThietLapDoSatThuong

    // this là từ khóa tham chiêu đến đối tượng class
    this.doSatThuong = doSatThuong;
  }

  public void TanCong()
  {
    Console.Write(name + ":\t"); // \t: tab
    for (int i = 0; i < doSatThuong; i++)
    {
      Console.Write("* ");
    }
    Console.WriteLine("");
  }

  // 05. PHUONG THUC HUY
  ~VuKhi()
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Huy" + name);
    Console.ResetColor();

    // Gc.collect() Thu hôi tât cả đổi thượng không có tham chiếu ngay lặp tức trên dotnet frame work
    // Trên dotnet core sẽ thu hồi khi nào cân thêm bộ nhớ
    // GC.Collect();
  }

  public void Dispose()
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Huy giai phong tai nguyen boi Dispo" + name);
    Console.ResetColor();

  }
}

