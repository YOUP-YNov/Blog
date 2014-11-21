using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.BLL;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestCategorie
    {
        /// <summary>
        /// The category dal
        /// </summary>
        private CategorieDAL categoryDal;
        /// <summary>
        /// The category BLL
        /// </summary>
        private CategorieBLL categoryBll;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            categoryDal = new CategorieDAL();
            Assert.IsNotNull(categoryDal);

            categoryBll = new CategorieBLL();
            Assert.IsNotNull(categoryBll);
        }

        /// <summary>
        /// Tests the lecture categories dal.
        /// </summary>
        [TestMethod]
        public void TestLectureCategoriesDAL()
        {
            List<ModuleBlog.DAL.Models.Categorie> categoryList;
            categoryList = categoryDal.GetCategories();

            Assert.IsNotNull(categoryList);
            Assert.IsTrue(categoryList.Count > 0, "Liste des catégories vide");
        }

        /// <summary>
        /// Tests the lecture categories BLL.
        /// </summary>
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
