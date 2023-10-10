/* 01
Delegate: Kiểu ủy quyền


Ý TƯỞNG BAN ĐẦU:

- Tao ra các variable tham chiêu được đến các phương thức ( bien = phương thuc)

- Biến này được gọi là biến kiểu DELEGATE
*/

ShowLog log = null;

log = Info;
log("Xin chao");
log.Invoke("Xin chao"); // Hai cách này tương tự nhau
log?.Invoke("Xin chao");


log = Warning;
log("Hoc lap trih C#");





/* 02
Chuỗi phương thức trong biến delegate

- Sử dụng biến delegate thực hiện nhiều phương thức cùng lúc
*/

Console.WriteLine("**************CHUOI PHƯƠNG THUC******************");
log += Warning;
log += Info;
log += Info;
log += Warning;
log("Lap trinh REST full API");








/* 03 ACTION

Ý TƯỞNG BAN ĐẦU:
- THay vì định nghĩ các delegate trước 
VD:  public delegate void ShowLog(string message);

- Co thể sử dụng ACtion và Func

- Action: delegate kiểu trả về là void hay không có kiểu dữ liệu gì

vD: 
Action <TenKieu>;   ~ delegate void KIEU()
Action<string, int> <TenKieu>; ~ delegate void KIEU(string, int)

*/


Console.WriteLine("************** ACTION ******************");
Action<string> action1;
Action action2;

action1 = Info;
action2 = Danger;

action1("Xin chao");
action2();





/* 04. FUNC
Tương tự như Action nhưng có kiểu trả về ở cuối cùng

A, B, C: kiểu dữ liệu của tham số

Func<A, B, C,....., KieuDuLieuTraVe>

VD: Func<string, int, double> action01 ~ delegate double action01(string, int)

*/

Console.WriteLine("************** FUNCTION ******************");

Func<int, int, string> action03;
Func<double, int, string> action04;

action03 = Tong;
// action03 = Hieu; // ERROR: không đúng kiểu dữ liệu của tham số
action04 = Hieu;
// action04 = Tong; // ERROR: không đúng kiểu dữ liệu của tham số






/* 05.  DELEGATE là tham số của một hàm */
Console.WriteLine("************** Delegate là tham số cua mot method ******************");
Tich(3, 4, Info);





//******************************************************************
static string Tong(int a, int b) => (a + b).ToString();
static string Hieu(double a, int b) => (a - b).ToString();

static void Tich(int a, int b, ShowLog log)
{
  string result = (a * b).ToString();
  log?.Invoke($"Ket qua la: {result}");
}

static void Danger()
{
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine("RẤT LÀ NGUY HIỂM");
  Console.ResetColor();
}


static void Info(string s)
{
  Console.ForegroundColor = ConsoleColor.Green;
  Console.WriteLine(s);
  Console.ResetColor();
}

static void Warning(string s)
{
  Console.ForegroundColor = ConsoleColor.Magenta;
  Console.WriteLine(s);
  Console.ResetColor();
}


public delegate void ShowLog(string message);

