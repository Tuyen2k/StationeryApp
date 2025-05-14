using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class WarehouseRequest
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [Display(Name = "Tên kho hàng")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Location { get; set; }
    }
}
