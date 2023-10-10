/* 01 LAMDA EXPRESSION

Biểu thức lamda => Anonymous Function

a)
(tham_so) => bieu_thuc


b)
(tham_so) => {
  cac_bieu_thuc
  return bieu_thuc_tra_ve;
}

*/


// (string s) => Console.WriteLine("Xin chao!!"); 
// ERROR: vì chưa gán cho biến
// biêu thức lamda trên ~ delegate void KIEU(string s) = Action<string> ten_bien;
// Để fix lỗi trên gan biểu thức lamda cho biến kiểu delegate

Action<string> thongbao;
thongbao = (string s) => Console.WriteLine("Xin chao!!");

// Các viết khác
// Vì biến s là được ép kiểu ở string ở Action<string> nên có thể bỏ kiểu string ở tham sô s
Action<string> thongbao02;
thongbao02 = (s) => Console.WriteLine("Xin chao!!");


for (int i = 0; i < 5; i++)
{
  thongbao?.Invoke("Hello wold !!!!");
}


for (int i = 0; i < 5; i++)
{
  thongbao02?.Invoke("Hello work !!!!");
}





/*
Thưc hành biểu thức lamda có kiểu dữ liệu trả về
*/

Func<int, int, string> tinhTong;
tinhTong = (int a, int b) =>
{
  string ketqua = (a + b).ToString();
  return ketqua;
};

Console.WriteLine(tinhTong.Invoke(4, 6));






/*
Sử dụng lamda cho một số thư viện .NET
*/

int[] mang = { 2, 8, 10, 45, 7 };


var kq = mang.Select((int x) =>
{
  return Math.Sqrt(x);
});

// Console.WriteLine(String.Join(" - ", kq));


var kq02 = mang.Where((int x) =>
{
  return x % 4 == 0;
});

Console.WriteLine(String.Join(" - ", kq02));
Console.WriteLine(kq02);





