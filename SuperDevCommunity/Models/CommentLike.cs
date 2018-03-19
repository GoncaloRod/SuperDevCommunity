using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class CommentLike
    {
        [Key]
        public int key { get; set; }

        // Foreign Key
        public int userid { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int commentid { get; set; }
        public Comment comment { get; set; }

        public DateTime createdat { get; set; }

        public CommentLike()
        {
            createdat = DateTime.Now;
        }
    }
}