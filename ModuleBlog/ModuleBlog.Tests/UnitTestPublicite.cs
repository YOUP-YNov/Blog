using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestPublicite
    {
        private PUBLICITE_DAL adDal;

        [TestInitialize]
        public void Init()
        {
            adDal = new PUBLICITE_DAL();
            Assert.IsNotNull(adDal);

        }

        [TestMethod]
        public void TestAjout()
        {
            string result = string.Empty;
            result = adDal.AddAd(4, 150, 150, "sample content");
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }

        [TestMethod]
        public PubliciteDao TestLecture()
        {
            PubliciteDao dao;
            dao = adDal.GetAdByBlogId(4);

            Assert.IsNotNull(dao);
            Assert.IsTrue(dao.Blog_id == 4);
            return dao;
        }

        [TestMethod]
        public void TestModification()
        {
            PubliciteDao dao = TestLecture();
            dao.Hauteur += 50;
            dao.Largeur += 50;
            dao.ContenuPublicite = "test Update";

            string result = string.Empty;
            result = adDal.UpdateAd(dao.Publicite_id, dao.Largeur, dao.Hauteur, dao.ContenuPublicite);

            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual("OK", result);
        }
    }
}
