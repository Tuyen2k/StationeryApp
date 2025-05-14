using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.ResultDataDb
{
    public class ProductItemStock
    {
        public string ProductId { get; set; }
        public double Stock { get; set; }
        public double ImportQuantity { get; set; }
        public double ExportQuantity { get; set; }
    }
}
