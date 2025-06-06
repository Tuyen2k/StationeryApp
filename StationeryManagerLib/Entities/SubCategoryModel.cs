﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Model;

namespace StationeryManagerLib.Entities
{
    public class SubCategoryModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string CategoryId { get; set; }
    }
}
