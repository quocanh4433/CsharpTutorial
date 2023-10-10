/*
Extension method: phương thức mở rộng chức năng 
của các thư viện class mà không nhất thiết phải tạo ra class kết thừa

- Để mở rông phương thức cân tạo một class static

- Các phương thức bên trong đều ở kiểu static

- sử dụng từ khóa "this" đẻ chỉ đối tượng cần mở rông


*/

using MyExtension;


// method BinhPhuong, Sin, CanBacHai được khai báo trong file MyExtension.cs
double a = 56;
double binhPHuong = a.BinhPhuong();
double sin = a.Sin();
double canbachai = a.CanBacHai();

Console.WriteLine(a.BinhPhuong());