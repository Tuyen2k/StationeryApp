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
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string SubCategoryId { get; set; }
        public double Price { get; set; }
    }
}
