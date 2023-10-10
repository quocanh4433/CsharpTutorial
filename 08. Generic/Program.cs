/*
Ý TƯỞNG BAN ĐẦU: 



int a = 5;
int b = 6;

static int Tich (int x, int y) {
  return x * y;
}

Tich(5,6) => 30





- Bây giờ, muốn tính tích của 2 số thục SẼ phải
tạo thêm method Tich() với kiểu trả về là số thực




float a = 3.4f;
float b= 5.6f;

static float Tich(float x, float y){
  return x * y;
}

Tich(3.4f, 5.6f) => 19.04





- Lúc này, Generic ra đời để có thể tính Tich với các kiểu dư liệu linh hoạt
theo use


static T Tich<T>(T x, T y) {
  return x * y
}




*/

int a = 10;
int b = 45;



static void Swap(ref int x, ref int y)
{
  int t = x;
  x = y;
  y = t;
}


Swap(ref a, ref b);

Console.WriteLine($"a = {a} , b = {b}");


Product<string> sanpham = new Product<string>();
sanpham.SetID("fđsfdfsdf");

Product<int> sanpham2 = new Product<int>();
sanpham2.SetID(123445);

sanpham.Printf();
sanpham2.Printf();


/*
Lúc này, bài toán chỉ nhận kiểu dữ liệu int

Để tổng quát bài toán hơn có thể nhận bất kỳ kiểu dữ liệu 

Sử dụng Generic

*/


static void Swap02<T>(ref T x, ref T y)
{
  T t = x;
  x = y;
  y = t;
}

float f1 = 3.4f;
float f2 = 8.9f;

double d1 = 56.7;
double d2 = 122.3;

string s1 = "Hello";
string s2 = "Xin chao";

Swap02<string>(ref s1, ref s2);
Swap02<float>(ref f1, ref f2);
Swap02<double>(ref d1, ref d2);

Console.WriteLine($"s1 = {s1}, s2 = {s2}");
Console.WriteLine($"d1 = {d1}, s2 = {d2}");
Console.WriteLine($"f1 = {f1}, s2 = {f2}");








/**
GENERIC: cho class
*/


class Product<T>
{
  T ID;

  public void SetID(T id)
  {
    this.ID = id;
  }

  public void Printf()
  {
    Console.WriteLine($"ID = {this.ID}");
  }
}

