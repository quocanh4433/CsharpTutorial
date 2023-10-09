/************************************************************************/
/************************************************************************/
/* 01. VARIBALE */
/************************************************************************/
/************************************************************************/

// /*
// Kieudaulieu Tenbien;
// */


// /*

//  int --- kiểu số nguyên (có dấu, dùng 32 bit biểu diễn, từ -2,147,483,648 đến 2,147,483,647)
//  sbyte --- kiểu số nguyên (có dấu, dùng 8 bit biểu diễn, từ -128 đến 127)
//  byte --- kiểu số nguyên (không dấu, dùng 8 bit biểu diễn, từ 0 đến 255)
//  short --- kiểu số nguyên (có dấu, dùng 16 bit biểu diễn, từ -32,768 đến 32,767)
//  ushort --- kiểu số nguyên (không dấu, dùng 16 bit biểu diễn, từ 0 đến 65,535)
//  long --- kiểu số nguyên (có dấu, dùng 64 bit biểu diễn, từ -9,223,372,036,854,775,808 đến 9,223,372,036,854,775,807)
//  ulong --- kiểu số nguyên (không dấu, dùng 64 bit biểu diễn, từ 0 đến 18,446,744,073,709,551,615)
//  float --- số thực chấm động (dùng 32 bit biểu diễn phù hợp số có bảy chữ số, độ chính xác số dấu chấm động 1.5 × 10−45 đến 3.4 × 1038)
//  double --- số thực chấm động (dùng 64 bit biểu diễn)
//  decimal --- số thực chấm động (dùng 128 bit biểu diễn)
//  char --- một ký tự (dùng 16 bit biểu diễn ký tự Unicode)
//  bool --- kiểu logic (chỉ nhận giá trị false hoặc true)
//  string --- chuỗi (xâu) ký tự (tập hợp các ký tự theo thứ tự - một văn bản text)
//  object --- đối tượng, biểu diễn các đối tượng C#, nó là kiểu cơ sở - mọi đối tượng C# đều kế thừa từ kiểu này.

// */


// string chuoi;
// int songuyen;
// char kytu;
// bool TrueOrFalse;

// /* 
// Mặc định kiểu số thực là dobule => muốn ép kieu sang float thì thêm 'f' phía sau => 12.12 
// */
// float c ;
// c = 12.12f;

// /* 
// Console được build trong System.IO 
// */
// // Console.WriteLine(c);
// // Console.Beep(); // tạo ra tiếng beep!!!!
// // Console.Clear(); // xóa console

// float t,d;
// Console.WriteLine("Nhap gia tri: ");
// string input = Console.ReadLine();
// t = float.Parse(input);
// d = Convert.ToSingle(input) + 2.3f;
// Console.WriteLine("So a = {0}, so b = {1}", t, d);


// /* 
// Khi báo biến ngầm định sau khi khởi tạo phải gán giá trị 
// */
// var h = "LETTER";
// // h = 5; //Error vig bien h là kieu string


// /*
// Khai báo hằng số
// */
// const float f05 = 13.45f;
// // f05 = 5.6f; Error

// const int i01 = 4;
// // i01 = 5; // Error



/************************************************************************/
/************************************************************************/
/* 01. OPERATOR */
/************************************************************************/
/************************************************************************/


// /*
// Toán tử toán học: +, -, *, /, %
// */

// int q = 7;
// int z = 2;

// Console.WriteLine("Ket qua q + z = {0}", q + z);
// Console.WriteLine("Ket qua q - z = {0}", q - z);
// Console.WriteLine("Ket qua q * z = {0}", q * z);
// Console.WriteLine("Ket qua q / z = {0}",  (float) q / z);
// Console.WriteLine("Ket qua q % z = {0}", q % z);


// /*
// - Toán tử gán: +=, -=, *=, /=, %=, ++, --
// - x++ và ++x như nhau
// */
// int u = 56;
// int i = u % 3;
// u %= 3;
// Console.WriteLine("Ket qua u: {0}, i: {1} ", u, i);

// /*
// Toán tử so sánh: >=, <=, !=, ==, <, >
// */
// Console.WriteLine($"So sanh q > z: { q > z} ");
// Console.WriteLine($"So sanh q < z: { q < z} ");
// Console.WriteLine($"So sanh q >= z: { q >= z} ");
// Console.WriteLine($"So sanh q <= z: { q <= z} ");
// Console.WriteLine($"So sanh q == z: { q == z} ");
// Console.WriteLine($"So sanh q != z: { q != z} ");

