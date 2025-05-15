using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Entities;
using StationeryManagerLib.Enum;

namespace StationeryManagerLib.Dtos
{
    public class HistoryProductInTransaction : InventoryTransactionModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
    }
}
