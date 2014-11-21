using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModuleBlog.Tests
{
    [TestClass]
    public class UnitTestArticle
    {
        /// <summary>
        /// The article dal
        /// </summary>
        private ArticleDAL ArticleDal;

        /// <summary>
        /// The article identifier
        /// </summary>
        private int ArticleId;

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            ArticleDal = new ArticleDAL();

            Article articleToInsert = new Article();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;

            articleToInsert.ListeTags = new List<HashTagArticle>();

            HashTagArticle hashTag1 = new HashTagArticle();
            hashTag1.Mots = "Tag1";
            articleToInsert.ListeTags.Add(hashTag1);

            ArticleId = int.Parse(ArticleDal.AddArticleWithEvent(articleToInsert));
        }


        /// <summary>
        /// Tests the get articles.
        /// </summary>
        [TestMethod]
        public void TestGetArticles()
        {
            List<Article> articles = ArticleDal.GetArticles(1, 4);
            Assert.IsTrue(articles.Count != 0);
        }

        /// <summary>
        /// Tests the get articles by tag.
        /// </summary>
        [TestMethod]
        public void TestGetArticlesByTag()
        {
            List<Article>  articles = ArticleDal.GetArticlesByTag(0, "Tag1");
            Assert.IsTrue(articles.Count != 0);

            articles = ArticleDal.GetArticlesByTag(0, "un random tag qui existe pas");
            Assert.IsTrue(articles.Count == 0);
        }

        /// <summary>
        /// Tests the insert article.
        /// </summary>
        [TestMethod]
        public void TestInsertArticle()
        {
            Article articleToInsert = new Article();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;

            string id = ArticleDal.AddArticleWithEvent(articleToInsert);

            Article articleAdded = ArticleDal.GetArticles(1, 4).Search(int.Parse(id));
            Assert.AreEqual(articleToInsert.Blog_id, articleAdded.Blog_id);
            Assert.AreEqual(articleToInsert.ContenuArticle, articleAdded.ContenuArticle);
            Assert.AreEqual(articleToInsert.TitreArticle, articleAdded.TitreArticle);
            Assert.AreEqual(articleToInsert.ImageChemin, articleAdded.ImageChemin);
            Assert.AreEqual(articleToInsert.Evenement_id, articleAdded.Evenement_id);
        }

        /// <summary>
        /// Tests the add article with hash tags.
        /// </summary>
        [TestMethod]
        public void TestAddArticleWithHashTags()
        {
            Article articleToInsert = new Article();
            articleToInsert.Blog_id = 4;
            articleToInsert.ContenuArticle = "Contenu d'un article avec hashtag inséré pour les tests";
            articleToInsert.TitreArticle = "Article de test avec hashtag";
            articleToInsert.ImageChemin = "";
            articleToInsert.Evenement_id = 2;
            articleToInsert.ListeTags = new List<HashTagArticle>();

            HashTagArticle hashTag1 = new HashTagArticle();
            hashTag1.Mots = "Premier hash tag avec test";
            HashTagArticle hashTag2 = new HashTagArticle();
            hashTag2.Mots = "Second hash tag avec test";
            HashTagArticle hashTag3 = new HashTagArticle();
            hashTag3.Mots = "Troisième hash tag avec test";

            articleToInsert.ListeTags.Add(hashTag1);
            articleToInsert.ListeTags.Add(hashTag2);
            articleToInsert.ListeTags.Add(hashTag3);

            string id = ArticleDal.AddArticleWithEvent(articleToInsert);

            Article articleAdded = ArticleDal.GetArticles(1, 4).Search(int.Parse(id));
            Assert.AreEqual(articleToInsert.Blog_id, articleAdded.Blog_id);
            Assert.AreEqual(articleToInsert.ContenuArticle, articleAdded.ContenuArticle);
            Assert.AreEqual(articleToInsert.TitreArticle, articleAdded.TitreArticle);
            Assert.AreEqual(articleToInsert.ImageChemin, articleAdded.ImageChemin);
            Assert.AreEqual(articleToInsert.Evenement_id, articleAdded.Evenement_id);
            Assert.AreEqual(articleToInsert.ListeTags.Count, articleAdded.ListeTags.Count);

        }

        /// <summary>
        /// Tests the update article.
        /// </summary>
        [TestMethod]
        public void TestUpdateArticle()
        {
            string NouveauContenu = "Un nouveau contenu d'article lol ";
            Article ArticleToUpdate = ArticleDal.GetArticlesByTag(0, "Tag1")[0];

            ArticleToUpdate.ContenuArticle = NouveauContenu;

            ArticleDal.UpdateArticle(ArticleToUpdate);

            Assert.IsTrue(ArticleDal.GetArticlesByTag(0, "Tag1")[0].ContenuArticle == NouveauContenu);
        }

        /// <summary>
        /// Tests the update article with tags.
        /// </summary>
        [TestMethod]
        public void TestUpdateArticleWithTags()
        {
            string NouveauContenu = "Un nouveau contenu d'article lol ";
            Article ArticleToUpdate = ArticleDal.GetArticlesByTag(7, "Tag1").Last();

            HashTagArticle hashTag1 = new HashTagArticle();
            hashTag1.Mots = "Premier hash tag avec test";
            HashTagArticle hashTag2 = new HashTagArticle();
            hashTag2.Mots = "Second hash tag avec test";
            HashTagArticle hashTag3 = new HashTagArticle();
            hashTag3.Mots = "Troisième hash tag avec test";

            ArticleToUpdate.ListeTags.Add(hashTag1);
            ArticleToUpdate.ListeTags.Add(hashTag2);
            ArticleToUpdate.ListeTags.Add(hashTag3);

            ArticleToUpdate.ContenuArticle = NouveauContenu;

            ArticleDal.UpdateArticle(ArticleToUpdate);

            Article ArticleUpdated = ArticleDal.GetArticlesByTag(7, "Tag1").Last();
 
            Assert.IsTrue(ArticleUpdated.ContenuArticle == NouveauContenu);
            Assert.AreEqual(ArticleToUpdate.ListeTags.Count, ArticleUpdated.ListeTags.Count);       
        }

        /// <summary>
        /// Tests the delete article.
        /// </summary>
        [TestMethod]
        public void TestDeleteArticle()
        {
            Articles articles = ArticleDal.GetArticles(1, 4);

            if (articles.Count > 0)
            {
                int articlesCount = articles.Count;
                Article articleToDelete = articles.Last();

                ArticleDal.DeleteArticle(articleToDelete.Article_id);

                articles = ArticleDal.GetArticles(1, 4);

                Assert.AreEqual(articlesCount - 1, articles.Count);
            }

        }

        /// <summary>
        /// Tests the like article.
        /// </summary>
        [TestMethod]
        public void TestLikeArticle()
        {
            ArticleDal.LikeArticle(7, ArticleId);
            Article articleToLike = ArticleDal.GetArticles(7, 4).Last();

            Assert.IsTrue(articleToLike.IsLiked);
        }

        /// <summary>
        /// Tests the dislike article.
        /// </summary>
        [TestMethod]
        public void TestDislikeArticle()
        {
            ArticleDal.LikeArticle(7, ArticleId);

            ArticleDal.DislikeArticle(7, ArticleId);
            Article articleToDislike = ArticleDal.GetArticles(7, 4).Last();

            Assert.IsFalse(articleToDislike.IsLiked);
        }

        /// <summary>
        /// Tests the clean up.
        /// </summary>
        [TestCleanup]
        public void TestCleanUp()
        {
            //On remet un contenu par défaut pour pouvoir retester la modification

            ArticleDal.DeleteArticleForReal(ArticleId);

        }
        
    }
}
