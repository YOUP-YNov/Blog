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
        private PubliciteDAL adDal;
        private PubliciteBLL adBll;

        [TestInitialize]
        public void Init()
        {
            adDal = new PubliciteDAL();
            Assert.IsNotNull(adDal);

            adBll = new PubliciteBLL();
            Assert.IsNotNull(adBll);
        }

        #region DAL_TESTS
        [TestMethod]
        public void TestAjoutPubliciteDAL()
        {
            ModuleBlog.DAL.Models.Publicite adDao = new ModuleBlog.DAL.Models.Publicite(105, 150, 150, "sample content");

            Assert.IsTrue(adDal.AddAd(adDao));
        }

        [TestMethod]
        public ModuleBlog.DAL.Models.Publicite TestLecturePubliciteDAL()
        {
            ModuleBlog.DAL.Models.Publicite dao;
            dao = adDal.GetAdByBlogId(4);

            Assert.IsNotNull(dao);
            Assert.IsTrue(dao.Blog_id == 4);

            return dao;
        }

        [TestMethod]
        public void TestModificationPubliciteDAL()
        {
            ModuleBlog.DAL.Models.Publicite adDao = TestLecturePubliciteDAL();
            adDao.Hauteur += 50;
            adDao.Largeur += 50;
            adDao.ContenuPublicite = "test Update";

            Assert.IsTrue(adDal.UpdateAd(adDao));
        }
        #endregion

        #region BLL_TESTS
        [TestMethod]
        public void TestAjoutPubliciteBLL()
        {
            ModuleBlog.BLL.Models.Publicite adBllModel = new ModuleBlog.BLL.Models.Publicite(106, 150, 150, "sample content");

            Assert.IsTrue(adBll.AddAd(adBllModel));
        }

        [TestMethod]
        public ModuleBlog.BLL.Models.Publicite TestLecturePubliciteBLL()
        {
            ModuleBlog.BLL.Models.Publicite bll;
            bll = adBll.GetAdByBlogId(4);

            Assert.IsNotNull(bll);
            Assert.IsTrue(bll.Blog_id == 4);

            return bll;
        }

        [TestMethod]
        public void TestModificationPubliciteBLL()
        {
            ModuleBlog.BLL.Models.Publicite adBllModel = TestLecturePubliciteBLL();
            adBllModel.Hauteur += 50;
            adBllModel.Largeur += 50;
            adBllModel.ContenuPublicite = "test Update";

            Assert.IsTrue(adBll.UpdateAdd(adBllModel));
        }
        #endregion
    }
}
