using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Util.Validate;

namespace StationeryManagerLib.RequestModel
{
    public class AuthRequest
    {
    }

    public class LoginRequestModel
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Mật khẩu")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&^#()[\\]{}|\\\\/\\-+_.:;=,~`])[^\\s<>]{8,20}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất 1 ký tự viết hoa, 1 chữ số, 1 ký tự đặc biệt và có độ dài từ 8 đến 20 ký tự, không chứa khoảng trắng và các ký tự ['>','<'].")]
        [NoVietnamese(ErrorMessage = "{0} không được chứa ký tự Tiếng Việt")]
        public string Password { get; set; }
    }

}
