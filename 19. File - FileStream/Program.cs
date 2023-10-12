
/* 01. DRIVEINFO
Class DRIVEINFO tại namespace System.IO: đọc thông tin các ổ đĩa trong hệ thống

****************************************************************************
*/

using System.Text;
using Microsoft.VisualBasic;

DriveInfo drive = new DriveInfo("D");

Console.WriteLine($"Drive: {drive.Name}");
Console.WriteLine($"Drive: {drive.DriveType}");
Console.WriteLine($"Drive: {drive.VolumeLabel}");
Console.WriteLine($"Drive: {drive.DriveFormat}");
Console.WriteLine($"Drive: {drive.TotalSize}");
Console.WriteLine($"Drive: {drive.TotalFreeSpace}");


// Biêu diên tất cả ổ đĩa có ở trong máy
var dsDrive = DriveInfo.GetDrives();

foreach (var item in dsDrive)
{
  Console.WriteLine($"+++++++++++++++++++++++++++++++");
  Console.WriteLine($"Drive: {item.Name}");
  Console.WriteLine($"Drive: {item.DriveType}");
  Console.WriteLine($"Drive: {item.VolumeLabel}");
  Console.WriteLine($"Drive: {item.DriveFormat}");
  Console.WriteLine($"Drive: {item.TotalSize}");
  Console.WriteLine($"Drive: {item.TotalFreeSpace}");
}




/* 02. DIRECTORY: thuộc class System.IO.Directory

Cung cấp cac phương thức tương ác với thư mục

****************************************************************************
*/

string path = "AAB";

CheckDiractory(path);

Directory.CreateDirectory("CCD");

CheckDiractory("CCD");

// Directory.Delete(path);




// Lấy danh sách các file có trong thư mục "obj"
var files = Directory.GetFiles("obj");

foreach (var f in files)
{
  System.Console.WriteLine(f);
}



// Lấy danh sách thư mục con trong thu muc "obj"
var directories = Directory.GetDirectories("obj");

foreach (var dicrectory in directories)
{
  System.Console.WriteLine("******************");
  Console.WriteLine(dicrectory);
}




// Liệt kê các thư mục file và thư mục con có trong một thư mục
static void ListFileDirectory(string path)
{
  String[] directories = System.IO.Directory.GetDirectories(path);
  String[] files = System.IO.Directory.GetFiles(path);
  foreach (var file in files)
  {
    Console.WriteLine(file);
  }
  foreach (var directory in directories)
  {
    Console.WriteLine(directory);
    ListFileDirectory(directory); // Đệ quy
  }
}

ListFileDirectory("obj");




static void CheckDiractory(string p)
{

  if (Directory.Exists(p))
  {
    System.Console.WriteLine($"{p} - ton tai");
  }
  else
  {
    System.Console.WriteLine($"{p} - khong ton tai");
  }
};


/* 03. PATH
Hỗ trợ làm việc với đường dẫn
****************************************************************************
*/


// Ký tự phân cách
// Trong mac, linux là dâu chéo xuôi  "/"
// Trong win la đâu chéo ngược "\" - Vd: C:\newfolder\hinhanh

Console.WriteLine(Path.DirectorySeparatorChar);


// Nối các phần từ thành đương dẫn duuy nhất
var path02 = Path.Combine("dir2", "dir3", "text.txt");
Console.WriteLine(path02);


// Thay đổi extension
var path03 = Path.ChangeExtension(path02, "md");
System.Console.WriteLine(path03);


// Tạo ra tên file ngâu nhiên đẻ luu trữ trạm
var nameFile = Path.GetRandomFileName();
Console.WriteLine(nameFile);








/* 04. FILE
Hỗ trợ làm việc với đường dẫn
****************************************************************************
*/


// Tao file
string filename = "abc.txt";
string content = "Hoc lap trinh c# - co ban";
string content02 = "Hoc lap trinh c# - nang cao";
File.WriteAllText(filename, content);

// Ghi đè nội dung cũ
File.WriteAllText(filename, content02);


