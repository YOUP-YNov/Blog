using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL.Models;
using System.Collections.Generic;
using ModuleBlog.DAL;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestBLOG
    {
        private BLOG_DAL blogDAL;

        [TestInitialize]
        public void Init()
        {
            blogDAL = new BLOG_DAL();
            // on vérifie que l'instance n'est pas nulle
            Assert.IsNotNull(blogDAL);
        }

        [TestMethod]
        public void TestGetBlogs()
        {
            List<BlogDao> blogList;
            blogList = blogDAL.GetBlogs();

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");
        }

        [TestMethod]
        public void TestGetBlogsByCategory()
        {
            List<BlogDao> blogList;
            blogList = blogDAL.GetBlogsByCategory(3);

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");

            foreach (BlogDao b in blogList)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
            }

        }

        [TestMethod]
        public void TestGetBlogsBySearch()
        {
            List<BlogDao> blogList1, blogList2, blogList3;
            blogList1 = blogDAL.GetBlogsBySearch(3, "Test");
            blogList2 = blogDAL.GetBlogsBySearch(0, "Test");
            blogList3 = blogDAL.GetBlogsBySearch(3, string.Empty);


            Assert.IsNotNull(blogList1);
            Assert.IsTrue(blogList1.Count > 0, "Liste 1 est vide");
            foreach (BlogDao b in blogList1)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
                Assert.IsTrue(b.TitreBlog.ToLower().Contains(("Test").ToLower()));
            }


            Assert.IsNotNull(blogList2);
            Assert.IsTrue(blogList1.Count > 0, "Liste 1 est vide");
            foreach (BlogDao b in blogList1)
            {
                Assert.IsTrue(b.TitreBlog.ToLower().Contains(("Test").ToLower()));
            }

            Assert.IsNotNull(blogList3);
            Assert.IsTrue(blogList3.Count > 0, "Liste des blogs vide");

            foreach (BlogDao b in blogList3)
            {
                Assert.IsTrue(b.Categorie_id == 3, "La catégorie du blog ne correspond pas à la catégorie définie");
            }
        }

        [TestMethod]
        public void TestGetPromotedBlogs()
        {
            List<BlogDao> blogList;
            blogList = blogDAL.GetPromotedBlogs();

            Assert.IsNotNull(blogList);
            Assert.IsTrue(blogList.Count > 0, "Liste des blogs vide");

            foreach (BlogDao b in blogList)
            {
                Assert.IsTrue(b.Promotion == true, "Le Blog n'est pas promu");
            }
        }

        [TestMethod]
        public void TestAddBlog()
        {
            //Utilisateur_id 119 à 127 n'ont pas de plog on peut les utiliser pour les test
            Assert.IsTrue(blogDAL.AddBlog(new BlogDao { Utilisateur_id = 118, TitreBlog = "Blog de l'utilisateur Test", Categorie_id = 3, Promotion = false, Actif = true, Theme_id = 4 }) == "OK", "Blog existe déjà");
        }


        [TestMethod]
        public void TestUpdateBlog()
        {
            Assert.IsTrue(blogDAL.UpdateBlog(new BlogDao { Blog_id = 12, Utilisateur_id = 25, TitreBlog = "Blog de l'utilisateur Test", Categorie_id = 3, Promotion = false, Actif = true, Theme_id = 3, DateCreation = DateTime.Now }) == "OK", "Blog non modifié");
        }
    }
}
