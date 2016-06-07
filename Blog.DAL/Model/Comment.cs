using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Blog.DAL.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public long PostId { get; set; }

        public Comment()
        {
        }

        public Comment(string title, string content, string author, long post)
        {
            this.Author = author;
            this.Content = content;
            this.PostId = post;
            this.Title = title;
        }
    }
}
