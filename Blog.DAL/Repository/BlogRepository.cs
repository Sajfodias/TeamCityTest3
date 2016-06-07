﻿using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public int SavePost(Post post)
        {
            _context.Posts.Add(post);
            return _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public int SaveComment(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges();
        }
    }
}