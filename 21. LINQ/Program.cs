/* 01. LINQ (Language Integrated Query): Ngôn ngữ truy vấn tích hợp 

- Giúp viết trong c# nhưng câu lênh truy vân tới cac nguồn dữ liệu để lấy dữ liệu

- Nguồn dữ liệu: IEnumerable, IEnumerable<T> (Stack, Queue, List, Array, ...)
                  XML, SQL, ...
*/

using System.ComponentModel;

var brands = new List<Brand>() {
    new Brand{ID = 1, Name = "Công ty AAA"},
    new Brand{ID = 2, Name = "Công ty BBB"},
    new Brand{ID = 4, Name = "Công ty CCC"},
};

var products = new List<Product>()
{
    new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
    new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
    new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
    new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
    new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
    new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
    new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
};


// Lấy ra các sản phẩm có giá 400
var query = from p in products
            where p.Price == 400
            select p;

// foreach (var item in query)
// {
//   Console.WriteLine($"{item.Name} - {item.Price}");
// }





/* 02. SELECT -> Trả về tập hợp các mang chuỗi string[]
- Khi sd thư viện Linq nó sẽ mở rông cho các IEnumerable cac method 
*************************************************************************
*/

var danhSachSelect = products.Select((p) => new
{
  Ten = p.Name,
  Gia = p.Price
});
// foreach (var item in danhSachSelect)
// {
//   Console.WriteLine(item);
// }




/* 03. SELECTMANY -> trả về tập hơp các chuôi
*************************************************************************
*/
var danhSachSelectMany = products.SelectMany((p) => p.Colors);

// foreach (var item in danhSachSelectMany)
// {
//   Console.WriteLine(item);
// }




/* 04. WHERE
*************************************************************************
*/

var danhSachWhere = products.Where((p) => p.Price >= 200 && p.Price <= 500);

// foreach (var item in danhSachWhere)
// {
//   Console.WriteLine(item);
// }




/* 05. MIN, MAX, SUM, AVERAGE
*************************************************************************
*/
int[] numbers = { 1, 2, 4, 6, 4, 2, 8, 9, 23, 47 };

var dsSoLe = numbers.Where(n => n % 2 != 0);
var soLeLonNhat = dsSoLe.Max();
var tongSoLe = dsSoLe.Sum();

// Console.WriteLine(soLeLonNhat + " - " + tongSoLe);


var giaNhoNhat = products.Min(p => p.Price);
var giaTB = products.Average(p => p.Price);

// Console.WriteLine(giaNhoNhat + " - " + giaTB);







/* 06. JOIN
*************************************************************************
*/

var danhsachJoin = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
{
  return new
  {
    Ten = p.Name,
    ThuongHieu = b.Name
  };
});


// foreach (var item in danhsachJoin)
// {
//   Console.WriteLine(item.ToString());

// }






/* 07. GROUPJOIN
*************************************************************************
*/

var danhsachGroupJoin = brands.GroupJoin(products, b => b.ID, p => p.Brand, (brand, danhsachSP) =>
{
  return new
  {
    ThuongHieu = brand.Name,
    danhsachSP
  };
});

// foreach (var item in danhsachGroupJoin)
// {
//   Console.WriteLine(item.ThuongHieu);

//   foreach (var sp in item.danhsachSP)
//   {
//     Console.WriteLine(sp);

//   }

// }







/* 08. TAKE
Lấy ra các giá trị đầu tiên
*************************************************************************
*/
// products.Take(4).ToList().ForEach(p => Console.WriteLine(p));







/* 09. SKIP
Bỏ qua các phần từ đầu tiên
*************************************************************************
*/
// products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));








/* 10. ORDERBY
Sắp xếp tăng dần
*************************************************************************
*/
// products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));








/* 10. ORDERBYDESCENDING
Sắp xếp giảm dân
*************************************************************************
*/
// products.OrderByDescending(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));

// products.OrderByDescending(p => p.Brand).ToList().ForEach(p => Console.WriteLine(p));






/* 11. REVERSE
Đảo ngược thứ tự các phần tử
*************************************************************************/

// numbers.Reverse().ToList().ForEach(n => Console.WriteLine(n));





/* 12. GROUPBY
Tâp hợp các phần tư theo gái trị
*************************************************************************/
var danhhsachGroupByPrice = products.GroupBy(p => p.Price);

// foreach (var group in danhhsachGroupByPrice)
// {
//   Console.WriteLine(group.Key);
//   foreach (var p in group)
//   {
//     Console.WriteLine(p);
//   }
// }



/* 13. DISTINCT
Loại bỏ cac phân tử cùng giá trị - chỉ giữ lại 1 giá trị
*************************************************************************/

// products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(color => Console.WriteLine(color));







