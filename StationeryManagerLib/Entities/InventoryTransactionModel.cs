using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Enum;
using StationeryManagerLib.Model;

namespace StationeryManagerLib.Entities
{
    public class InventoryTransactionModel : BaseModel
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        public string WarehouseId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Code { get; set; }
        public string? Note { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public TransactionTypeEnum TransactionType { get; set; }
    }
}
