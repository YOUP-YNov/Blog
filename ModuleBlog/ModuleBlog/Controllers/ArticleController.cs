using ModuleBlog.BLL;
using BLLModels = ModuleBlog.BLL.Models;
using ControllersModels = ModuleBlog.Controllers.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System;

namespace ModuleBlog.Controllers
{
    public class ArticleController : MapperConverter
    {

        private ArticleBLL articleBLL;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticleController"/> class.
        /// </summary>
        public ArticleController()
        {
            articleBLL = new ArticleBLL();
        }

        /// <summary>
        /// Maps the specified articles to map.
        /// </summary>
        /// <param name="articlesToMap">The articles to map.</param>
        /// <returns></returns>
        private ControllersModels.Articles Map(BLLModels.Articles articlesToMap)
        {
            ControllersModels.Articles articles = new ControllersModels.Articles();

            if (articlesToMap != null)
            {
                if (articlesToMap.Count > 0)
                {
                    foreach (BLLModels.Article article in articlesToMap)
                    {
                        List<ControllersModels.HashTagArticle> hashTags =
                            Convert<List<BLLModels.HashTagArticle>, List<ControllersModels.HashTagArticle>>(
                                article.ListeTags);
                        ControllersModels.Article articleToAdd =
                            Convert<BLLModels.Article, ControllersModels.Article>(article);
                        articleToAdd.ListeTags = hashTags;
                        articles.Add(articleToAdd);
                    }
                }
            }
            return articles;
        }

        /// <summary>
        /// Maps the specified article to map.
        /// </summary>
        /// <param name="articleToMap">The article to map.</param>
        /// <returns></returns>
        private BLLModels.Article Map(ControllersModels.Article articleToMap)
        {
            BLLModels.Article article = new BLLModels.Article();

            if (articleToMap.TitreArticle != string.Empty)
            {
                List<BLLModels.HashTagArticle> hashTags =
                    Convert<List<ControllersModels.HashTagArticle>, List<BLLModels.HashTagArticle>>(articleToMap.ListeTags);
                BLLModels.Article articleToAdd = Convert<ControllersModels.Article, BLLModels.Article>(articleToMap);
                articleToAdd.ListeTags = hashTags;
                return articleToAdd;
            }
            return null;
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
        public IEnumerable<ControllersModels.Article> Get(int utilisateurId, int blogId)
        {
            BLLModels.Articles articlesBLL = articleBLL.GetArticles(utilisateurId, blogId);
            return Map(articlesBLL);
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
        public IEnumerable<ControllersModels.Article> GetByTag(int utilisateurId, string tag)
        {
            BLLModels.Articles articlesBLL = articleBLL.GetArticlesByTag(utilisateurId, tag);

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
        /// Créer un article
        /// </summary>
        /// <param name="article">Article à ajouter</param>
        /// <returns></returns>
        [Route("api/article")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ControllersModels.Article article)//int blogId = -1, string titre = "", string imageChemin = "", string contenu = "", int evenementId = - 1)
        {
            if (article != null)
            {
                if (article.Blog_id == 0 || article.ContenuArticle == string.Empty || article.TitreArticle == string.Empty)
                    return BadRequest("parameters format is not correct.");

                BLLModels.Article articleBll = Map(article);
                string result = articleBLL.AddArticle(articleBll);
                if (int.Parse(result) > 0)
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "add/get_blogpost";
                        uriB.Query = string.Format("id={0}&content={1}&author={2}&title={3}", article.Article_id
                            , article.ContenuArticle,article.Blog_id,article.TitreArticle);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                        using ((HttpWebResponse)request.GetResponse()) { };
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    return Ok(result);

                }
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        /// <summary>
        /// Mettre à jour un article
        /// </summary>
        /// <param name="article">Article à mettre à jour</param>
        /// <returns></returns>
        [Route("api/article/{id}"), HttpPut]
        public IHttpActionResult UpdateArticle(int id, [FromBody]ControllersModels.Article article)
        {
            if (article != null || id <= 0)
            {
                if (article.Blog_id == 0 || article.ContenuArticle == string.Empty || article.TitreArticle == string.Empty)
                    return BadRequest("parameters format is not correct.");
                if (article.Article_id == 0)
                    article.Article_id = id;
                BLLModels.Article articleBll = Map(article);
                if (articleBLL.UpdateArticle(articleBll))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "update/get_blogpost";
                        uriB.Query = string.Format("id={0}&content={1}&author={2}&title={3}", article.Article_id
                            , article.ContenuArticle, article.Blog_id, article.TitreArticle);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                        using ((HttpWebResponse)request.GetResponse()) { };
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    return StatusCode(HttpStatusCode.Created);
                }
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
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
            {
                try
                {
                    UriBuilder uriB = new UriBuilder();
                    uriB.Host = "www.youp-recherche.azurewebsites.net";
                    uriB.Path = "remove/get_blogpost";
                    uriB.Query = string.Format("id={0}",id);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                    using ((HttpWebResponse)request.GetResponse()) { };
                }
                catch (Exception e)
                {
                    throw;
                }
                return StatusCode(HttpStatusCode.OK);
            }
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }
    }
}