/* 14. SINGLE
Trả về 1 phần tử thỏa mãn điều kiên


- Nếu không tìm thấy hoặc tìm thấy nhiều hơn một phần tử thỏa mãn điều kiên sẽ
phát sinh lỗi
*************************************************************************/

var productSingle = products.Single(p => p.Price == 600);
// Console.WriteLine(productSingle);


// var productSingle = products.Single(p => p.Price == 400); // ERROR: do có hai phần từ 400





/* 15. SINGLEORDEFAULT
Trả về 1 phần tử thỏa mãn điều kiên


- Nếu không tìm thấy tra ve NULL


- Nếu tìm thấy nhiều hơn một phần tử thỏa mãn điều kiên VẪN phát sinh lỗi
*************************************************************************/



var productSingleDefault = products.SingleOrDefault(p => p.Price == 9000);

if (productSingleDefault != null)
{
  Console.WriteLine(productSingleDefault);
}
else
{
  Console.WriteLine("NULLL");
}

// var j = productSingleDefault == null ? productSingleDefault ? "NULLLL";







/* 13. ANY
- Trả về true/fale 
- Nếu thoa mãn/không thoản mãn điều kiên logic nào đó
*************************************************************************/

var isAny = products.Any(p => p.Price == 700);







/* 14. ALL
- Trả về true/fale
- Nếu tất cả phần tử thỏa mãn/không thoa mã điều kiện nào đó  
*************************************************************************/
var isAll = products.Any(p => p.Price >= 700);
// Console.WriteLine(isAll);










/* 14. COUNT
- Trả về sô phẩn tử thỏa điều kiện
*************************************************************************/
var count = products.Count(p => p.Price == 400);
// Console.WriteLine(count);








/* 15. THỰC HÀNH
- In  ra sản phẩm, tên thương hiệu giá 300 đến 500
- Giá giảm dần
*************************************************************************/

var danhsachSanPham = products
  .Where((prod) => prod.Price >= 300 && prod.Price <= 500)
  .OrderByDescending(prod => prod.Price)
  .Join(brands, p => p.Brand, b => b.ID, (prod, brand) =>
  {
    return new
    {
      tenSP = prod.Name,
      tenTH = brand.Name,
      gia = prod.Price
    };
  });


// foreach (var item in danhsachSanPham)
// {
//   Console.WriteLine(item);
// }











/* 16. CÚ PHÁP CỦA LINQ: gôm 2 phân

1) Xác định nguôn dũ liệu: from tenphantu in IEnumerable

2) Lấy dữ liệu: select, group by, where...

*************************************************************************/

var qr = from p in products
         from color in p.Colors
         where p.Price <= 600 && color == "Xanh"
         orderby p.Price descending
         select new
         {
           Ten = p.Name,
           Gia = p.Price,
           MauSac = p.Colors
         };
foreach (var item in qr)
{
  Console.WriteLine(item.Ten + " - " + item.Gia + " - " + string.Join(",", item.MauSac));

};




//***** Nhóm cá sản phẩm theo gía


var qrGroup = from p in products
              group p by p.Price into gr
              orderby gr.Key
              let sl = gr.Count()
              select new
              {
                Gia = gr.Key,
                Cacsanpham = gr.ToList(),
                SoLuong = sl
              };


// Cach 1
// qrGroup.ToList().ForEach(i =>
// {
//   // Console.WriteLine(group.Key);
//   // group.ToList().ForEach(p => Console.WriteLine(p));

//   Console.WriteLine(i.Gia);
//   Console.WriteLine(i.SoLuong);
//   i.Cacsanpham.ForEach(p => Console.WriteLine(p));
// });


// Cach 2
// foreach (var group in qrGroup)
// {
//   Console.WriteLine(group.Key);
//   foreach (var prod in group)
//   {
//     Console.WriteLine(prod);
//   }
// }






//***** Ket hop cac nguon du lieu voi tu khoa Join()
var qrJoin = from product in products
             join brand in brands on product.Brand equals brand.ID into t
             from b in t.DefaultIfEmpty()
             select new
             {
               ten = product.Name,
               gia = product.Price,
               thuonghieu = (b != null) ? b.Name : "Khong co thuong hieu"
             };

qrJoin.ToList().ForEach(p =>
{
  Console.WriteLine($"{p.ten} - {p.gia} - {p.thuonghieu}");
});


/*****************************************************************************************/
public class Product
{
  public int ID { set; get; }
  public string Name { set; get; }         // tên
  public double Price { set; get; }        // giá
  public string[] Colors { set; get; }     // các màu sắc
  public int Brand { set; get; }           // ID Nhãn hiệu, hãng
  public Product(int id, string name, double price, string[] colors, int brand)
  {
    ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
  }
  // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
  override public string ToString()
     => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

}


public class Brand
{
  public string Name { set; get; }
  public int ID { set; get; }
}

