using System.Net;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] prefixes = 
            { 
                "http://localhost:8080/get/products/",
                "http://localhost:8080/post/product/",
                "http://localhost:8080/put/product/",
                "http://localhost:8080/delete/produt/" 
            };


            HttpListener listener = new HttpListener();
            
            foreach(string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            listener.Start();
        }
    }
}