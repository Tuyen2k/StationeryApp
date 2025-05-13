using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Enum;

namespace StationeryManagerLib.RequestModel
{
    public class FilterModel
    {
        //public string? Id { get; set; } = "";
        public string? Name { get; set; } = "";
        public int? Limit { get; set; } = 10;
        public int? Page { get; set; } = 0;
    }

    public class InventoryTransactionFilterModel : FilterModel
    {
        public string? Id { get; set; } = "";
        public string? TransactionType { get; set; } = "";
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ProductId { get; set; } = "";
    }

    public class InventoryItemFilterModel
    {
        public string? InventoryTransactionId { get; set; } = "";
        public string? ProductId { get; set; } = "";
        public string? ProductName { get; set; } = "";
    }
}
