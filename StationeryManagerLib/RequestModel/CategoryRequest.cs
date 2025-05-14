using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class CategoryRequest
    {
        [Required(ErrorMessage ="{0} là bắt buộc")]
        [Display(Name = "Tên danh mục phân loại")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }

}
