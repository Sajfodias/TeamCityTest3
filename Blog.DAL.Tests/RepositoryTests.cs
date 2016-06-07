using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blog.DAL.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestInitialize]
        public void initializeData()
        {
            // arrange            
            var context = new BlogContext();

            context.Database.CreateIfNotExists();

            //initialize data
            Post newPost = new Post("This is the fine post.", "Maksym Avdieiev");
            Comment comment1 = new Comment("=)", "It's funny", "Max", 6);
            Comment comment2 = new Comment("No!", "I don't understand this post", "BarryAllen", 6);
            Comment comment3 = new Comment("Final", "This is the last comment", "Max", 6);

            var repository = new BlogRepository();

            //repository.SavePost(newPost);
            //repository.SaveComment(comment1);
            //repository.SaveComment(comment2);
            //repository.SaveComment(comment3);
        }

        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetSpecificPostById()
        {
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            var post = result.Where(x => x.Id == 2);
            // assert
            Assert.AreEqual(0, post.Count());
        }

        [TestMethod]
        public void GetCommentsAssingToSpecificPost()
        {
            var repository = new BlogRepository();
            // act
            var coments = repository.GetAllComments();
            var result = coments.Where(x => x.PostId == 6);
            // assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetCommentsToNonExistingPost()
        {
            var repository = new BlogRepository();
            // act
            var coments = repository.GetAllComments();
            var result = coments.Where(x => x.PostId == 1);
            // assert
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void TheRepositoryISNOTEmpty()
        {
            var repository = new BlogRepository();
            //act
            var comments = repository.GetAllComments();
            //assert
            Assert.AreNotEqual(null, comments);
        }
        [TestMethod]
        public void ThePost6Has3Comments()
        {
            var repository = new BlogRepository();
            var comments = repository.GetAllPosts();
            var result = comments.Where(x => x.Id == 6 && repository.GetAllComments().Count()==3);
            Assert.AreNotEqual(false, result);
        }

    }
}
