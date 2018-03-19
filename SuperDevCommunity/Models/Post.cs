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
        public int userid { get; set; }
        public User user { get; set; }

        public DateTime createdat { get; set; }

        public Post()
        {
            createdat = DateTime.Now;
        }
    }
}