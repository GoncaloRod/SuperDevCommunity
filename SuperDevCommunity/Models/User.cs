using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(5, ErrorMessage = "Password is too short!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public string profile_pic { get; set; }

        public DateTime created_at { get; set; }
    }
}