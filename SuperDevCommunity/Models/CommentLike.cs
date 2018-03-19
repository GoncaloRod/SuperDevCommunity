using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class CommentLike
    {
        [Key]
        public int key { get; set; }

        // Foreign Key
        public int userId { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int commentId { get; set; }
        public Comment comment { get; set; }

        public DateTime createdAt { get; set; }

        public CommentLike()
        {
            createdAt = DateTime.Now;
        }
    }
}