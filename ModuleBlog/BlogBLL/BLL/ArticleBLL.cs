using AutoMapper;
using ModuleBlog.DAL;
using System.Collections.Generic;


namespace ModuleBlog.BLL
{
    public class ArticleBLL
    {
        /// <summary>
        /// The article dal
        /// </summary>
        private ArticleDAL articleDal;
        public ArticleBLL()
        {
            articleDal = new ArticleDAL();
        }

        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <param name="idUtilisateur">The identifier utilisateur.</param>
        /// <param name="idBlog">The identifier blog.</param>
        /// <returns></returns>
        public ModuleBlog.BLL.Models.Articles GetArticles(int idUtilisateur, int idBlog)
        {
            ModuleBlog.DAL.Models.Articles articlesDao = articleDal.GetArticles(idUtilisateur, idBlog);
            if (articlesDao.Count > 0)
            {
                return Map(articlesDao);
            }

            return null;
        }

        /// <summary>
        /// Gets the articles by tag.
        /// </summary>
        /// <param name="idUtilisateur">The identifier utilisateur.</param>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public ModuleBlog.BLL.Models.Articles GetArticlesByTag(int idUtilisateur, string tag)
        {
            ModuleBlog.DAL.Models.Articles articlesDao = articleDal.GetArticlesByTag(idUtilisateur, tag);
            if (articlesDao.Count > 0)
            {
                return Map(articlesDao);
            }

            return null;
        }

        /// <summary>
        /// Maps the specified articles to map.
        /// </summary>
        /// <param name="articlesToMap">The articles to map.</param>
        /// <returns></returns>
        private ModuleBlog.BLL.Models.Articles Map(ModuleBlog.DAL.Models.Articles articlesToMap)
        {
            ModuleBlog.BLL.Models.Articles articlesBLL = new ModuleBlog.BLL.Models.Articles();
            if (articlesToMap.Count > 0) 
            {
                foreach (ModuleBlog.DAL.Models.Article article in articlesToMap)
                {                    
                    List<ModuleBlog.BLL.Models.HashTagArticle> hashTagsBLL = Mapper.Map<List<ModuleBlog.DAL.Models.HashTagArticle>, List<ModuleBlog.BLL.Models.HashTagArticle>>(article.ListeTags);
                    ModuleBlog.BLL.Models.Article articleBLL = Mapper.Map<ModuleBlog.DAL.Models.Article, ModuleBlog.BLL.Models.Article>(article);
                    articleBLL.ListeTags = hashTagsBLL;
                    articlesBLL.Add(articleBLL);
                }
            }
            return articlesBLL;
        }

        /// <summary>
        /// Likes the article.
        /// </summary>
        /// <param name="idUtilisateur">The identifier utilisateur.</param>
        /// <param name="idArticle">The identifier article.</param>
        /// <returns></returns>
        public bool LikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.LikeArticle(idUtilisateur, idArticle);
        }

        /// <summary>
        /// Dislikes the article.
        /// </summary>
        /// <param name="idUtilisateur">The identifier utilisateur.</param>
        /// <param name="idArticle">The identifier article.</param>
        /// <returns></returns>
        public bool DislikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.DislikeArticle(idUtilisateur, idArticle);
        }

        /// <summary>
        /// Adds the article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public string AddArticle(ModuleBlog.BLL.Models.Article article)
        {
            ModuleBlog.DAL.Models.Article articleDao = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>(article);
            return articleDal.AddArticle(articleDao);
        }

        /// <summary>
        /// Updates the article.
        /// </summary>
        /// <param name="article">The article.</param>
        /// <returns></returns>
        public bool UpdateArticle(ModuleBlog.BLL.Models.Article article)
        {            
            ModuleBlog.DAL.Models.Article articleDao = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>(article);
            return articleDal.UpdateArticle(articleDao);
        }

        /// <summary>
        /// Deletes the article.
        /// </summary>
        /// <param name="idArticle">The identifier article.</param>
        /// <returns></returns>
        public bool DeleteArticle(int idArticle)
        {
            return articleDal.DeleteArticle(idArticle);
        }
    }
}