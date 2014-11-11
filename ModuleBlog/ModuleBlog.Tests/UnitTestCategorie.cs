using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.DAL.Models;
using ModuleBlog.BLL.Models;
using ModuleBlog.BLL;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestCategorie
    {
        private CategorieDAL categoryDal;
        private CategorieBLL categoryBll;

        [TestInitialize]
        public void Init()
        {
            categoryDal = new CategorieDAL();
            Assert.IsNotNull(categoryDal);

            categoryBll = new CategorieBLL();
            Assert.IsNotNull(categoryBll);
        }

        [TestMethod]
        public void TestLectureCategoriesDAL()
        {
            List<ModuleBlog.DAL.Models.Categorie> categoryList;
            categoryList = categoryDal.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }

        [TestMethod]
        public void TestLectureCategoriesBLL()
        {
            List<ModuleBlog.BLL.Models.Categorie> categoryList;
            categoryList = categoryBll.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }
    }
}
