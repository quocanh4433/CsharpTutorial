// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");


/*
Nối chuỗi
*/
string a, b; // null
a = "Xin Chào";
b = "Quoc Anh";

string loiChao = a + " " + b;
Console.WriteLine(loiChao);


/* Chèn ký tự đặc biệt vào chuỗi*/

// chèn dấu nháy kép ""
string special = "Hoc lap trình \"Csharp\"";
Console.WriteLine(special);

// chèn dáu chéo "\"
string backslash = "Hoc lap trình \\";
Console.WriteLine(backslash);

// Chèn các ký tự đặc biệt
// \n : new line
// \t : tab
// \r : trờ về đầu dòng
string newString = "Hoc\r lap\n trinh\t  \"Csharp\" cho nguoi moi bat dau";
Console.WriteLine(newString);


/*
Chèn theo đúng format
*/

// Để hiên thị dấu nhay kép cần thực hiện 2 dâu nháy kép

string formatString = @"Xin chao 2021    ----- """"   --- ";
Console.WriteLine(formatString);




/*
Chèn biểu thức giá trị vào chuỗi
*/
int year = 2023;
string valueString = $"Nam nay là {year}";
Console.WriteLine(valueString);

/*
Chèn giá trị + format
*/

string sex = "Nam";
string birth = "1996";
string name = "Anh";

string thongBao =
$@"


Ho va ten: {name,10}
Nam sinh: {birth,10}
Gioi tinh: {sex,10}


";

Console.WriteLine(thongBao);


/* Đô dài chuỗi */
int length = thongBao.Length;
Console.WriteLine(length);


/* Cắt chuỗi */
string quangcao = "******** Alo alo ********";
Console.WriteLine(quangcao.Trim('*'));
Console.WriteLine(quangcao.TrimEnd('*'));
Console.WriteLine(quangcao.TrimStart('*'));
Console.WriteLine(thongBao.Trim());


/* Chuyển chữ thường thành chữ hoa và ngược lại */
Console.WriteLine(quangcao.ToUpper());
Console.WriteLine(quangcao.ToLower());


/* THay thế chuỗi */
Console.WriteLine(quangcao.Replace("Alo", "Hello"));


/* Chèn vào chuỗi */
Console.WriteLine(quangcao.Insert(12, " hello"));


/* Lấy ra chuỗi con từ chuôi ban đầu */
Console.WriteLine(quangcao.Substring(8, 4));


/* Xóa chuỗi con */
Console.WriteLine(quangcao.Remove(8));
Console.WriteLine(quangcao.Remove(8, 4));


/* Chia chuôi thành các chuỗi con theo ky tự */
Console.WriteLine(String.Join("###", quangcao.Split(" ")));



/* StringBuilder */
StringBuilder loiNoiDau = new StringBuilder();
Console.WriteLine("Lơi noi dau tien:{0}**", loiNoiDau);
Console.WriteLine(loiNoiDau.GetType());

loiNoiDau.Append("Hello");
loiNoiDau.Append(" ");
loiNoiDau.Append("Everybody!!!!!");

Console.WriteLine(loiNoiDau);