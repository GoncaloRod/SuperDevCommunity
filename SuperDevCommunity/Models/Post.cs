using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class Post
    {
        private SuperDevCommunityContext db = new SuperDevCommunityContext();

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Content")]
        public string content { get; set; }

        public int likes { get; set; }

        // Foreing Key
        public int userId { get; set; }
        public User user { get; set; }

        public DateTime createdAt { get; set; }

    }
}