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
            Post newPost = new Post("lalalalallala", "Damian");
            Comment coment1 = new Comment("fajny", "bardzo fajny post", "zbychu", 9);
            Comment coment2 = new Comment("polecam", "polecam Allegrowicza", "Rudy102", 9);

            var repository = new BlogRepository();

            //repository.SavePost(newPost);
            //repository.SaveComment(coment1);
            //repository.SaveComment(coment2);
        }
        [TestMethod]
        public void IsDatabaseExist()
        {
            var context = new BlogContext();
            var result = context.Database.Exists();
            Assert.IsTrue(result);
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
            var result = coments.Where(x => x.PostId == 9);
            // assert
            Assert.AreEqual(2, result.Count());
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
    }
}
