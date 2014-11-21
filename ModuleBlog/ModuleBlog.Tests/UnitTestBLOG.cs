using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL.Models;
using System.Collections.Generic;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestBlog
    {
        /// <summary>
        /// The blog dal
        /// </summary>
        private ModuleBlog.DAL.BlogDAL blogDAL;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            blogDAL = new ModuleBlog.DAL.BlogDAL();
            // on vérifie que l'instance n'est pas nulle
            Assert.IsNotNull(blogDAL);
        }

        /// <summary>
        /// Tests the get blogs.
        /// </summary>
        [TestMethod]
        public void TestGetBlogs()
        {
            List<Blog> blogList;
            blogList = blogDAL.GetBlogs();

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");
        }

        /// <summary>
        /// Tests the get blogs by category.
        /// </summary>
        [TestMethod]
        public void TestGetBlogsByCategory()
        {
            List<Blog> blogList;
            blogList = blogDAL.GetBlogsByCategory(3);

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");

            foreach (Blog b in blogList)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
            }

        }

        /// <summary>
        /// Tests the get blogs by search.
        /// </summary>
        [TestMethod]
        public void TestGetBlogsBySearch()
        {
            List<Blog> blogList1, blogList2, blogList3;
            blogList1 = blogDAL.GetBlogsBySearch(3, "Test");
            blogList2 = blogDAL.GetBlogsBySearch(0, "Test");
            blogList3 = blogDAL.GetBlogsBySearch(3, string.Empty);


            Assert.IsNotNull(blogList1);
            Assert.IsTrue(blogList1.Count > 0, "Liste 1 est vide");
            foreach (Blog b in blogList1)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
                Assert.IsTrue(b.TitreBlog.ToLower().Contains(("Test").ToLower()));
            }


            Assert.IsNotNull(blogList2);
            Assert.IsTrue(blogList1.Count > 0, "Liste 1 est vide");
            foreach (Blog b in blogList1)
            {
                Assert.IsTrue(b.TitreBlog.ToLower().Contains(("Test").ToLower()));
            }

            Assert.IsNotNull(blogList3);
            Assert.IsTrue(blogList3.Count > 0, "Liste des blogs vide");

            foreach (Blog b in blogList3)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
            }
        }

        /// <summary>
        /// Tests the get promoted blogs.
        /// </summary>
        [TestMethod]
        public void TestGetPromotedBlogs()
        {
            List<Blog> blogList;
            blogList = blogDAL.GetPromotedBlogs();

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");

            foreach (Blog b in blogList)
            {
                Assert.IsTrue(b.Promotion == true, "Le Blog n'est pas promu");
            }
        }

        /// <summary>
        /// Tests the add blog.
        /// </summary>
        [TestMethod]
        public void TestAddBlog()
        {
            //Utilisateur_id 119 à 127 n'ont pas de plog on peut les utiliser pour les test
            Assert.IsTrue(blogDAL.AddBlog(new Blog { Utilisateur_id = 120, TitreBlog = "Blog de l'utilisateur Test", Categorie_id = 3, Theme_id = 4 }), "Blog existe déjà");
        }


        /// <summary>
        /// Tests the update blog.
        /// </summary>
        [TestMethod]
        public void TestUpdateBlog()
        {
            Assert.IsTrue(blogDAL.UpdateBlog(new Blog { Blog_id = 12, Utilisateur_id = 25, TitreBlog = "Blog de l'utilisateur Test", Categorie_id = 3, Promotion = false, Actif = true, Theme_id = 3, DateCreation = DateTime.Now }), "Blog non modifié");
        }
    }
}
