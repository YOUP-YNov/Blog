using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.DAL.Models;
using ModuleBlog.BLL.Models;

namespace ModuleBlog.Tests
{
    /// <summary>
    /// Description résumée pour UnitTestCommentaireDAL
    /// </summary>
    [TestClass]
    public class COMMENTAIRE_TESTS
    {
        private CommentaireDAL cdal;

        [TestInitialize]

        public void Init(){
             cdal = new ModuleBlog.DAL.CommentaireDAL();
            Assert.IsNotNull(cdal);

        }
        [TestMethod]
        public void TestMethodGetCommentaireById()
        {
            ModuleBlog.DAL.Models.Commentaire commentaire;
            commentaire = cdal.GetCommentaireById(2);
            Assert.IsNotNull(commentaire);
            Assert.IsTrue(commentaire.Article_id==10002);
           
        }
       
        [TestMethod]
        public void TestMethodGetCommentaires()
        {
            List<ModuleBlog.DAL.Models.Commentaire> commentaireList;
            commentaireList = cdal.GetCommentaires(10002);

            Assert.IsNotNull(commentaireList);
            Assert.IsTrue(commentaireList.Count>0);
            
        }

       
        [TestMethod]
        public void TestMethodUpdateCommentaire()
        {
            ModuleBlog.DAL.Models.Commentaire commentaire;
            commentaire = cdal.GetCommentaireById(1);
            commentaire.ContenuCommentaire="Update Commentaire Test";
            commentaire.DateModification = DateTime.Now;
            Assert.IsTrue(cdal.UpdateCommentaire(commentaire));
            
        }
        [TestMethod]
        public void TestMethodReportCommentaire()
        {            
                Assert.IsTrue(cdal.ReportCommentaire(1, 7));  
        }

        [TestMethod]
        public void TestMethodAddCommentaire()
        {
            ModuleBlog.DAL.Models.Commentaire c = cdal.GetCommentaireById(2);
            Assert.IsTrue(cdal.AddCommentaire(c));
        }
        [TestMethod]
        public void TestMethodDeleteCommentaire()
        {
            Assert.IsTrue(cdal.DeleteCommentaire(1));
            ModuleBlog.DAL.Models.Commentaire c = cdal.GetCommentaireById(1);
            Assert.IsTrue(cdal.GetCommentaireById(c.Commentaire_id).Actif == false);
            c.Actif = true;
            c.DateModification = DateTime.Now;
            cdal.UpdateCommentaire(c);
        }

        [TestCleanup]
        public void TestCleanup()
        {
           
        }


    }
}


