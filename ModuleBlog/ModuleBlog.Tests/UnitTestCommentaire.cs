using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.DAL.Models;


namespace ModuleBlog.Tests
{
    /// <summary>
    /// Description résumée pour UnitTestCommentaireDAL
    /// </summary>
    [TestClass]
    public class COMMENTAIRE_TESTS
    {
        private COMMENTAIRE_DAL cdal;

        [TestInitialize]

        public void Init(){
             cdal = new ModuleBlog.DAL.COMMENTAIRE_DAL();
            Assert.IsNotNull(cdal);

        }
        [TestMethod]

        public void TestMethodGetCommentaireById()
        {
            CommentaireDao commentaire;
            commentaire = cdal.GetCommentaireById(1);
            Assert.IsNotNull(commentaire);
            Assert.IsTrue(commentaire.Article_id==10001);
           
        }
       
        [TestMethod]
        public void TestMethodGetCommentaires()
        {
            List<CommentaireDao> commentaireList;
            commentaireList = cdal.GetCommentaires(10001);

            Assert.IsNotNull(commentaireList);
            Assert.IsTrue(commentaireList.Count>1);
            
        }

       
        [TestMethod]
        public void TestMethodUpdateCommentaire()
        {
            CommentaireDao commentaire;
            commentaire = cdal.GetCommentaireById(1);
            commentaire.ContenuCommentaire="Update Commentaire Test";
            commentaire.DateModification = DateTime.Now;
            Assert.IsTrue(cdal.UpdateCommentaire(commentaire) == "OK");
            
        }
        [TestMethod]
        public void TestMethodReportCommentaire()
        {            
                Assert.IsTrue(cdal.ReportCommentaire(1, 7) == "OK");  
        }

        [TestMethod]
        public void TestMethodAddCommentaire()
        {
            CommentaireDao c = cdal.GetCommentaireById(1);
            Assert.IsTrue(cdal.AddCommentaire(c) == "OK");
        }
        [TestMethod]
        public void TestMethodDeleteCommentaire()
        {
            Assert.IsTrue(cdal.DeleteCommentaire(1) == "OK");
            CommentaireDao c = cdal.GetCommentaireById(1);
            Assert.IsTrue(cdal.GetCommentaireById(c.Commentaire_id).Actif == false);
        }

        [TestCleanup]
        public void TestCleanup()
        {
           
        }


    }
}


