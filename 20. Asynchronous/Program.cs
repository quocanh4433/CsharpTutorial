

static void DoSomeThing(int second, string mgs, ConsoleColor color)
{
  for (int i = 0; i < second; i++)
  {
    lock (Console.Out)
    {
      Console.ForegroundColor = color;
      Console.WriteLine($"Lan lap thu {i,10} - {mgs}");
      Thread.Sleep(1000);
    }

  }
  Console.ResetColor();
}

static async Task Task2()
{
  Task t2 = new Task(() => DoSomeThing(10, "T2", ConsoleColor.DarkGreen));
  t2.Start();
  await t2;
  System.Console.WriteLine("T2 da hoan thanh .....");
  // return t2; // await đẽ trả về t2 nên không cân return
};

static async Task Task3()
{
  Task t3 = new Task(
  (object ob) =>
  {
    string tentacvu = (string)ob;
    DoSomeThing(3, tentacvu, ConsoleColor.Blue);
  }, "T3");

  t3.Start();
  await t3;
  System.Console.WriteLine("T3 da hoan thanh .....");
  // return t3; // await đã tra về t3 nen không cân return
};


// DoSomeThing(5, "Everybody ", ConsoleColor.Blue);








/* 01 SYNCHRONOUS
- Tạo ra ứng dụng có khả ăng chạy đơn luồng (single thread)
*************************************************************************
*/

// DoSomeThing(3, "T1", ConsoleColor.Yellow);
// DoSomeThing(5, "T2", ConsoleColor.Green);
// DoSomeThing(2, "T3", ConsoleColor.Red);








/* 02. ASYNCHRONOUS
- Tạo ra ứng dụng có khả ăng chạy đa luồng (multi thread)

- Task , Taks<T>
*************************************************************************
*/

// Cách 1
//-------------------------
// Task t2 = new Task(Action); // () => {}
// Task t2 = new Task(() => DoSomeThing(10, "T2", ConsoleColor.DarkGreen));
Task t2 = Task2();


// Cach 2
//--------------------------
// Task t3 = new Task(Action<Object>, Object); // (Object ob) => {}
// Task t3 = new Task(
//   (object ob) =>
//   {
//     string tentacvu = (string)ob;
//     DoSomeThing(3, tentacvu, ConsoleColor.Blue);
//   }, "T3");
Task t3 = Task3();



// Chạy trên 3 thread khác nhau
// t2.Start();
// t3.Start();
DoSomeThing(2, "T1", ConsoleColor.Red);

// t2.Wait();
// t3.Wait();
Task.WaitAll(t2, t3);


Console.WriteLine("Press any key");
Console.ReadKey();






/* 03. ASYNCHRONOUS
Cho tác vụ có giá trị trả về  Taks<T>
*************************************************************************
*/

// Tương tự như ví dụ trên nhưng ở phương thức có thêm kiểu trả về

// Và nhận được kiểu trả về sau khi hoàn thành var ketqua =  t4.Result;



/* 04. THƯC HÀNH
Xây dựng một phuwogn thức bất đồng bộ và tải về một trang web
*************************************************************************
*/

static async Task<string> GetWeb(string url)
{
  HttpClient httpClient = new HttpClient();
  Console.WriteLine("Bat dau tai +++++++++++");
  HttpResponseMessage kq = await httpClient.GetAsync(url);
  Console.WriteLine("Bat dau doc noi dung +++++++++++");
  string content = await kq.Content.ReadAsStringAsync();
  Console.WriteLine("Hoan thanh doc noi dung +++++++++++");

  return content;
}


var task = GetWeb("https://xuanthulab.net");
var content = await task;
Console.WriteLine(content);
