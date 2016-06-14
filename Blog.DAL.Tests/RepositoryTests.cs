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

            // -- prepare data in db
            context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
            context.Posts.Add(new Post
            {
                Author = "NewUSER",
                Content = "test2, test2, test2..."
            });

            context.Posts.Add(new Post { Author = "MAX", Content = "TestContent", Id=3 });
            context.Comments.Add(new Comment { Author = "max", Content = "cos fajnego", Id = 1, PostId = 3, Title = "New Comm" });

            context.Posts.Add(new Post { Author = "Maksym", Content = "TestContent2", Id = 4 });
            context.Comments.Add(new Comment { Author = "Mirek", Content = "Bardzo fajny i ciekawy post, polecam", Id = 41, PostId = 4, Title = "New Comm2" });
            context.Comments.Add(new Comment { Author = "Krzycho", Content = "Polecam ten post", Id = 42, PostId = 4, Title = "Podpinam sie" });

            context.SaveChanges();
        }

            //initialize data
            /*
            Post newPost = new Post("This is the Fine POST", "Maksym Awdiejew");
            Comment coment1 = new Comment("FINE POSTE", "Bardzo fajny i ciekawy post, polecam", "Krzysztof", 9);
            Comment coment2 = new Comment("Podpinam sie", "Polecam ten post", "Krzycho", 9);

            var repository = new BlogRepository();

            repository.SavePost(newPost);
            repository.SaveComment(coment1);
            repository.SaveComment(coment2);
        }*/

        [TestMethod]
        public void IsDatabaseExist()
        {
            var context = new BlogContext();
            var result = context.Database.Exists();
            Assert.IsTrue(result);
        }

       /* [TestMethod]
        public void DataBaseIsEmpty()
        {
            var context = new BlogContext();
            Assert.IsNull(context);
        }*/
        //
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(3, result.Count());
        }
        
        [TestMethod]
        public void GetSpecificPostById()
        {
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            var post = result.Where(x => x.Id == 1);
            // assert
            Assert.AreEqual(0, post.Count());
        }
        
        [TestMethod]
        public void GetCommentsAssingToSpecificPost()
        {
            var repository = new BlogRepository();
            // act
            var coments = repository.GetAllComments();
            var result = coments.Where(x => x.PostId == 4);
            // assert
            Assert.AreNotEqual(2, result.Count());
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
