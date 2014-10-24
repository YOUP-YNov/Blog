using ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class CommentController : ApiController
    {
        // GET: api/Comment
        /// <summary>
        /// Récupérer tous les commentaires d'un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article</param>
        /// <returns>Liste des commentaires</returns>
        public IEnumerable<Commentaire> Get(int articleId)
        {
            return null;
        }

        // GET: api/Comment/5
        /// <summary>
        /// Récupérer un commentaire spécifique
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns>le commentaire</returns>
        public Commentaire GetById(int id)
        {
            return null;
        }

        // POST: api/Comment
        /// <summary>
        /// Ajouter un commentaire
        /// </summary>
        /// <param name="comment">commentaire à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(Commentaire comment)
        {
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
            return Ok();
        }

        // PUT: api/Comment/5
        /// <summary>
        /// Mettre à jour un commentaire
        /// </summary>
        /// <param name="comment">commentaire à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(Commentaire comment)
        {
            return Ok();
        }

        // DELETE: api/Comment/5
        /// <summary>
        /// Désactiver un commentaire
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
