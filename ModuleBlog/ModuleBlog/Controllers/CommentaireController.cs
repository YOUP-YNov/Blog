using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using ModuleBlog.BLL;
using System;

namespace ModuleBlog.Controllers
{
    public class CommentaireController : MapperConverter
    {
       
        private CommentaireBLL commentaireBLL;

        
        public CommentaireController()
        {
            commentaireBLL = new CommentaireBLL();
        }

        // GET: api/Comment
        /// <summary>
        /// Récupérer tous les commentaires d'un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article</param>
        /// <returns>Liste des commentaires</returns>
        [Route("api/article/comment/{articleId}")]
        public IEnumerable<ModuleBlog.Controllers.Models.Commentaire> Get(int articleId)
        {
            IEnumerable<ModuleBlog.BLL.Models.Commentaire> commentairesBll = commentaireBLL.GetCommentaires(articleId);
            IEnumerable<ModuleBlog.Controllers.Models.Commentaire> commentaires = Convert<IEnumerable<ModuleBlog.BLL.Models.Commentaire>, IEnumerable<ModuleBlog.Controllers.Models.Commentaire>>(commentairesBll);
            return commentaires;
        }

        // GET: api/Comment/5
        /// <summary>
        /// Récupérer un commentaire spécifique
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns>le commentaire</returns>
        [Route("api/comment/{id}")]
        public ModuleBlog.Controllers.Models.Commentaire GetById(int id)
        {
            ModuleBlog.BLL.Models.Commentaire commentaireBll = commentaireBLL.GetCommentaireById(id);
            ModuleBlog.Controllers.Models.Commentaire commentaire = Convert<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.Controllers.Models.Commentaire>(commentaireBll);

            return commentaire;
        }

        // POST: api/Comment
        /// <summary>
        /// Ajouter un commentaire
        /// </summary>
        /// <param name="comment">commentaire à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post([FromBody]ModuleBlog.Controllers.Models.Commentaire comment)
        {
            
            if (comment != null)
            {
                if (comment.Article_id == 0 || comment.Utilisateur_id == 0 || comment.ContenuCommentaire == string.Empty)
                    return BadRequest("parameters format is not correct.");
                ModuleBlog.BLL.Models.Commentaire commentaireBll = Convert<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(comment);
                if (commentaireBLL.AddCommentaire(commentaireBll))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "add/get_blogpostcomment";
                        uriB.Query = string.Format("id={0}&content={1}&author={2}", comment.Commentaire_id,comment.ContenuCommentaire,comment.Utilisateur_id);
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
             
            return Ok();
        }

        /// <summary>
        /// Reporter un commentaire (ajout dans table HR_Signaler)
        /// </summary>
        /// <param name="commentId">identifiant du commentaire</param>
        /// <param name="userId">Identifiant de l'utilisateur</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(int commentId, int userId)
        {
            if(commentaireBLL.ReportCommentaire(commentId, userId))
                return Ok();
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }

        // PUT: api/Comment/5
        /// <summary>
        /// Mettre à jour un commentaire
        /// </summary>
        /// <param name="comment">commentaire à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put([FromBody]ModuleBlog.Controllers.Models.Commentaire comment)
        {
            if (comment != null)
            {
                if (comment.Commentaire_id == 0 || comment.ContenuCommentaire == string.Empty)
                    return BadRequest("parameters format is not correct.");
                ModuleBlog.BLL.Models.Commentaire commentaireBll = Convert<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(comment);
                if (commentaireBLL.UpdateCommentaire(commentaireBll))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "update/get_blogpostcomment";
                        uriB.Query = string.Format("id={0}&content={1}&author={2}", comment.Commentaire_id, comment.ContenuCommentaire, comment.Utilisateur_id);
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

        // DELETE: api/Comment/5
        /// <summary>
        /// Désactiver un commentaire
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            if (commentaireBLL.DeleteCommentaire(id))
            {
                try
                {
                    UriBuilder uriB = new UriBuilder();
                    uriB.Host = "www.youp-recherche.azurewebsites.net";
                    uriB.Path = "remove/get_blogpostcomment";
                    uriB.Query = string.Format("id={0}", id);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                    using ((HttpWebResponse)request.GetResponse()) { };
                }
                catch (Exception e)
                {
                    throw;
                }


                return Ok();
            }
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }



    }
}
