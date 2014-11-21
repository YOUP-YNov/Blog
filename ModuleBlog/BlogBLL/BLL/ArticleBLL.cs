using AutoMapper;
using ModuleBlog.DAL;
using System.Collections.Generic;


namespace ModuleBlog.BLL
{
    /// <summary>
    /// Classe de gestion de la BLL pour Article
    /// </summary>
    public class ArticleBLL
    {
        /// <summary>
        /// Instance de la DAL Article
        /// </summary>
        private ArticleDAL articleDal;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        public ArticleBLL()
        {
            articleDal = new ArticleDAL();
        }

        /// <summary>
        /// Récupérer les articles
        /// </summary>
        /// <param name="idUtilisateur">Identifiant de l'utilisateur</param>
        /// <param name="idBlog">Identifiant du blog</param>
        /// <returns>Liste des articles du blog</returns>
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
        /// Récupérer les articles par tag
        /// </summary>
        /// <param name="idUtilisateur">Identifiant de l'utilisateur</param>
        /// <param name="tag">Le tag</param>
        /// <returns>Liste des articles</returns>
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
        /// Mapper les articles de la couche DAL vers la couche BLL
        /// </summary>
        /// <param name="articlesToMap">The articles to map.</param>
        /// <returns>Liste des articles</returns>
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
        /// Aimer un article
        /// </summary>
        /// <param name="idUtilisateur">Identifiant de l'utilisateur</param>
        /// <param name="idArticle">Identifiant de l'article</param>
        /// <returns>True si la DAL a réussi / False sinon</returns>
        public bool LikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.LikeArticle(idUtilisateur, idArticle);
        }

        /// <summary>
        /// Dislike un article
        /// </summary>
        /// <param name="idUtilisateur">Identifiant de l'utilisateur</param>
        /// <param name="idArticle">Identifiant de l'article</param>
        /// <returns>True si la DAL a réussi / False sinon</returns>
        public bool DislikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.DislikeArticle(idUtilisateur, idArticle);
        }

        /// <summary>
        /// Ajouter un article
        /// </summary>
        /// <param name="article">l'article à ajouter</param>
        /// <returns>Id de l'article ajouté</returns>
        public string AddArticle(ModuleBlog.BLL.Models.Article article)
        {
            ModuleBlog.DAL.Models.Article articleDao = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>(article);
            return articleDal.AddArticle(articleDao);
        }

        /// <summary>
        /// Mettre à jour un article
        /// </summary>
        /// <param name="article">L'article à mettre à jour</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool UpdateArticle(ModuleBlog.BLL.Models.Article article)
        {            
            ModuleBlog.DAL.Models.Article articleDao = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>(article);
            return articleDal.UpdateArticle(articleDao);
        }

        /// <summary>
        /// Désactiver un article
        /// </summary>
        /// <param name="idArticle">L'identifiant de l'article</param>
        /// <returns>True si DAL OK/ False sinon</returns>
        public bool DeleteArticle(int idArticle)
        {
            return articleDal.DeleteArticle(idArticle);
        }
    }
}