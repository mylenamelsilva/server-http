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
                "http://localhost:8080/product/"
            };
            string json;

            HttpListener listener = new HttpListener();
            
            foreach(string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            listener.Start();

            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest req = context.Request;
            string method = req.HttpMethod.ToString();
            HttpListenerResponse response = context.Response;

            if (method == "GET")
            {
                var result = _controller.GetResponse<List<ProductModel>>(method, null);
                json = JsonSerializer.Serialize(result);
                ProcessResponse(json, response);
            } else
            {
                Stream body = req.InputStream;
                var reader = new StreamReader(body, req.ContentEncoding);
                var content = reader.ReadToEnd();
                var result = _controller.GetResponse<bool>(method, content);
                ProcessResponse(Convert.ToString(result), response);
            }
        }

        private static void ProcessResponse(string json, HttpListenerResponse response)
        {
            response.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
    }
}