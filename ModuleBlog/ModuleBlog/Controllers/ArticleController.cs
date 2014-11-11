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

        private ArticleBLL articleBLL;

        public ArticleController()
        {
            articleBLL = new ArticleBLL();
        }

        // GET: api/Article
        /// <summary>
        /// Récupérer la liste des articles d'un blog
        /// </summary>
        /// <param name="utilisateurId">identifiant de l'utilisateur qui faire la requête</param>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>Liste des articles du blog</returns>
        [Route ("api/article")]
        [HttpGet]
        public IEnumerable<ModuleBlog.Controllers.Models.Article> Get(int utilisateurId, int blogId)
        {
            ModuleBlog.BLL.Models.Articles articlesBLL = articleBLL.GetArticles(utilisateurId, blogId);

            return Map(articlesBLL);
        }

        private ModuleBlog.Controllers.Models.Articles Map(ModuleBlog.BLL.Models.Articles articlesToMap)
        {
            ModuleBlog.Controllers.Models.Articles articles = new ModuleBlog.Controllers.Models.Articles();

            if (articlesToMap.Count > 0)
            {

                foreach (ModuleBlog.BLL.Models.Article article in articlesToMap)
                {
                    Mapper.CreateMap<ModuleBlog.BLL.Models.HashTagArticle, ModuleBlog.Controllers.Models.HashTagArticle>();
                    List<ModuleBlog.Controllers.Models.HashTagArticle> hashTags = Mapper.Map<List<ModuleBlog.BLL.Models.HashTagArticle>, List<ModuleBlog.Controllers.Models.HashTagArticle>>(article.ListeTags);

                    Mapper.CreateMap<ModuleBlog.BLL.Models.Article, ModuleBlog.Controllers.Models.Article>();
                    ModuleBlog.Controllers.Models.Article articleToAdd = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.Controllers.Models.Article>(article);

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
        [Route("api/article")]
        [HttpGet]
        public IEnumerable<ModuleBlog.Controllers.Models.Article> GetByTag(int utilisateurId, string tag)
        {
            ModuleBlog.BLL.Models.Articles articlesBLL = articleBLL.GetArticlesByTag(utilisateurId, tag);

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
            bool result = articleBLL.LikeArticle(utilisateurId, id);

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
            bool result = articleBLL.DislikeArticle(utilisateurId, id);

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
        public IHttpActionResult Add(int blogId = -1, string titre = "", string imageChemin = "", string contenu = "", int evenementId = - 1)
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
            bool result = articleBLL.DeleteArticle(id);

            if (result)
                return StatusCode(HttpStatusCode.OK);
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
