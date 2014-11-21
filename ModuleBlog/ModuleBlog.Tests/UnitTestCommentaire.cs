using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using System.Collections.Generic;
using ModuleBlog.DAL.Models;
using ModuleBlog.BLL.Models;
using ModuleBlog.BLL;

namespace ModuleBlog.Tests
{
    /// <summary>
    /// Description résumée pour UnitTestCommentaireDAL
    /// </summary>
    [TestClass]
    public class COMMENTAIRE_TESTS
    {
        private CommentaireDAL cdal;
        private CommentaireBLL cbll;
        private List<ModuleBlog.DAL.Models.Commentaire> commentaireDalList;
        private List<ModuleBlog.BLL.Models.Commentaire> commentaireBllList;
        private ModuleBlog.DAL.Models.Commentaire commentaireDAL;
        private ModuleBlog.BLL.Models.Commentaire commentaireBLL;
        [TestInitialize]

        public void Init(){
             cdal = new ModuleBlog.DAL.CommentaireDAL();
            Assert.IsNotNull(cdal);
            cbll = new ModuleBlog.BLL.CommentaireBLL();
            Assert.IsNotNull(cbll);
            
        }
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

       
        [TestMethod]
        public void TestMethodUpdateCommentaire()
        {
                         // Assert.IsTrue(blogDAL.UpdateBlog(new Blog { Blog_id = 12, Utilisateur_id = 25, TitreBlog = "Blog de l'utilisateur Test", Categorie_id = 3, Promotion = false, Actif = true, Theme_id = 3, DateCreation = DateTime.Now }), "Blog non modifié");
            Assert.IsTrue(cdal.UpdateCommentaire(new ModuleBlog.DAL.Models.Commentaire { Commentaire_id = 2, ContenuCommentaire="update commentaire Dal test", Actif=true }));
            
         //   commentaireBLL = cbll.GetCommentaireById(2);
          //  commentaireBLL.ContenuCommentaire = "Update Commentaire Test BLL";
           // Assert.IsTrue(cbll.UpdateCommentaire(commentaireBLL));

        }
        [TestMethod]
        public void TestMethodReportCommentaire()
        {            
                Assert.IsTrue(cdal.ReportCommentaire(1, 7));
                Assert.IsTrue(cbll.ReportCommentaire(1, 7));
        }

        [TestMethod]
        public void TestMethodAddCommentaire()
        {
            ModuleBlog.DAL.Models.Commentaire commentaireDAL = cdal.GetCommentaireById(2);
            Assert.IsTrue(cdal.AddCommentaire(commentaireDAL));
            
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = cbll.GetCommentaireById(2);
            Assert.IsTrue(cbll.AddCommentaire(commentaireBLL));
        }
        [TestMethod]
        public void TestMethodDeleteCommentaire()
        {
            Assert.IsTrue(cdal.DeleteCommentaire(2));
            Assert.IsTrue(cbll.DeleteCommentaire(2));
           
        
        }

        [TestCleanup]
        public void TestCleanup()
        {
      
        }


    }
}