// Ghi thêm vào nội dung cũ
File.AppendAllText(filename, " - Cap nhat nam 2023");

// Đọc nội dung của file
var allcontent = File.ReadAllText(filename);
Console.WriteLine(allcontent);


// Chuyên tên file
// File.Move(filename, "123.txt");

// Copy file
// File.Copy("xyz.txt", "456.txt");

// Xóa fiel
File.Delete("456.txt");




/* 05. FILESTREAM

Lớp FileStream là đọc và ghi dữ liệu ra file

- Do stream là tài nguyên không quant lý bơi GC, nên cần đưa nó vào cấu trúc "using" để 
tự động giải phóng tài nguyên (Dispose) khi khối lệnh kết thúc
*/

string dataPath = "data.dat";
using var stream = new FileStream(dataPath, FileMode.OpenOrCreate);


// Lưu dữ liệu
byte[] buffer = { 1, 2, 4 }; // Buffer: bộ dệm

stream.Write(buffer, 0, 3); // buffer: nơi lưu trư - 0: bắt đầu từ index 0 - 3: lưu trư 3 byte


// Doc du liệu
int soByteDocDuoc = stream.Read(buffer, 0, 3); // 0: bắt đầu từ - 3: môi lần đọc tăng thêm 3 byte


// int, double --> bytes
int abc = 1;
var byte_abc = BitConverter.GetBytes(abc);


// byte -> int, double

Console.WriteLine("Byte -> int: " + BitConverter.ToInt32(byte_abc, 0));



// string -> byte
var byte_string = Encoding.UTF8.GetBytes("ABC");
var byte_leng = byte_string.Length;
Console.WriteLine("Byte string: " + byte_string);
Console.WriteLine("Byte length: " + byte_leng);



// byte -> string
var stringEncode = Encoding.UTF8.GetString(byte_string, 0, byte_leng);
Console.WriteLine("byte -> string: " + stringEncode);



/* 06. THỰC HÀNH LƯU DỮ LIỆU VÀ ĐỌC DỮ LIỆU ĐÔI TƯỢNG TỪ FILE


*/
using var stream02 = new FileStream("streamFile.txt", FileMode.Open);


Product product = new Product();
// {
//   ID = 10,
//   Price = 12345,
//   Name = "San pham ABC"
// };

// product.Save(stream02);

product.Restore(stream02);

Console.WriteLine($"{product.Name} - {product.Price} - {product.ID}");


class Product
{
  public int ID { set; get; }

  public double Price { set; get; }

  public string Name { set; get; }

  public void Save(Stream stream)
  {
    var bytes_id = BitConverter.GetBytes(ID);
    stream.Write(bytes_id, 0, 4); // int chiếm 4 byte

    var bytes_price = BitConverter.GetBytes(Price);
    stream.Write(bytes_price, 0, 8); // double chiếm 8 byte

    var bytes_name = Encoding.UTF8.GetBytes(Name);
    // Xác định chuỗi có bao nhiêu byte
    var bytes_length = BitConverter.GetBytes(bytes_name.Length);

    // Ghi lại sô byte dưới dạng int --> 4bytes
    stream.Write(bytes_length, 0, 4);
    stream.Write(bytes_name, 0, bytes_name.Length); // double chiếm 8 byte


  }

  public void Restore(Stream _stream)
  {
    var byte_ID = new byte[4];

    _stream.Read(byte_ID, 0, 4);
    ID = BitConverter.ToInt32(byte_ID, 0);
    Console.WriteLine(ID);


    var byte_Price = new byte[8];
    _stream.Read(byte_Price, 0, 8);
    Price = BitConverter.ToDouble(byte_Price, 0);


    var byte_leng02 = new byte[4];
    _stream.Read(byte_leng02, 0, 4);
    int leng = BitConverter.ToInt32(byte_leng02, 0);

    var byte_Name = new byte[leng];
    _stream.Read(byte_Name, 0, leng);
    Name = Encoding.UTF8.GetString(byte_Name, 0, leng);


  }
}





