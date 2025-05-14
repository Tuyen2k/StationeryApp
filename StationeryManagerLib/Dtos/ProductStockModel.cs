using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Entities;

namespace StationeryManagerLib.Dtos
{
    public class ProductStockModel : ProductModel
    {
        public double Stock { get; set; }
        public double ImportQuantity { get; set; }
        public double ExportQuantity { get; set; }
    }

    public class ProductInventoryView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
    }
}
