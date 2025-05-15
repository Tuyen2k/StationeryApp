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
        
        [Required(ErrorMessage ="{0} là bắt buộc")]
        [Display(Name = "Kho hàng")]
        public string WarehouseId { get; set; }

        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
        

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Loại phiếu")]
        public TransactionTypeEnum TransactionType { get; set; }


        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Danh sách sản phẩm trong phiếu")]
        public List<InventoryItemRequest> Items { get; set; }

    }

    public class InventoryItemRequest
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Sản phẩm")]
        public string ProductId { get; set; }


        [Required(ErrorMessage ="{0} là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} phải lớn hơn {1}")]
        [Display(Name = "Số lượng")]
        public double Quantity { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string? ProductName { get; set; }

        [Display(Name = "Mã Sku")]
        public string? ProductSku { get; set; }


        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Giá")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} phải lớn hơn {1}")]
        public double Price { get; set; }
    }
}
