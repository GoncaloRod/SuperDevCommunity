using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class CommentAnswer
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Content")]
        public string content { get; set; }

        // Foreign Key
        public int user_id { get; set; }
        public int user { get; set; }

        // Foreign Key
        public int comment_id { get; set; }
        public Comment comment { get; set; }

        public DateTime created_at { get; set; }
    }
}