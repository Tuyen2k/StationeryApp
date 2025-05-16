using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Model;

namespace StationeryManagerLib.Entities
{
    public class ProductModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string SubCategoryId { get; set; }

        /// <summary>
        /// Giá nhập
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Giá bán
        /// </summary>
        public double PriceSale { get; set; } = 0;

        [Required]
        public string Sku { get; set; }
    }
}
