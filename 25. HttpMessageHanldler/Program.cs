using System.Net;
using System.Text;


/* 01. SOCKETHTTPHANDLER - COOKIECONTAINER
*/

// var cookies = new CookieContainer();
// string url = "https://postman-echo.com/post";

// using var hanlder = new SocketsHttpHandler();
// hanlder.AllowAutoRedirect = true; // Chuyển sang URL mới
// hanlder.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate; // Cho phép giải nén các định dạng
// hanlder.UseCookies = true;
// hanlder.CookieContainer = cookies;


// using HttpClient httpCLient = new HttpClient(hanlder);



// var httpRequestMessage = new HttpRequestMessage();

// httpRequestMessage.Method = HttpMethod.Post;
// httpRequestMessage.RequestUri = new Uri(url);
// httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");


// var parameters = new List<KeyValuePair<string, string>>();
// parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
// parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
// parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
// var content = new FormUrlEncodedContent(parameters);


// httpRequestMessage.Content = content;
// HttpResponseMessage response = await httpCLient.SendAsync(httpRequestMessage);
// cookies.GetCookies(new Uri(url)).ToList().ForEach(c =>
// {
//   Console.WriteLine($"COOKIE ========== {c.Name} - {c.Value}");
// });

// var html = await response.Content.ReadAsStringAsync();
// Console.WriteLine(html);




/* 02. DELEGATINGHANDLER */

var cookies = new CookieContainer();
string url = "https://postman-echo.com/post";

// Tạo chuỗi handler()
var bottomHandler = new MyHttpClientHandler(cookies);
var chagngeUriHandler = new ChangeUri(bottomHandler);
var denyAccessFacebook = new DenyAccessFacebook(chagngeUriHandler);

using HttpClient httpCLient = new HttpClient(denyAccessFacebook);

var httpRequestMessage = new HttpRequestMessage();

httpRequestMessage.Method = HttpMethod.Post;
httpRequestMessage.RequestUri = new Uri(url);
httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");



var parameters = new List<KeyValuePair<string, string>>();
parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));
var content = new FormUrlEncodedContent(parameters);


HttpResponseMessage response = await httpCLient.SendAsync(httpRequestMessage);
var html = await response.Content.ReadAsStringAsync();
Console.WriteLine(html);




//*******************************************************************************
public class MyHttpClientHandler : HttpClientHandler
{
  public MyHttpClientHandler(CookieContainer cookie_container)
  {

    CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
    AllowAutoRedirect = false;                // không cho tự động Redirect
    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
    UseCookies = true;
  }
  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
  {
    Console.WriteLine("Bất đầu kết nối " + request.RequestUri.ToString());
    // Thực hiện truy vấn đến Server
    var response = await base.SendAsync(request, cancellationToken);
    Console.WriteLine("Hoàn thành tải dữ liệu");
    return response;
  }
}

public class ChangeUri : DelegatingHandler
{
  public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

  protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                         CancellationToken cancellationToken)
  {
    var host = request.RequestUri.Host.ToLower();
    Console.WriteLine($"Check in  ChangeUri - {host}");
    if (host.Contains("google.com"))
    {
      // Đổi địa chỉ truy cập từ google.com sang github
      request.RequestUri = new Uri("https://github.com/");
    }
    // Chuyển truy vấn cho base (thi hành InnerHandler)
    return base.SendAsync(request, cancellationToken);
  }
}


public class DenyAccessFacebook : DelegatingHandler
{
  public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
  {

    var host = request.RequestUri.Host.ToLower();
    Console.WriteLine($"Check in DenyAccessFacebook - {host}");
    if (host.Contains("facebook.com"))
    {
      var response = new HttpResponseMessage(HttpStatusCode.OK);
      response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
      return await Task.FromResult<HttpResponseMessage>(response);
    }
    // Chuyển truy vấn cho base (thi hành InnerHandler)
    return await base.SendAsync(request, cancellationToken);
  }
}