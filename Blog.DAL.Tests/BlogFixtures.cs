using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.DAL.Infrastructure;
using TDD.DbTestHelpers.Yaml;

namespace Blog.DAL.Tests
{
    public class BlogFixtures :YamlDbFixture<BlogContext,BlogFixturesModel>
    {
        public
        BlogFixtures()
        {
            SetYamlFiles(
            "posts.yml"
            );
        }
    }
}
