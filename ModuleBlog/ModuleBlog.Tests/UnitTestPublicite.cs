using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using ModuleBlog.BLL;


namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestPublicite
    {
        /// <summary>
        /// The ad dal
        /// </summary>
        private PubliciteDAL adDal;
        /// <summary>
        /// The ad BLL
        /// </summary>
        private PubliciteBLL adBll;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            adDal = new PubliciteDAL();
            Assert.IsNotNull(adDal);

            adBll = new PubliciteBLL();
            Assert.IsNotNull(adBll);
        }

        #region DAL_TESTS
        /// <summary>
        /// Tests the ajout publicite dal.
        /// </summary>
        [TestMethod]
        public void TestAjoutPubliciteDAL()
        {
            ModuleBlog.DAL.Models.Publicite adDao = new ModuleBlog.DAL.Models.Publicite(12, 150, 150, "sample content");

            Assert.IsTrue(adDal.AddAd(adDao));
        }

        /// <summary>
        /// Tests the lecture publicite dal.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public ModuleBlog.DAL.Models.Publicite TestLecturePubliciteDAL()
        {
            ModuleBlog.DAL.Models.Publicite dao;
            dao = adDal.GetAdByBlogId(4);

            Assert.IsNotNull(dao);
            Assert.IsTrue(dao.Blog_id == 4);

            return dao;
        }

        /// <summary>
        /// Tests the modification publicite dal.
        /// </summary>
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
        /// <summary>
        /// Tests the ajout publicite BLL.
        /// </summary>
        [TestMethod]
        public void TestAjoutPubliciteBLL()
        {
            ModuleBlog.BLL.Models.Publicite adBllModel = new ModuleBlog.BLL.Models.Publicite(4, 150, 150, "sample content");

            Assert.IsTrue(adBll.AddAd(adBllModel));
        }

        /// <summary>
        /// Tests the lecture publicite BLL.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public ModuleBlog.BLL.Models.Publicite TestLecturePubliciteBLL()
        {
            ModuleBlog.BLL.Models.Publicite bll;
            bll = adBll.GetAdByBlogId(4);

            Assert.IsNotNull(bll);
            Assert.IsTrue(bll.Blog_id == 4);

            return bll;
        }

        /// <summary>
        /// Tests the modification publicite BLL.
        /// </summary>
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
