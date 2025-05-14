using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Enum;

namespace StationeryManagerLib.RequestModel
{
    public class InventoryTransactionRequest
    {
        
        [Required]
        public string WarehouseId { get; set; }
        public string? Note { get; set; }
        
        [Required]
        public TransactionTypeEnum TransactionType { get; set; }

        [Required]
        public List<InventoryItemRequest> Items { get; set; }

    }

    public class InventoryItemRequest
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        public double Quantity { get; set; }
        public string? ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
