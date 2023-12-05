using Server.Controller;
using Server.Model;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Server
{
    public class Program
    {
        private static ProductController _controller = new();
        static void Main(string[] args)
        {
            string[] prefixes = 
            { 
                "http://localhost:8080/products/",
                "http://localhost:8080/product/",
                "http://localhost:8080/product/",
                "http://localhost:8080/produt/" 
            };


            HttpListener listener = new HttpListener();
            
            foreach(string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest req = context.Request;
            string method = req.HttpMethod.ToString();

            var result = _controller.GetResponse<List<ProductModel>>(method);
            var json = JsonSerializer.Serialize(result);

            HttpListenerResponse response = context.Response;
            response.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
    }
}