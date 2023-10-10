/*01/

Virtual method: có thể bị định nghĩa lại ở class con

- Dùng từ khóa "virtual" cho method ở class cha

vd: public virtual class Parent {}


- Dùng từ khóa override ở class con

vd: public "ovveride" cho method class Child {}
*/

Iphone iphone = new Iphone();
iphone.ShowInfo();


/*02/

Ý TƯỞNG BAN ĐẦU CỦA ABSTRACT:
- Tạo ra nhung class mà không để tạo ra các đối tượng mà chỉ để làm class cơ sở

- trong class abstract có thể khai báo một method abstract
*/

Cat c = new Cat();
c.ShowName();



/*03/

Ý TƯỞNG BAN ĐẦU CỦA INERFACE:
- Gần giống với abstract, khi khai báo sử dụng từ khóa interface

- Một class có thể kế thừa nhiều interface nhưng chỉ kế thừa 1 class

- Method trong interface luôn là abstract và bắc buột phải định nghĩa lại
*/

HinhChuNhat hcn = new HinhChuNhat(45.6, 56.4);
IHinhHoc hcn02 = new HinhChuNhat(45.6, 56.4); // Hai cách khai báo tương tự nhau
Console.WriteLine($"Dien tich hcn: {hcn.TinhDienTich()} - Chu vi hcn: {hcn.TinhChuVi()}");


//  01. Virtual method **************************************************************

public class Product
{
  public virtual void ShowInfo()
  {
    Console.WriteLine("Phuong thuc o class cha !!!");
  }
}

public class Iphone : Product
{
  public override void ShowInfo()
  {
    base.ShowInfo();
    Console.WriteLine("Phuong thuc o class con !!!");
  }
}


// 02. Abstract **************************************************************

public abstract class Animal // class Animal chỉ dùng để kế thừa
{
  // Không mở và đóng ngoặc nhọn vì method ShowName nay bị nạp chồng ở class cơ sở
  public abstract void ShowName();
}

public class Cat : Animal
{
  public override void ShowName()
  {
    Console.WriteLine("Method nap chong abstract");
  }
}


// 03. Inerface **************************************************************

interface IHinhHoc
{
  public double TinhDienTich();
  public double TinhChuVi();
}

interface IHinhHoc02 { }
interface IHinhHoc03 { }


// Một class có thể kế thừa nhiều interface
public class HinhChuNhat : IHinhHoc, IHinhHoc02, IHinhHoc03
{
  public double a;
  public double b;


  public HinhChuNhat(double a, double b)
  {
    this.a = a;
    this.b = b;
  }

  public double TinhChuVi()
  {
    return a + b;
  }

  public double TinhDienTich()
  {
    return a * b;
  }
}