using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class ProductModel
    {  
        public string Id { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }

    public class ProductParams
    {
        public string Product { get; set; }
        public double Price { get; set; }
    }
}
