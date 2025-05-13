using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationeryManagerLib.RequestModel
{
    public class CreateAccountRequest : UpdateAccountRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class UpdateAccountRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Phone { get; set; }

    }

}
