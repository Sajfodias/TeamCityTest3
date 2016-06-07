using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.DAL.Model;
using TDD.DbTestHelpers.Yaml;

namespace Blog.DAL.Tests
{
    public class BlogFixturesModel
    {
        public FixtureTable<Post>Posts{get;set;}
    }
}
