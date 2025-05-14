using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationeryManagerLib.Util.Validate;

namespace StationeryManagerLib.RequestModel
{
    public class CreateAccountRequest : UpdateAccountRequest
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Mật khẩu")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&^#()[\\]{}|\\\\/\\-+_.:;=,~`])[^\\s<>]{8,20}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất 1 ký tự viết hoa, 1 chữ số, 1 ký tự đặc biệt và có độ dài từ 8 đến 20 ký tự, không chứa khoảng trắng và các ký tự ['>','<'].")]
        [NoVietnamese(ErrorMessage ="{0} không được chứa ký tự Tiếng Việt")]
        public string Password { get; set; }
    }

    public class UpdateAccountRequest
    {
        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Tên tài khoản")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        public string Name { get; set; }


        [Required(ErrorMessage = "{0} là bắt buộc")]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} có độ dài từ {2} đến {1} ký tự")]
        [EmailAddress(ErrorMessage = "{0} không hợp lệ")]
        public string Email { get; set; }


        [Display(Name = "Số điện thoại")]
        [RegularExpression("^(?:\\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-9])[0-9]{7}$",
            ErrorMessage ="{0} không hợp lệ")]
        public string? Phone { get; set; }

    }

}
