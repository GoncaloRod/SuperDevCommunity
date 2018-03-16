using System;
using System.ComponentModel.DataAnnotations;

namespace SuperDevCommunity.Models
{
    public class CommentAnswerLike
    {
        [Key]
        public int id { get; set; }

        // Foreing Key
        public int user_id { get; set; }
        public User user { get; set; }

        // Foreign Key
        public int comment_answer_id { get; set; }
        public CommentAnswer comment_answer { get; set; }

        public DateTime created_at { get; set; }

        public CommentAnswerLike()
        {
            created_at = DateTime.Now;
        }
    }
}