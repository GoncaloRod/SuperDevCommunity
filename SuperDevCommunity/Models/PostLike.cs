using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class PostLike
    {
        [Key]
        public int id { get; set; }

        // Foreign Key
        public int userId { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int postId { get; set; }
        public Post post { get; set; }

        public DateTime createdAt { get; set; }
    }
}