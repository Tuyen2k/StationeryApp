using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class SubCategoryRequest
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [Display(Name = "Tên danh mục sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Danh mục phân loại")]
        public string CategoryId { get; set; }

    }

}
