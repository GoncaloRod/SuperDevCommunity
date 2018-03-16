using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Content")]
        public string content { get; set; }

        // Foreing Key
        public int user_id { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int post_id { get; set; }
        public Post post { get; set; }

        public DateTime created_at { get; set; }

        public Comment()
        {
            created_at = DateTime.Now;
        }
    }
}