// /*
// Toán tử logic bool: $$, ||, ! (phủ định)
// */
// const bool bool1 = true;
// const bool bool2 = false;

// Console.WriteLine($"So sanh bool1 && bool2: {bool1 && bool2}");
// Console.WriteLine($"So sanh bool1 || bool2: {bool1 || bool2}");
// Console.WriteLine($"Phu dinh phép so sanh bool1 || bool2: {!(bool1 || bool2)}");


/************************************************************************/
/************************************************************************/
/* 03. CÂU LỆNH ĐIỀU KIỆN IF...ELSE */
/************************************************************************/
/************************************************************************/


// /*
// Tim so chan - le
// */
// int a;
// Console.WriteLine("Nhap gia trị a: ");
// a = int.Parse(Console.ReadLine());

// if (a % 2 == 0) 
// {
//   Console.WriteLine($"a = {a} la so chan");
// }
// else 
// {
//   Console.WriteLine($"a = {a} la so le");
// }


// /*
// Tinh diem trung binh
// */
// float toan, van, anhVan, diemTB;
// Console.WriteLine("Nhap diem mon Toan:");
// toan = float.Parse(Console.ReadLine());
// Console.WriteLine("Nhap diem mon Van:");
// van = float.Parse(Console.ReadLine());
// Console.WriteLine("Nhap diem mon Anh Van:");
// anhVan = float.Parse(Console.ReadLine());

// diemTB = (toan + van + anhVan) / 3f;
// Console.Write("Diem trung binh: {0} - ", diemTB);

// if(diemTB < 5 && diemTB >= 0)
// {
//   Console.WriteLine("HS Yeu");
// }
// else if (diemTB >=5 && diemTB < 6.5)
// {
//   Console.WriteLine("HS TB");
// }
// else if(diemTB >= 6.5 && diemTB < 8 )
// {
//   Console.WriteLine("HS Kha");
// }
// else if(diemTB >= 8)
// {
//   Console.WriteLine("HS Gioi");
// }
// else 
// {
//   Console.WriteLine("HS Ca Biet");
// }



/************************************************************************/
/************************************************************************/
/* 04. CÂU LỆNH ĐIỀU KIỆN SWITCH...CASE */
/************************************************************************/
/************************************************************************/

// // VD1:
// int a = 3;

// switch (a)
// {
//   case 1: 
//     Console.WriteLine("a = 1"); 
//     break;
//   case 2: 
//     Console.WriteLine("a = 2");
//     break;
//   case 3: 
//     Console.WriteLine("a = 3");
//     break;
//   case 4: 
//     Console.WriteLine("a = 4");
//     break;
//   default: 
//     Console.WriteLine("Số không hợp lệ"); 
//     break;
// }

// // VD2:

// Console.WriteLine("Nhap so dau tien: ");
// int num1 = int.Parse( Console.ReadLine());

// Console.WriteLine("Nhap so thu 2: ");
// int num2 = int.Parse( Console.ReadLine());

// Console.WriteLine("Hay chon lenh");
// Console.WriteLine("1/ Tinh tong");
// Console.WriteLine("2/ Tinh hieu");
// Console.WriteLine("3/ Tinh tich");
// Console.WriteLine("4/ Tinh thuong");

// L1: char c = Console.ReadKey().KeyChar;
// Console.WriteLine("");

// switch (c)
// {
//   case '1': 
//     Console.WriteLine($"Ket qua: {num1 + num2}"); 
//   break;
//   case '2': 
//     Console.WriteLine($"Ket qua: {num1 - num2}"); 
//   break;
//   case '3': 
//     Console.WriteLine($"Ket qua: {num1 * num2}"); 
//   break;
//   case '4': 
//     Console.WriteLine($"Ket qua: {num1 / num2}"); 
//   break;
//   default:
//     Console.WriteLine("Ket qua khong hop le. Vui long nhap lai");
//     goto L1; // Quay lai
//   break;
// }



/************************************************************************/
/************************************************************************/
/* 05. VÒNG LẶP do...while, while, for và lệnh break */
/************************************************************************/
/************************************************************************/


// /*
// Vòng lặp for... !!!
// */

