using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestPublicite
    {
        private PUBLICITE_DAL adDal;
        private PUBLICITE_BLL adBll;

        [TestInitialize]
        public void Init()
        {
            adDal = new PUBLICITE_DAL();
            Assert.IsNotNull(adDal);

            adBll = new PUBLICITE_BLL();
            Assert.IsNotNull(adBll);
        }

        #region DAL_TESTS
        [TestMethod]
        public void TestAjoutPubliciteDAL()
        {
            PubliciteDao adDao = new PubliciteDao(4, 150, 150, "sample content");

            string result = string.Empty;
            result = adDal.AddAd(adDao);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public PubliciteDao TestLecturePubliciteDAL()
        {
            PubliciteDao dao;
            dao = adDal.GetAdByBlogId(4);

            Assert.IsNotNull(dao);
            Assert.IsTrue(dao.Blog_id == 4);
            return dao;
        }

        [TestMethod]
        public void TestModificationPubliciteDAL()
        {
            PubliciteDao adDao = TestLecturePubliciteDAL();
            adDao.Hauteur += 50;
            adDao.Largeur += 50;
            adDao.ContenuPublicite = "test Update";

            string result = string.Empty;
            result = adDal.UpdateAd(adDao);

            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }
        #endregion

        #region BLL_TESTS
        [TestMethod]
        public void TestAjoutPubliciteBLL()
        {
            PubliciteBLL adBllModel = new PubliciteBLL(4, 150, 150, "sample content");

            string result = string.Empty;
            result = adBll.AddAd(adBllModel);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public PubliciteBLL TestLecturePubliciteBLL()
        {
            PubliciteBLL bll;
            bll = adBll.GetAdByBlogId(4);

            Assert.IsNotNull(bll);
            Assert.IsTrue(bll.Blog_id == 4);
            return bll;
        }

        [TestMethod]
        public void TestModificationPubliciteBLL()
        {
            PubliciteBLL adBllModel = TestLecturePubliciteBLL();
            adBllModel.Hauteur += 50;
            adBllModel.Largeur += 50;
            adBllModel.ContenuPublicite = "test Update";

            string result = string.Empty;
            result = adBll.UpdateAdd(adBllModel);
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }
        #endregion
    }
}
