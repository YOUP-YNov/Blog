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
        private CATEGORIE_DAL categoryDal;
        private CATEGORIE_BLL categoryBll;

        [TestInitialize]
        public void Init()
        {
            categoryDal = new CATEGORIE_DAL();
            // on vérifie que l'instance n'est pas nulle
            Assert.IsNotNull(categoryDal);

            categoryBll = new CATEGORIE_BLL();
            Assert.IsNotNull(categoryBll);
        }

        [TestMethod]
        public void TestLectureCategoriesDAL()
        {
            List<CategorieDao> categoryList;
            categoryList = categoryDal.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }

        [TestMethod]
        public void TestLectureCategoriesBLL()
        {
            List<CategorieBLL> categoryList;
            categoryList = categoryBll.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }
    }
}
