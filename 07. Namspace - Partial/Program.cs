using level2 = Mynamespace.MynamespaceLevel2;
using level1 = Mynamespace;
using static System.Math;



/*
Namespace:
  - khai báo một phạm vi, nó chứa tập hợp các đối tượng liên quan nhau, 
  nhằm mục đích tổ chức code khoa học, dễ quản lý và đặc biệt là tránh xung đột 
  về tên. (bạn có thể khai báo hai lớp tên giống nhau nhưng nằm ở hai 
  namespace khác nhau).

Partail: chia các class thành cac file khác nhau để dễ quan lý


*/

level1.Class1.XinChao();
level2.Class1.XinChao();
Console.WriteLine(PI);
Console.WriteLine(E);


SanPham.Product sanpham1 = new SanPham.Product();
sanpham1.name = "IPAD";
sanpham1.price = 1000;
sanpham1.description = "Mắc lắm đưng mua";

sanpham1.GetInfo();

sanpham1.manufactory = new SanPham.Product.Manufactory();
sanpham1.manufactory.name = "CHINA";
sanpham1.manufactory.year = "1996";






