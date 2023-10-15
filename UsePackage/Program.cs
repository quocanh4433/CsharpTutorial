using Newtonsoft.Json;
using Utils; // Thêm thư viện chuyển số thành chữ


/*
+ Câu lệnh thêm thư viên:
dotnet add package <packageName> --version xxx


+ Câu lệnh xóa thư viện
dotnet remove package <packageName>


+ Câu lệnh phục hồi các package
dotnet restore


+ Câu lệnh tham chiếu đến thư viện local
dotnet add <ten_dự_án.csproj> reference <tên_thư_viện.csproj>

dotnet add D:\QA\C#\UsePackage\UsePackage.csproj reference D:\QA\C#\Utils\Utils.csproj
*/


Product product = new Product();

product.Name = "Apple";
product.Expiry = new DateTime(2023, 12, 28);
product.Sizes = new string[] { "Samll", "Lagre" };


// Chuyển đối tượng thành chuỗi JSON
//-------------------------------------------------------
// string json = JsonConvert.SerializeObject(product);
// Console.WriteLine(json);


// Chuyển chuôi JSON thành đối tượng
//-------------------------------------------------------
string json = @"{
  'Name': 'Bad Boys',
  'ReleaseDate': '1995-4-7T00:00:00',
  'Genres': [
    'Action',
    'Comedy'
  ]
}";


Product m = JsonConvert.DeserializeObject<Product>(json);
Console.WriteLine(m);
Console.WriteLine(m.Name);




// Chuyển đối số thành chữ từ thư viện local
//-------------------------------------------------------
double a = 1456000;
var result = Class1.NumberToText(a);
Console.WriteLine(result);






/**********************************************************/

class Product
{
  public string Name { set; get; }
  public DateTime Expiry { set; get; }
  public string[] Sizes { set; get; }
}
