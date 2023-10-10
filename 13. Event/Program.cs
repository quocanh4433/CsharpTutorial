/*
Lập trình hướng sự kiện là tạo ra

publisher -> class -> phát sự kiện

subsriber -> class -> nhận sự kiện
*/
Console.CancelKeyPress += (sender, e) =>
{
  Console.WriteLine("");
  Console.WriteLine("Thoat ung dung");
};

UserInput userInput = new UserInput();

userInput.sukiennhapso += (sender, e) =>
{
  DuLieuNhap dulieunhap = (DuLieuNhap)e;
  Console.WriteLine("Ban vua nhap so" + dulieunhap.data);
};

TinhCan tinhcan = new TinhCan();
tinhcan.Sub(userInput); // Để đăng ký tính căn khi người dụng nhập giá trị


TinhBinhPhuong tinhBinhPhuong = new TinhBinhPhuong();
tinhBinhPhuong.Sub(userInput);

userInput.Input();





//*********************************************

public delegate void SuKienNhapSo(int x);


class DuLieuNhap : EventArgs
{
  public int data { set; get; }
  public DuLieuNhap(int x) => data = x;
}



// Publisher: class phát đi sự kiên
class UserInput
{
  // public event SuKienNhapSo sukiennhapso;


  // ~ delegate void KIEU(object? sender, EventArgs args)
  public event EventHandler sukiennhapso;


  public void Input()
  {
    do
    {
      Console.WriteLine("Nhập vào số nguyên: ");
      string s = Console.ReadLine();
      int i = Int32.Parse(s);
      // sukiennhapso?.Invoke(i);
      sukiennhapso?.Invoke(this, new DuLieuNhap(i));
    } while (true);
  }
}


// Subriber: class nhận sự kiện
class TinhCan
{
  public void Sub(UserInput input)
  {
    input.sukiennhapso += Can;
  }
  // public void Can(int i)
  // {
  //   Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
  // }

  public void Can(object? sender, EventArgs e)
  {
    DuLieuNhap duLieuNhap = (DuLieuNhap)e;
    int i = duLieuNhap.data;
    Console.WriteLine($"Can bac hai cua {i} la {Math.Sqrt(i)}");
  }
}

class TinhBinhPhuong
{
  public void Sub(UserInput input)
  {
    input.sukiennhapso += BinhPhuong;
  }
  public void BinhPhuong(object? sender, EventArgs e)
  {
    DuLieuNhap duLieuNhap = (DuLieuNhap)e;
    int i = duLieuNhap.data;
    Console.WriteLine($"Binh phuong cua {i} la {i * i}");
  }
}