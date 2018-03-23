using System;
using System.Collections;
using System.Collections.Generic;
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

        [Required(ErrorMessage = "This filed is required!")]
        [Compare("password", ErrorMessage = "Passwords does not match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Retry Password")]
        public string retryPassword { get; set; }

        public string profilePic { get; set; }

        public DateTime createdAt { get; set; }

        // Relationed tables
        public ICollection<Post> posts { get; set; }
        public ICollection<PostLike> postLikes { get; set; }
        public ICollection<Comment> comments { get; set; }
        public ICollection<CommentLike> commentLikes { get; set; }
    }
}