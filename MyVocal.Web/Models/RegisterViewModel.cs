using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyVocal.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu.")]
        [MinLength(6,ErrorMessage ="Mật khẩu phải ít nhất 6 ký tự.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập số địa chỉ email.")]
        [EmailAddress(ErrorMessage ="Địa chỉ email không đúng.")]
        public string Email { get; set; }

    }
}