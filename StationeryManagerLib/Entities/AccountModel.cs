using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Model;

namespace StationeryManagerLib.Entities
{
    
    public class AccountModel : BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string PaswordHash { get; set; }
        
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
