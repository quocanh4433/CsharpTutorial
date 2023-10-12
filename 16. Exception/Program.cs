/* 01.
Ý TƯỞNG BAN ĐẦU:

- Điều hướng chương trinh sang 1 luồng nào đó khi lỗi

- Thay vì phải kết thúc đột ngột


- Khi có lỗi chương trình phát sinh ra đối tượng Exception hoặc đối tượng kế thừa từ Exception

*/

int a = 5;
int b = 4;
int[] arr = { 1, 2 };

try
{
  var c = a / b;
  var e = arr[5];
}
catch (DivideByZeroException e1)
{
  // Error khi biến int b = 0
  Console.WriteLine("Khong the chia cho 0 " + e1.Message);
}
catch (IndexOutOfRangeException e2)
{
  Console.WriteLine("Không thể truy cập phần tử của mảng " + e2.Message);
}
catch (Exception e) // class kế thừa (DivideByZeroException e)
{
  Console.WriteLine(e.Message);
  Console.WriteLine(e.StackTrace);
  // at Program.<Main>$(String[] args) in D:\QA\C#\16. Exception\Program.cs:line 18
  // Lỗi xảy ra ở class Progarm, method Main,


  // Kiêm tra kiểu lỗi
  Console.WriteLine(e.GetType());
  Console.WriteLine("Chuong trinh da xay ra loi");
}
Console.WriteLine("Ket thuc");



/* 02. BẮT NHIỀU EXCEPTION CÙNG LÚC*/

try
{
  string path = "1.txt";
  string s = File.ReadAllText(path);
  System.Console.WriteLine(s);
}
catch (FileNotFoundException e)
{
  System.Console.WriteLine("Không tìm thấy file " + e.Message);
}
catch (ArgumentNullException e)
{
  System.Console.WriteLine("Duong dan file phai khac null " + e.Message);
}







/* 03. TAO RA EXCEPTION */

static void Register(string name, int age)
{
  if (string.IsNullOrEmpty(name))
  {
    // throw new Exception("Ten khong duoc rong");
    throw new NameEmptyException();
  }

  if (age < 18 && age >= 100)
  {
    throw new Exception("Tuoi phai >= 18 va nho <= 100");
  }

  System.Console.WriteLine("Xin chao " + name + " - " + age);
}


try
{
  Register("", 20);
}
catch (NameEmptyException e)
{
  Console.WriteLine("Message:" + e.Message);
}
