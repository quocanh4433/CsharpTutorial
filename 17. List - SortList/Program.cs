/*
List: tập hợp các phần tử mà các phần tử này có cùng kiểu

List<ten_kieu_du_lieu> ds1
vd: List<string> ds;

*/


// Cách 1
// List<int> ds1 = new List<int>(new int[] { 8, 9, 10 });


// Cách 2
using System.Runtime.InteropServices;

List<int> ds1 = new List<int>() { 8, 9, 10 };

ds1.Add(1);
ds1.Add(2);
ds1.AddRange(new int[] { 5, 3, 4 });

Console.WriteLine("So luong cac phan tu " + ds1.Count);
Console.WriteLine("Phan tu dau tien trong List " + ds1[0]);





/* 01 CHÈN PHẦN TỬ
*******************************/

// Chèn vào List -> Insert(vị trị cần chèn, giá trị cần chèn)
ds1.Insert(0, 20);
ds1.InsertRange(0, new int[] { 2, 3, 8 });





/* 02 XÓA PHẦN TỬ
*******************************/

// Xóa phần tử trong List theo index
ds1.RemoveAt(2);


// Xóa phần tử trong list theo value 
// lưu ý: chỉ xóa phần tử đầu tiên bắt gặp
ds1.RemoveAt(9);


// Xóa các phần từ có trong mảng theo điều kiện
ds1.RemoveAll(isEven);
static bool isEven(int i)
{
  return ((i % 2) == 0);
}

// Xóa tất cả phần từ trong list
// ds1.Clear();



foreach (var item in ds1)
{
  Console.WriteLine(item);
}



/* 03 TÌM PHÂN TỬ
*******************************/

// Tìm phần tử đầu tiên thảo điều kiệ
ds1.Find(isEven);
ds1.FindAll(isEven);




/* 04. THỰC HÀNH
*******************************/
List<Product> dsSanPham = new List<Product>() {
  new Product("Samsung", "China", 324, 1000),
  new Product("Nokia", "Poland", 847, 1450),
  new Product("Apple", "USA", 854, 8900),
  new Product("Oppo", "China", 205, 7800)
};


// Tìm ra sản phẩm đầu iteen ở "China"
var p = dsSanPham.FindAll((item) =>
{
  return item.origin == "China";
});







/* 04. SẮP XẾP PHẦN TỬ
*******************************/

dsSanPham.Sort((p1, p2) =>
{
  // reutrn 0 -> p2 = p1
  // reutrn 1 -> p2 > p1 -> tăng dần
  // return -1 -> p2 < p1 -> giảm gdaanf

  if (p1.price == p2.price) return 0;
  if (p1.price > p2.price) return 1;
  return -1;
});


foreach (var item in dsSanPham)
{
  System.Console.WriteLine(item.name + " - " + item.price);
}




/* 05. SORTLIST */

SortedList<string, Product> products = new SortedList<string, Product>();

products["sp1"] = new Product("ABC", "USA", 134, 56000);
products["sp2"] = new Product("DEF", "UK", 534, 12000);
products.Add("sp3", new Product("XYZ", "UK", 543, 78000));


// Truy xuất
var p1 = products["sp1"];
System.Console.WriteLine(p1.name);


// Truy xuất keys và values của sorted list
var keys = products.Keys;
var values = products.Values;


foreach (var k in keys)
{
  var prod = products[k];
  Console.WriteLine(prod.name);
}


foreach (KeyValuePair<string, Product> item in products)
{
  Console.WriteLine($"{item.Key} - {item.Value.name}");
}



// Xóa phần tử
products.Remove("sp1");
products.RemoveAt(0);
products.Clear();


//****************************
class Product
{
  public string name;
  public string origin;
  public int ID;
  public int price;
  public Product(string name, string origin, int ID, int price)
  {
    this.name = name;
    this.origin = origin;
    this.ID = ID;
    this.price = price;
  }

}

