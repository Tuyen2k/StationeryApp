using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class ProductRequest
    {
        [Required(ErrorMessage ="{0} là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Danh mục sản phẩm")]
        public string SubCategoryId { get; set; }

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Giá nhập sản phẩm")]
        public double Price { get; set; } = 0;

        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Giá bán sản phẩm")]
        public double PriceSale { get; set; } = 0;

        [Display(Name = "Mã sản phẩm")]
        public string? Sku { get; set; }
    }

    //public class CreateProductRequest : UpdateProductRequest
    //{

    //}

    //public class UpdateProductRequest
    //{
    //    [Required]
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string? ImageUrl { get; set; }

    //    [Required]
    //    public string SubCategoryId { get; set; }
    //    public double Price { get; set; }
    //}
}
