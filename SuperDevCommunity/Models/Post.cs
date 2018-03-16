using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Content")]
        public string content { get; set; }

        // Foreing Key
        public int user_id { get; set; }
        public User user { get; set; }

        public DateTime created_at { get; set; }

        public Post()
        {
            created_at = DateTime.Now;
        }
    }
}