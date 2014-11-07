﻿using AutoMapper;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;
using ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class ArticleController : ApiController
    {

        private ARTICLE_BLL articleBLL;

        public ArticleController()
        {
            articleBLL = new ARTICLE_BLL();
        }

        // GET: api/Article
        /// <summary>
        /// Récupérer la liste des articles d'un blog
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui faire la requête</param>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>Liste des articles du blog</returns>
        public IEnumerable<Article> Get(int utilisateurId, int blogId)
        {
            ArticlesBLL articlesBLL = articleBLL.GetArticles(utilisateurId, blogId);

            Articles articles = new Articles();

            foreach (ArticleBLL article in articlesBLL)
            {
                Mapper.CreateMap<HashTagArticleBLL, HashTagArticle>();
                List<HashTagArticle> hashTags = Mapper.Map<List<HashTagArticleBLL>, List<HashTagArticle>>(article.ListeTags);

                Mapper.CreateMap<ArticleBLL, Article>();
                Article articleToAdd = Mapper.Map<ArticleBLL, Article>(article);

                articleToAdd.ListeTags = hashTags;
                articles.Add(articleToAdd);
            }

            return articles;
        }

        // GET: api/Article/5
        /// <summary>
        /// Récupérer les liste des articles d'un tag
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui faire la requête"</param>
        /// <param name="tag">tag recherché</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Article> GetByTag(int idUtilisateur, string tag)
        {
            return null;
        }

        // POST: api/Article
        /// <summary>
        /// Créer un article
        /// </summary>
        /// <param name="article">article à créer</param>
        /// <returns>Réponse HTTTP</returns>
        public IHttpActionResult Post(Article article)
        {
            return Ok();
        }

        // PUT: api/Article/5
        /// <summary>
        /// Mettre à jour un article
        /// </summary>
        /// <param name="article">article à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(Article article)
        {
            return Ok();
        }

        /// <summary>
        /// Like/Dislike un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article à aimer</param>
        /// <param name="like">aimer un article = vrai</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(int articleId, bool like)
        {
            return Ok();
        }

        // DELETE: api/Article/5
        /// <summary>
        /// Désactiver un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article à désactiver</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Delete(int articleId)
        {
            return Ok();
        }
    }
}
