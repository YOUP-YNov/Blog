using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestArticle
    {
        private ARTICLE_DAL ArticleDal;

        private int ArticleId;

        [TestInitialize]
        public void TestInitialize()
        {
            ArticleDal = new ARTICLE_DAL();

            ArticleDao articleToInsert = new ArticleDao();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;

            articleToInsert.ListeTags = new List<HashTagArticleDao>();

            HashTagArticleDao hashTag1 = new HashTagArticleDao();
            hashTag1.Mots = "Tag1";
            articleToInsert.ListeTags.Add(hashTag1);

            ArticleId = int.Parse(ArticleDal.AddArticle(articleToInsert));
        }


        [TestMethod]
        public void TestGetArticles()
        {
            List<ArticleDao> articles = ArticleDal.GetArticles(1, 4);
            Assert.IsTrue(articles.Count != 0);
        }

        [TestMethod]
        public void TestGetArticlesByTag()
        {
            List<ArticleDao>  articles = ArticleDal.GetArticlesByTag(0, "Tag1");
            Assert.IsTrue(articles.Count != 0);

            articles = ArticleDal.GetArticlesByTag(0, "un random tag qui existe pas");
            Assert.IsTrue(articles.Count == 0);
        }

        [TestMethod]
        public void TestInsertArticle()
        {
            ArticleDao articleToInsert = new ArticleDao();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;

            string id = ArticleDal.AddArticle(articleToInsert);

            ArticleDao articleAdded = ArticleDal.GetArticles(1, 4).GetArticleDao(int.Parse(id));
            Assert.AreEqual(articleToInsert.Blog_id, articleAdded.Blog_id);
            Assert.AreEqual(articleToInsert.ContenuArticle, articleAdded.ContenuArticle);
            Assert.AreEqual(articleToInsert.TitreArticle, articleAdded.TitreArticle);
            Assert.AreEqual(articleToInsert.ImageChemin, articleAdded.ImageChemin);
            Assert.AreEqual(articleToInsert.Evenement_id, articleAdded.Evenement_id);
        }

        [TestMethod]
        public void TestAddArticleWithHashTags()
        {
            ArticleDao articleToInsert = new ArticleDao();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article avec hashtag inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test avec hashtag";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;
            articleToInsert.ListeTags = new List<HashTagArticleDao>();

            HashTagArticleDao hashTag1 = new HashTagArticleDao();
            hashTag1.Mots = "Premier hash tag avec test";
            HashTagArticleDao hashTag2 = new HashTagArticleDao();
            hashTag2.Mots = "Second hash tag avec test";
            HashTagArticleDao hashTag3 = new HashTagArticleDao();
            hashTag3.Mots = "Troisième hash tag avec test";

            articleToInsert.ListeTags.Add(hashTag1);
            articleToInsert.ListeTags.Add(hashTag2);
            articleToInsert.ListeTags.Add(hashTag3);

            string id = ArticleDal.AddArticle(articleToInsert);

            ArticleDao articleAdded = ArticleDal.GetArticles(1, 4).GetArticleDao(int.Parse(id));
            Assert.AreEqual(articleToInsert.Blog_id, articleAdded.Blog_id);
            Assert.AreEqual(articleToInsert.ContenuArticle, articleAdded.ContenuArticle);
            Assert.AreEqual(articleToInsert.TitreArticle, articleAdded.TitreArticle);
            Assert.AreEqual(articleToInsert.ImageChemin, articleAdded.ImageChemin);
            Assert.AreEqual(articleToInsert.Evenement_id, articleAdded.Evenement_id);
            Assert.AreEqual(articleToInsert.ListeTags.Count, articleAdded.ListeTags.Count);

        }

        [TestMethod]
        public void TestUpdateArticle()
        {
            string NouveauContenu = "Un nouveau contenu d'article lol ";
            ArticleDao ArticleToUpdate = ArticleDal.GetArticlesByTag(0, "Tag1")[0];

            ArticleToUpdate.ContenuArticle = NouveauContenu;

            ArticleDal.UpdateArticle(ArticleToUpdate);

            Assert.IsTrue(ArticleDal.GetArticlesByTag(0, "Tag1")[0].ContenuArticle == NouveauContenu);
        }

        [TestMethod]
        public void TestUpdateArticleWithTags()
        {
            string NouveauContenu = "Un nouveau contenu d'article lol ";
            ArticleDao ArticleToUpdate = ArticleDal.GetArticlesByTag(7, "Tag1").Last();

            HashTagArticleDao hashTag1 = new HashTagArticleDao();
            hashTag1.Mots = "Premier hash tag avec test";
            HashTagArticleDao hashTag2 = new HashTagArticleDao();
            hashTag2.Mots = "Second hash tag avec test";
            HashTagArticleDao hashTag3 = new HashTagArticleDao();
            hashTag3.Mots = "Troisième hash tag avec test";

            ArticleToUpdate.ListeTags.Add(hashTag1);
            ArticleToUpdate.ListeTags.Add(hashTag2);
            ArticleToUpdate.ListeTags.Add(hashTag3);

            ArticleToUpdate.ContenuArticle = NouveauContenu;

            ArticleDal.UpdateArticle(ArticleToUpdate);

            ArticleDao ArticleUpdated = ArticleDal.GetArticlesByTag(7, "Tag1").Last();
 
            Assert.IsTrue(ArticleUpdated.ContenuArticle == NouveauContenu);
            Assert.AreEqual(ArticleToUpdate.ListeTags.Count, ArticleUpdated.ListeTags.Count);       
        }

        [TestMethod]
        public void TestDeleteArticle()
        {
            ArticlesDao articles = ArticleDal.GetArticles(1, 4);

            if (articles.Count > 0)
            {
                int articlesCount = articles.Count;
                ArticleDao articleToDelete = articles.Last();

                ArticleDal.DeleteArticle(articleToDelete.Article_id);

                articles = ArticleDal.GetArticles(1, 4);

                Assert.AreEqual(articlesCount - 1, articles.Count);
            }

        }

        [TestMethod]
        public void TestLikeArticle()
        {
            ArticleDal.LikeArticle(7, ArticleId);
            ArticleDao articleToLike = ArticleDal.GetArticles(7, 4).Last();

            Assert.IsTrue(articleToLike.IsLiked);
        }

        [TestMethod]
        public void TestDislikeArticle()
        {
            ArticleDal.LikeArticle(7, ArticleId);

            ArticleDal.DislikeArticle(7, ArticleId);
            ArticleDao articleToDislike = ArticleDal.GetArticles(7, 4).Last();

            Assert.IsFalse(articleToDislike.IsLiked);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //On remet un contenu par défaut pour pouvoir retester la modification

            ArticleDal.DeleteArticleForReal(ArticleId);

        }
        
    }
}
