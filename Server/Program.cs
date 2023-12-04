using Server.Controller;
using Server.Model;
using System.Net;

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

            _controller.GetResponse<ProductModel>(method);
        }
    }
}