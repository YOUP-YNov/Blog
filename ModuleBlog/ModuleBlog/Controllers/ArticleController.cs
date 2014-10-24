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
        // GET: api/Article
        /// <summary>
        /// Récupérer la liste des articles d'un blog
        /// </summary>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>Liste des articles du blog</returns>
        public IEnumerable<Article> Get(int blogId)
        {
            return null;
        }

        // GET: api/Article/5
        /// <summary>
        /// Récupérer les liste des articles d'un tag
        /// </summary>
        /// <param name="id">identifiant du tag</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Article> GetByTag(int id)
        {
            return null;
        }

        /// <summary>
        /// Récupérer la liste des articles correspondants au critère de recherche
        /// </summary>
        /// <param name="keyword">chaine de caractères à rechercher</param>
        /// <returns>Liste des articles</returns>
        public IEnumerable<Article> Get(string keyword)
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
        /// <param name="id">identifiant de l'article à désactiver</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
