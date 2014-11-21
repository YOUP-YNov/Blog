using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.BLL;

namespace ModuleBlog.Tests
{
    /// <summary>
    /// Description résumée pour UnitTestCommentaireDAL
    /// </summary>
    [TestClass]
    public class COMMENTAIRE_TESTS
    {
        /// <summary>
        /// The cdal
        /// </summary>
        private CommentaireDAL cdal;
        /// <summary>
        /// The CBLL
        /// </summary>
        private CommentaireBLL cbll;
        /// <summary>
        /// The commentaire dal list
        /// </summary>
        private List<ModuleBlog.DAL.Models.Commentaire> commentaireDalList;
        /// <summary>
        /// The commentaire BLL list
        /// </summary>
        private List<ModuleBlog.BLL.Models.Commentaire> commentaireBllList;
        /// <summary>
        /// The commentaire dal
        /// </summary>
        private ModuleBlog.DAL.Models.Commentaire commentaireDAL;
        /// <summary>
        /// The commentaire BLL
        /// </summary>
        private ModuleBlog.BLL.Models.Commentaire commentaireBLL;


        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Init(){
             cdal = new ModuleBlog.DAL.CommentaireDAL();
            Assert.IsNotNull(cdal);
            cbll = new ModuleBlog.BLL.CommentaireBLL();
            Assert.IsNotNull(cbll);
            
        }
        /// <summary>
        /// Tests the method get commentaire by identifier.
        /// </summary>
        [TestMethod]
        public void TestMethodGetCommentaireById()
        {            
            commentaireDAL = cdal.GetCommentaireById(2);
            Assert.IsNotNull(commentaireDAL);
            Assert.IsTrue(commentaireDAL.Article_id==10002);

            commentaireBLL = cbll.GetCommentaireById(2);
            Assert.IsNotNull(commentaireBLL);
            Assert.IsTrue(commentaireBLL.Article_id == 10002);         
        }

        /// <summary>
        /// Tests the method get commentaires.
        /// </summary>
        [TestMethod]
        public void TestMethodGetCommentaires()
        {
            
            commentaireDalList = cdal.GetCommentaires(10002);
            Assert.IsNotNull(commentaireDalList);
            Assert.IsTrue(commentaireDalList.Count>0);

            commentaireBllList = cbll.GetCommentaires(10002);
            Assert.IsNotNull(commentaireBllList);
            Assert.IsTrue(commentaireBllList.Count > 0);
            
        }


        /// <summary>
        /// Tests the method update commentaire.
        /// </summary>
        [TestMethod]
        public void TestMethodUpdateCommentaire()
        {
            commentaireDAL = cdal.GetCommentaireById(2);
            commentaireDAL.ContenuCommentaire = "Update Commentaire Test DAL";
            Assert.IsTrue(cdal.UpdateCommentaire(commentaireDAL));

            
            commentaireBLL = cbll.GetCommentaireById(2);
            commentaireBLL.ContenuCommentaire = "Update Commentaire Test BLL";
            Assert.IsTrue(cbll.UpdateCommentaire(commentaireBLL));

        }
        /// <summary>
        /// Tests the method report commentaire.
        /// </summary>
        [TestMethod]
        public void TestMethodReportCommentaire()
        {            
                Assert.IsTrue(cdal.ReportCommentaire(1, 7));
                Assert.IsTrue(cbll.ReportCommentaire(1, 7));
        }

        /// <summary>
        /// Tests the method add commentaire.
        /// </summary>
        [TestMethod]
        public void TestMethodAddCommentaire()
        {
            ModuleBlog.DAL.Models.Commentaire commentaireDAL = cdal.GetCommentaireById(2);
            Assert.IsTrue(cdal.AddCommentaire(commentaireDAL));
            
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = cbll.GetCommentaireById(2);
            Assert.IsTrue(cbll.AddCommentaire(commentaireBLL));
        }

        /// <summary>
        /// Tests the method delete commentaire.
        /// </summary>
        [TestMethod]
        public void TestMethodDeleteCommentaire()
        {
            Assert.IsTrue(cdal.DeleteCommentaire(2));
            ModuleBlog.DAL.Models.Commentaire commentaireDAL = cdal.GetCommentaireById(2);
            Assert.IsTrue(cdal.GetCommentaireById(commentaireDAL.Commentaire_id).Actif == false);

            Assert.IsTrue(cbll.DeleteCommentaire(2));
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = cbll.GetCommentaireById(2);
            Assert.IsTrue(cdal.GetCommentaireById(commentaireBLL.Commentaire_id).Actif == false);
        
        }

        /// <summary>
        /// Tests the cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
      
        }


    }
}


