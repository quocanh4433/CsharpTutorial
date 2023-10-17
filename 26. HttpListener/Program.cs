using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


/* 01. GIỚI THIỆU HTTPLISTENER
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
*/
// if (HttpListener.IsSupported)
// {
//   Console.WriteLine("Support HttpListener");
// }
// else
// {
//   Console.WriteLine("Not Support HttpListener");
//   throw new Exception("Not Support HttpListener");

// }

// var server = new HttpListener();
// server.Prefixes.Add("http://localhost:4444/"); // 8080, 8081 access denied. port 4444 is normal
// server.Start();

// do
// {
//   var context = await server.GetContextAsync();
//   Console.WriteLine("Client Connected");
//   var response = context.Response;

//   response.Headers.Add("content-type", "text/html");

//   var outputStream = response.OutputStream; // Stream viết dữ liệu và client sẽ nhận được

//   var html = "<h1>Hello World</h1>";

//   var bytes = Encoding.UTF8.GetBytes(html); // Convert string to byte

//   await outputStream.WriteAsync(bytes, 0, bytes.Length);

//   outputStream.Close();


// } while (server.IsListening);











/* 02. XÂY DỰNG HTTP SERVER ĐƠN GIẢN 
--------------------------------------------------------------------------------
--------------------------------------------------------------------------------
*/

var server = new MyHttpServer(new string[] { "http://localhost:4444/" });
await server.Start();


class MyHttpServer
{
  private HttpListener listener;

  public MyHttpServer(string[] prefixes)
  {
    if (!HttpListener.IsSupported)
    {
      throw new Exception("HttpListener Not Support HttpListener");

    }
    listener = new HttpListener();
  }

  public async Task Start()
  {

    // Khởi chạy listener
    listener.Start();
    Console.WriteLine("Http server start");

    // Chấp nhận các client kết nối đến
    do
    {
      Console.WriteLine(DateTime.Now.ToLongTimeString() + " Waiting Client");
      var context = await listener.GetContextAsync();

      ProccessRequest(context);

      Console.WriteLine(DateTime.Now.ToLongTimeString() + "Client connected");
    } while (listener.IsListening);
  }

  public async Task ProccessRequest(HttpListenerContext context)
  {
    HttpListenerRequest request = context.Request;
    HttpListenerResponse response = context.Response;

    Console.WriteLine($"{request.HttpMethod} - {request.RawUrl} - {request.Url.AbsolutePath}");

    var outputStream = response.OutputStream; // Stream viết dữ liệu và client sẽ nhận được

    switch (request.Url.AbsolutePath)
    {
      case "/":
        {
          var buffer = Encoding.UTF8.GetBytes("Xin chao cac ban"); // Convert string to byte
          response.ContentLength64 = buffer.Length;
          await outputStream.WriteAsync(buffer, 0, buffer.Length);
        }
        break;

      case "/json":
        {
          response.Headers.Add("Content-Type", "application/json");
          var product = new
          {
            Name = "Macbook",
            Price = 2000
          };

          var json = JsonConvert.SerializeObject(product);
          var buffer = Encoding.UTF8.GetBytes(json); // Convert string to byte
          response.ContentLength64 = buffer.Length;
          await outputStream.WriteAsync(buffer, 0, buffer.Length);

        }
        break;


      case "/anh2.png":
        {
          response.Headers.Add("Content-Type", "image/png");

          var buffer = await File.ReadAllBytesAsync("2.png");
          response.ContentLength64 = buffer.Length;
          await outputStream.WriteAsync(buffer, 0, buffer.Length);

        }
        break;

      default:
        {
          response.StatusCode = (int)HttpStatusCode.NotFound;
          var buffer = Encoding.UTF8.GetBytes("NOT FOUND ================="); // Convert string to byte
          response.ContentLength64 = buffer.Length;
          await outputStream.WriteAsync(buffer, 0, buffer.Length);
        }
        break;
    }

    outputStream.Close();
  }

}

