using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.DAL.Models;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class CATEGORIE_TESTS
    {
        private CATEGORIE_DAL categoryDal;

        [TestInitialize]
        public void Init()
        {
            categoryDal = new CATEGORIE_DAL();
            // on vérifie que l'instance n'est pas nulle
            Assert.IsNotNull(categoryDal);
        }

        [TestMethod]
        public void TestLectureCategories()
        {
            List<CategorieDao> categoryList;
            categoryList = categoryDal.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }
    }
}
