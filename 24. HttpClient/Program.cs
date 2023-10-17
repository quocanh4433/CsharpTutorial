using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.IO;

// NỘI DUNG BÀI HỌC DỰA VÀO
// https://www.youtube.com/watch?v=iJlAMzFy4yQ&list=PLwJr0JSP7i8BERdErX9Ird67xTflZkxb-&index=34



/* 01. HTTPCLIENT
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------*/


// --- Đọc nội dung trang web
// var html = await GetWebContent("https://xuanthulab.net/");
// Console.WriteLine(html);



// --- Lưu hinh ảnh cach 1
// var bytes = await DownloadDataByte("https://deviet.vn/wp-content/uploads/2019/04/vuong-quoc-anh.jpg");
// string fileName = "i.png";
// using var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
// stream.Write(bytes, 0, bytes.Length);


// --- Luu hinh anh cach 2
// var url = "https://deviet.vn/wp-content/uploads/2019/04/vuong-quoc-anh.jpg";
// await DownloadStream(url, "ii.png");




// --- Phương thức hỗ trợ tốt hơn GetAsync()
// using HttpClient httpCLient = new HttpClient();
// var httpRequestMessage = new HttpRequestMessage();

// httpRequestMessage.Method = HttpMethod.Post;
// httpRequestMessage.RequestUri = new Uri("https://xuanthulab.net/");
// httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

// HttpResponseMessage httpResponseMessage = await httpCLient.SendAsync(httpRequestMessage);
// var html = await httpResponseMessage.Content.ReadAsStringAsync();
// Console.WriteLine(html);



// --- Thực hành method POST: Mô phỏng gửi dữ liệu form
/*
key1 -> value1                    [INPUT]
key2 -> [value2-1, value2-2]      [MULTI SELECT]
*/

using HttpClient httpCLient = new HttpClient();
var httpRequestMessage = new HttpRequestMessage();

httpRequestMessage.Method = HttpMethod.Post;
httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");
httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");






// Trường hơp form
// var parameters = new List<KeyValuePair<string, string>>();
// parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
// parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
// parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
// var content = new FormUrlEncodedContent(parameters);



// Trường hợp có file + form json
var content = new MultipartFormDataContent();
Stream fileStream = File.OpenRead("1.txt");
var fileUpload = new StreamContent(fileStream);
content.Add(fileUpload, "tttt", "abc.xyz");
content.Add(new StringContent("value1"), "key1");




httpRequestMessage.Content = content;

HttpResponseMessage httpResponseMessage = await httpCLient.SendAsync(httpRequestMessage);
var html = await httpResponseMessage.Content.ReadAsStringAsync();
Console.WriteLine(html);




/* 02. URI 
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------*/

// Mặc định http -> port: 80, https -> 443

// string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";

// var uri = new Uri(url);

// var uritype = typeof(Uri); // Hoặc uri.GetType()
// uritype.GetProperties().ToList().ForEach(property =>
// {
//   Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
// });
// Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");





/* 03. DNS
Một tên miền có thể có nhiều IP
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------*/

// var hostmane = Dns.GetHostName();
// Console.WriteLine(hostmane);


// // var url = "https://xuanthulab.net";
// var url = "https://www.bootstrapcdn.com/";
// var uri = new Uri(url);

// Console.WriteLine(uri.Host);
// var ipHostEntry = Dns.GetHostEntry(uri.Host);

// ipHostEntry.AddressList.ToList().ForEach(ip =>
// {
//   Console.WriteLine(ip);
// });



/* 04. PING
Kiêm tra địa chị IP còn sống hay không?
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------*/

// var ping = new Ping();
// var pingReply = ping.Send("google.com.vn");
// Console.WriteLine(pingReply.Status);
// if (pingReply.Status == IPStatus.Success)
// {
//   Console.WriteLine(pingReply.RoundtripTime); // Thời gian phản hồi
//   Console.WriteLine(pingReply.Address); // Địa chỉ phản hồi
// }








//*************************************************************

static async Task<string> GetWebContent(string url)
{
  using var httpCLient = new HttpClient();

  try
  {
    // Thêm Header
    httpCLient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

    HttpResponseMessage httpResponseMessage = await httpCLient.GetAsync(url);
    string html = await httpResponseMessage.Content.ReadAsStringAsync();
    ShowHeader(httpResponseMessage.Headers);
    return html;
  }
  catch (System.Exception e)
  {
    Console.WriteLine(e.Message);
    throw new Exception("Xay ra loi !!!!!!!");
  }
}


static async Task<byte[]> DownloadDataByte(string url)
{
  using var httpCLient = new HttpClient();

  try
  {
    // Thêm Header
    httpCLient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

    HttpResponseMessage httpResponseMessage = await httpCLient.GetAsync(url);
    var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
    ShowHeader(httpResponseMessage.Headers);
    return bytes;
  }
  catch (System.Exception e)
  {
    Console.WriteLine(e.Message);
    throw new Exception("Xay ra loi !!!!!!!");
    return null;
  }
}


static async Task DownloadStream(string url, string fileName)
{
  using var httpCLient = new HttpClient();

  try
  {
    HttpResponseMessage httpResponseMessage = await httpCLient.GetAsync(url);

    using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
    using var streamWrite = File.OpenWrite(fileName);


    int SIZEBUFFER = 500;
    var buffer = new byte[SIZEBUFFER];


    bool eandREad = false;
    do
    {
      int numberByte = await stream.ReadAsync(buffer, 0, SIZEBUFFER);

      if (numberByte == 0)
      {
        eandREad = true;
      }
      else
      {
        await streamWrite.WriteAsync(buffer, 0, numberByte);
      }

    } while (!eandREad);

  }
  catch (System.Exception e)
  {
    Console.WriteLine(e.Message);
    throw new Exception("Xay ra loi !!!!!!!");
  }
}



static void ShowHeader(HttpResponseHeaders headers)
{
  Console.WriteLine("CAC HEADER ======================================================");
  foreach (var header in headers)
  {
    Console.WriteLine($"{header.Key} - {header.Value}");
  }

  Console.WriteLine("CAC HEADER ======================================================");

}





