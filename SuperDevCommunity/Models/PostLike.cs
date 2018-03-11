using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class PostLike
    {
        [Key]
        public int id { get; set; }

        // Foreign Key
        public int user_id { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int post_id { get; set; }
        public Post post { get; set; }

        public DateTime created_at { get; set; }
    }
}