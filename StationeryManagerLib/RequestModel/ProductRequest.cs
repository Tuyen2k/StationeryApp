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
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        [Required]
        public string SubCategoryId { get; set; }
        public double Price { get; set; } = 0;
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
