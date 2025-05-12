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
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
    }
}
