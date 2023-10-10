/*
Amonymous Type: kiểu dữ liệu vô danh

Object - thuoc tinh - chi đọc

new {thuoctinh = giatrị, thuoctinh2 = giatri2}
*/

var sanpham = new
{
  ten = "Ipad",
  gai = 1000,
  nãm = 2003
};

Console.WriteLine($"THuoc tinh chi duoc doc: {sanpham.ten}");


List<SinhVien> danhSachSV = new List<SinhVien>()
{
  new SinhVien() {HovaTen = "Nam", NamSinh = 2003, NoiSinh = "VinhLong"},
  new SinhVien() {HovaTen = "Tung", NamSinh = 1994, NoiSinh = "HaNoi"},
  new SinhVien() {HovaTen = "Khang", NamSinh = 2000, NoiSinh = "CanTHo"},
  new SinhVien() {HovaTen = "Phu", NamSinh = 1989, NoiSinh = "VinhPhuc"},
};

var ketqua = from sv in danhSachSV
             where sv.NamSinh <= 1994
             select new
             {
               ten = sv.HovaTen,
               noisinh = sv.NoiSinh
             };


foreach (var sv in ketqua)
{
  Console.WriteLine($"{sv.ten} - {sv.noisinh}");
}


/*****************************
KIÊU DYNAMIC

- Kiểu dũ liệu chi được xác định khi code được thực thi


- khác với khai báo "var" kiểu dữ liệu được xác định trong qua trình biên dịch
******************************/


var obj = 5678;

void DisplayName(dynamic object02)
{

  object02.name = "ABC";
  object02.gia = 3000;
}

int c = 4000;

DisplayName(c);
// Sẽ không báo lỗi nhưng nếu chạy dotnet run sẽ xay ra lỗi. 
// Do int c không có thuộc tính name và giá
// Nếu truyên vao dối tượng có thuộc tnhs nam và gia, chương trinh van hoat dong binh thuong

// *****************************************************
class SinhVien
{
  public string HovaTen;
  public int NamSinh;
  public string NoiSinh;
}


