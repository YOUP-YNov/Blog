using AutoMapper;
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

            return Map(articlesBLL);
        }

        private Articles Map(ArticlesBLL articlesToMap)
        {
            Articles articles = new Articles();

            if (articlesToMap.Count > 0)
            { 

                foreach (ArticleBLL article in articlesToMap)
                {
                    Mapper.CreateMap<HashTagArticleBLL, HashTagArticle>();
                    List<HashTagArticle> hashTags = Mapper.Map<List<HashTagArticleBLL>, List<HashTagArticle>>(article.ListeTags);

                    Mapper.CreateMap<ArticleBLL, Article>();
                    Article articleToAdd = Mapper.Map<ArticleBLL, Article>(article);

                    articleToAdd.ListeTags = hashTags;
                    articles.Add(articleToAdd);
                }
            }

            return articles;
        }

        // GET: api/Article/
        /// <summary>
        /// Récupérer les liste des articles d'un tag
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui fait la requête"</param>
        /// <param name="tag">tag recherché</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Article> GetByTag(int utilisateurId, string tag)
        {
            ArticlesBLL articlesBLL = articleBLL.GetArticlesByTag(utilisateurId, tag);

            return Map(articlesBLL);
        }

        /// <summary>
        /// Aime un article
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui fait la requête</param>
        /// <param name="articleId">identifiant de l'article qui est aimé</param>
        /// <returns></returns>
        [Route("api/article/{id}/like")]
        [HttpPut]
        public IHttpActionResult Like(int id, int utilisateurId)
        {
            Boolean result = articleBLL.LikeArticle(utilisateurId, id);

            if (result)
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// N'aime un article
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui fait la requête</param>
        /// <param name="articleId">identifiant de l'article qui n'est plus aimé</param>
        /// <returns></returns>
        [Route("api/article/{id}/dislike")]
        [HttpPut]
        public IHttpActionResult Dislike(int id, int utilisateurId)
        {
            Boolean result = articleBLL.DislikeArticle(utilisateurId, id);

            if (result)
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Crée un article
        /// </summary>
        /// <param name="blogId">id du blog auquel appartient l'article</param>
        /// <param name="titre">titre de l'article</param>
        /// <param name="imageChemin">url de l'image de l'article</param>
        /// <param name="contenu">contenu de l'article</param>
        /// <param name="evenementId">id auquel appartient l'article</param>
        /// <returns></returns>
        [Route("api/article")]
        [HttpPost]
        public IHttpActionResult Add(string titre, string imageChemin, string contenu, int blogId = -1, int evenementId = - 1)
        {
            return null;
        }

        /// <summary>
        /// Désactive un article
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui fait la requête</param>
        /// <param name="articleId">identifiant de l'article qui est désactivé</param>
        /// <returns></returns>
        [Route("api/article/{id}/disable")]
        [HttpPut]
        public IHttpActionResult Disable(int id)
        {
            Boolean result = articleBLL.DeleteArticle(id);

            if (result)
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
