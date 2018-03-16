using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class CommentLike
    {
        [Key]
        public int key { get; set; }

        // Foreign Key
        public int user_id { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int comment_id { get; set; }
        public Comment comment { get; set; }

        public DateTime created_at { get; set; }

        public CommentLike()
        {
            created_at = DateTime.Now;
        }
    }
}