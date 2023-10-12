/* 01.
static: khai báo thành viên tĩnh của class

- đã là thành viên tĩnh không thuộc object của class mà có thể truy cập thông qua tên class

- từ khóa static phải xuất hiện trong phương thức

*/


CountNumber c1 = new CountNumber();
CountNumber c2 = new CountNumber();

// Lúc này đối tượng c1 và c2 cùng chia sẽ biễn tính number ở class Countnumber

c1.Count();
c2.Count();

CountNumber.Info(); // number = 2


// c1.time = "1 nam"; // ERROR: truong time chỉ để đọc dữ liệu





/* 02 Quá tải toán tử

- Đinh nghi những phép toán cụ thể

*/


Vector v1 = new Vector(2, 3);
Vector v2 = new Vector(5, 7);

v1.Info();


// C# không hổ trơ tính tổng giưa 2 vector nên phải tự định nghia (gọi là qua tai toán tử)
var v3 = v1 + v2;
v3.Info();




/* 03 Indexer
Ý TUONGR BAN ĐẦU: có thể lấy ra các đối số của đối tượng tương tự như array

VD: Vector v = new Vector(4,7);

v[0] ~ 4 
v[1] ~ 7


v["toadox"] ~ 4
v["toadoy"] ~ 7

*/

Console.WriteLine("Toa do v1" + v1[0]);




// *****************************************************************

class Vector
{
  double x;
  double y;

  public Vector(double _x, double _y)
  {
    x = _x;
    y = _y;

  }

  public void Info()
  {
    Console.WriteLine($"Toa do x = {x} - Toa do y = {y}");
  }

  public static Vector operator +(Vector v1, Vector v2)
  {
    return new Vector(v1.x + v2.x, v1.y + v2.y);
  }

  public double this[int i]
  {
    set
    {
      switch (i)
      {
        case 0: x = value; break;
        case 1: y = value; break;
        default: throw new Exception("Chi so sai");
      }
    }
    get
    {
      switch (i)
      {
        case 0: return x;
        case 1: return y;
        default: throw new Exception("Chi so sai");
      }


    }
  }

}





class CountNumber
{

  public static int number = 0;
  public static void Info()
  {
    Console.WriteLine("Số lần truy câp" + number);
  }

  public readonly string time;

  public void Count()
  {
    CountNumber.number++;
    number++;
    // this.number++; // Error vi number khong thuoc doi tuong Countnumber
  }
}

