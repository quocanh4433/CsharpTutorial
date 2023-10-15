using System.ComponentModel.DataAnnotations;
using System.Reflection;

/* 01. CLASS TYPE

- Phân biệt class type - datatype interface


- Class Type: chứa thông tin các Class, struct, ... int, bool,..

- Class Type thường được sử dụng trong kỹ thuật Reflection: lấy thông tin của kiểu dữ liệu
ở thơi điểm thực thi


*/

int a = 1;

Type t1 = typeof(int);
Type t2 = typeof(string);
Type t3 = typeof(Array);
var t4 = a.GetType();


int[] b = { 1, 2, 3 };
var t5 = b.GetType();
// Console.WriteLine(t5);


Console.WriteLine("Cac thuoc tinh -------------------------");
// t5.GetProperties().ToList().ForEach((PropertyInfo o) => { Console.WriteLine(o.Name); });


Console.WriteLine("Cac du lieu -------------------------");
// t5.GetFields().ToList().ForEach((FieldInfo o) => { Console.WriteLine(o.Name); });


Console.WriteLine("Cac phuong thuc -------------------------");
// t5.GetMethods().ToList().ForEach((MethodInfo o) => { Console.WriteLine(o.Name); });




/* 02. THỰC HÀNH lấy kiểu dữ liệu 
*/

User user = new User()
{
  Name = "QuocAnh",
  Age = 20,
  PhoneNumber = "5446512",
  Email = "quocanh@gamil.com"
};


// var propertiesUser = user.GetType().GetProperties();

// foreach (PropertyInfo property in propertiesUser)
// {
//   string name = property.Name;
//   var value = property.GetValue(user);

//   Console.WriteLine($"{name} - {value}");


// }



/* 03. ATTRIBUTE: THUỘC TÍNH BỔ SUNG

- Cung cấp thông tin bổ sung cho một class hoặc thành viên của một class

- Thông tin sẽ được lấy ra trong quá trình thực thi
*/

// Dánh dấu phương thức đã lôi thời dùng từ khóa "Obsolete"
user.PrintInfo();


// Lấy 
var propertiesUser = user.GetType().GetProperties();

foreach (PropertyInfo property in propertiesUser)
{
  foreach (var attr in property.GetCustomAttributes(false))
  {
    MotaAttribute mota = attr as MotaAttribute;

    if (mota != null)
    {
      var value = property.GetValue(user);
      Console.WriteLine($"{mota.ThongTinChiTiet} : {value}");
    }
  }
}



/* 04. THỰC HÀNH VỚI CÁC ATTIBUTE THIẾT LẬP SẴN
*/

User02 user02 = new User02()
{
  Name = "QuocAnh",
  Age = 7,
  PhoneNumber = "5446512",
  Email = "quocanhgamil.com"
};


ValidationContext context = new ValidationContext(user02);
var result02 = new List<ValidationResult>();

bool isError = Validator.TryValidateObject(user02, context, result02, true);
// true: kiểm tra tất cả các thuộc tính của đối tượng user02

if (isError == false)
{
  result02.ToList().ForEach((err) =>
  {
    Console.WriteLine($"Error --------- {err.MemberNames.First()}");
    Console.WriteLine(err.ErrorMessage);

  });
}




//****************************************
[Mota("Class chua thong tin User cua he thong")] // Mota() = MotaAttribute()
class User
{
  [Mota("Ten nguoi dung")]
  public string Name { set; get; }
  [Mota("Tuoi nguoi dung")]

  public int Age { set; get; }
  [Mota("So dien thoai nguoi dung")]
  public string PhoneNumber { set; get; }
  [Mota("Email nguoi dung")]
  public string Email { set; get; }
  [Obsolete("Phuong thuc khong phu hop. Can thay the phuong thuc ShowInfo")]
  public void PrintInfo() => Console.WriteLine($"{Name}");
  public void ShowInfo() { Console.WriteLine($"{Name}"); }
}



class User02
{
  [Required(ErrorMessage = "Phải khai bao ten nguoi dung")]
  [StringLength(50, MinimumLength = 3, ErrorMessage = "Ten phai tu 3 -> 50 ky tu")]
  // [Mota("Ten nguoi dung")]
  public string Name { set; get; }
  // [Mota("Tuoi nguoi dung")]
  [Range(18, 80, ErrorMessage = "tuoi phai tu 18 -> 80")]
  public int Age { set; get; }
  // [Mota("So dien thoai nguoi dung")]
  [Phone]
  public string PhoneNumber { set; get; }
  // [Mota("Email nguoi dung")]
  [EmailAddress]
  public string Email { set; get; }
  [Obsolete("Phuong thuc khong phu hop. Can thay the phuong thuc ShowInfo")]
  public void PrintInfo() => Console.WriteLine($"{Name}");
  public void ShowInfo() { Console.WriteLine($"{Name}"); }
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
class MotaAttribute : Attribute
{
  public string ThongTinChiTiet { set; get; }

  public MotaAttribute(string _ThongTinChiTiet)
  {
    this.ThongTinChiTiet = _ThongTinChiTiet;
  }
}