// using System.Reflection.Emit;
// using System.Security.Cryptography.X509Certificates;

// for (int i = 0; i <= 5; i++)
// {
//   Console.WriteLine("Hello everybody!!!!");
// }

// /*
// Vong lap while ...!!!
// */
// int j = 0;
// while (j <= 5)
// {
//   Console.WriteLine("Hello everybody!!!!");
//   j++;
// }


// /*
// Vong lap do ... while ... !!!
// */
// int index = 0;
// do
// {
//   Console.WriteLine(index);
//   index++;
// }
// while (index < 10);


/************************************************************************/
/************************************************************************/
/* 06. ARRAY
/************************************************************************/
/************************************************************************/


// /*
// - Khai bao mang: kieudulieu[soPhanTu(Optional)] tenMang
// Vd: - int[] danhSach
//     - int[3] danhSachHocSinh // mang chỉ có 3 phần tử 
// */

// int[] magSoNguyen = {4, 5, 6, 7};
// // int[] mangSoNguyen = new int[4] {4, 5, 6, 7};

// float[] mangSoThapPhan;
// mangSoThapPhan = new float[5] {8.9f, 15.2f, 1.24f, 2.56f, 5.63f};

// string[] danhSachHocSinh = new string[2] {"Nam", "Nguyen"};
// string[] danhSachGiaoVien = {"thầy Khoa", "cô Hương"};
// // string[2] danhBaoVe = {"chú Tài", "chú Phong"}; // ERROR size của mảng phải được khai báo CHUNG với từ khóa NEW


// for(int i = 0; i < mangSoThapPhan.Length; i++)
// {
//   Console.WriteLine(mangSoThapPhan[i]);
// }



// /*
// Phương thức có trong mảng
// */



// Console.WriteLine($"Mang {mangSoThapPhan.Rank} chieu" );
// Console.WriteLine($"So lon nhat: {mangSoThapPhan.Max()}" );
// Console.WriteLine($"So nho nhat: {mangSoThapPhan.Min()}" );
// Console.WriteLine($"Tong: {mangSoThapPhan.Sum()}" );

// Array.Sort(mangSoThapPhan);
// string s = string.Join(" ", mangSoThapPhan);
// Console.WriteLine(s);



// /*
// - Khai bao mang HAI CHIEU: 

//      0 1 2

// 0    6 4 2
// 1    5 7 2

// [0, 1] = 4
// [1, 2] = 3

// */

// int[,] mangHaiChieu = new int[2,3] {{6, 4, 2}, {5, 7, 2}};

// int soHang = 2;
// int soCot = 3;

// for(int i = 0; i < soHang ; i++)
// {
//   for(int j = 0; j < soCot; j++)
//   {
//     Console.Write(mangHaiChieu[i,j]);
//     Console.Write(" ");
//   }
//   Console.WriteLine("");
// }



/************************************************************************/
/************************************************************************/
/* 07. METHOD
/************************************************************************/
/************************************************************************/

/*
static: tạo ra 1 phương thức mà không cần qua đối tượng lớp
*/

static void hello ()
{
  Console.WriteLine("Hello every body");
}

/*
Cú pháp khai báo phương thức

<Access Modifiers> <return type> <name_method>(<parameters>) {}

<Access Modifiers>: puplic, protected, static, private

- puplic: phương thức cho phép truy cập từ bên ngoài

*/

static void tich(int a, int b) 
{
  int result01 = Abc.Tinhtoan.tich(a, b);

  // Khai báo không theo thứ tự
  int result02 = Abc.Tinhtoan.tich(b: 6, a: 4);

  // Khia bao tham số mặc định
  int result03 = Abc.Tinhtoan.tich(1);


  Console.WriteLine($"Ket qua 01 la: {result01}");
  Console.WriteLine($"Ket qua 02 la: {result02}");
  Console.WriteLine($"Ket qua 03 la: {result03}");

};

tich(5,6);



/*
Reference Type and Value type

key word
+ ref: biến càn khia báo trước
+ out: biến không cần khai báo trước

*/


// ref
int c = 5;
Abc.Tinhtoan.binhPhuong(ref c);
Console.WriteLine($"c = {c}");


// out
int ketQua;
Abc.Tinhtoan.binhPhuong02(ref c, out ketQua);
Console.WriteLine($"ketQua = {ketQua}");



