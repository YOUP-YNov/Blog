using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;

namespace ModuleBlog.Tests
{
    /// <summary>
    /// Description résumée pour UnitTestCommentaireDAL
    /// </summary>
    [TestClass]
    public class UnitTestCommentaireDAL
    {
      
        [TestInitialize]

        public void Init(){
            COMMENTAIRE_DAL cdal = new COMMENTAIRE_DAL();

        }
        [TestMethod]
        public void TestMethodDeleteCommentaire()
        {
                   

        }

        public void TestMethodGetCommentaireById()
        {
            

        }

        public void TestMethodGetCommentaires()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        public void TestMethodUpdateCommentaire()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }

        public void TestMethodReportCommentaire()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
        }



    }
}
