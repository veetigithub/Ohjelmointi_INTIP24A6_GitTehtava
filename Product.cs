using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varasto
{
    class Product
    {
        public int ProdID { get; set; }
        public string? ProdName { get; set; }
        public string? ProdType { get; set; }
        public string? ProdMaker { get; set; }
        public double ProdPrice { get; set; }
        public int ProdAmount { get; set; }
    }
}
