using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class PostLike
    {
        [Key]
        public int id { get; set; }

        // Foreign Key
        public int userid { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int postid { get; set; }
        public Post post { get; set; }

        public DateTime createdat { get; set; }

        public PostLike()
        {
            createdat = DateTime.Now;
        }
    }
}