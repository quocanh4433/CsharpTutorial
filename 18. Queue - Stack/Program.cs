/* 01
QUEUE: tương tự như kiểu dữ liệu List NHƯNG

- Thêm phân tử (Enqueue): luôn luôn thêm ở cuối danh sách

- Xóa phần tư (Dequeue):  Xóa phần tử đầu tiên



FIFO: first in first out

*/


Queue<string> hoso = new Queue<string>();


// Thêm phần tử
hoso.Enqueue("Ho so 01");
hoso.Enqueue("Ho so 02");
hoso.Enqueue("Ho so 03");

foreach (var hs in hoso)
{
  Console.WriteLine(hs);
}


// Xóa phần tử
var h = hoso.Dequeue();
Console.WriteLine($"Ho so duoc xu ly: {h} - So luong ho so con lai: {hoso.Count}");




/*
02. STACK
LIFO: last in, first out
*/


Stack<string> hanghoa = new Stack<string>();


hanghoa.Push("Mat hang 01");
hanghoa.Push("Mat hang 02");
hanghoa.Push("Mat hang 03");


var mathang = hanghoa.Pop();
Console.WriteLine($"Đa lay mat hang {mathang}");



/*
03. LINKEDLIST
*/

LinkedList<string> cacbaihoc = new LinkedList<string>();

// thêm vào đầu tiên của danh sách
cacbaihoc.AddFirst("Bai hoc 1");

// Thêm vào cuối cùng của danh sách
cacbaihoc.AddLast("Bai hoc cuoi cung");

// Method AddFrist() va AddLast() trả về node nê có thể gán vào biến
var baihoc02 = cacbaihoc.AddFirst("Bai hoc 02");
var baihoc03 = cacbaihoc.AddLast("Bai hoc 03");

// Kiểu dữ liệu trả về của MEthod AddFirst(), AddLast() là 
LinkedListNode<string> baihoc04 = cacbaihoc.AddAfter(baihoc02, "Bai hoc 04");

Console.WriteLine(baihoc02.Value);

// Node trước một node
Console.WriteLine(baihoc02.Next);

// Node sau một node
Console.WriteLine(baihoc02.Previous);

// Node cuối cung
Console.WriteLine(cacbaihoc.Last());



/*
04. DICTIONARY
Tương tự như SortedList như dùng cho dữ liệu lớn
*/
Dictionary<string, int> sodem = new Dictionary<string, int>()
{
  ["mot"] = 1,
  ["hai"] = 2
};

sodem["three"] = 3;
sodem.Add("four", 4);

var keys = sodem.Keys;

foreach (var k in keys)
{
  System.Console.WriteLine(sodem[k]);
}

foreach (KeyValuePair<string, int> item in sodem)
{
  System.Console.WriteLine(item.Key + " - " + sodem.Values);
}


/*
05. HASHSET
Mục đích là lưu trữ các phần từ không trùng nhau
*/

HashSet<int> set1 = new HashSet<int>() { 1, 2, 8, 6, 7 };
HashSet<int> set2 = new HashSet<int>() { 8, 1, 5, 6, 9, 10 };

// THêm phần từ
set1.Add(11);

// Xóa phân tử
set1.Remove(8);



// UnionWith - set1 hợp với set2
// Set1 sẽ lấy tất cả phần từ của set2 đưa vào chính nó
// Các phần từ chưa tồn tại trong set1
set1.UnionWith(set2);



// IntersectWith - set1 giao với set2
// Lấy ra các phần từ giống nhau giưa hai tập hơp
set1.IntersectWith(set2);







