using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varasto
{
    internal class Product
    {
        public int prodID { get; set; }
        public string prodName { get; set; }
        public string prodType { get; set; }
        public string prodMaker { get; set; }
        public decimal prodPrice { get; set; }
        public int prodAmount { get; set; }
        public string prodSafety { get; set; }
    }
}
