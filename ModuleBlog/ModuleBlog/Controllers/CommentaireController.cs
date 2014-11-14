using ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;
using ModuleBlog.Controllers.Models;

namespace ModuleBlog.Controllers
{
    public class CommentaireController : ApiController
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
        public IEnumerable<ModuleBlog.Controllers.Models.Commentaire> Get(int articleId)
        {
            IEnumerable<ModuleBlog.BLL.Models.Commentaire> commentairesBll = commentaireBLL.GetCommentaires(articleId);
            IEnumerable<ModuleBlog.Controllers.Models.Commentaire> commentaires = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Commentaire>, IEnumerable<ModuleBlog.Controllers.Models.Commentaire>>(commentairesBll);
            return commentaires;
        }

        // GET: api/Comment/5
        /// <summary>
        /// Récupérer un commentaire spécifique
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns>le commentaire</returns>
        public ModuleBlog.Controllers.Models.Commentaire GetById(int id)
        {
            ModuleBlog.BLL.Models.Commentaire commentaireBll = commentaireBLL.GetCommentaireById(id);
            ModuleBlog.Controllers.Models.Commentaire commentaire = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.Controllers.Models.Commentaire>(commentaireBll);

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
                ModuleBlog.BLL.Models.Commentaire commentaireBll = Mapper.Map<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(comment);
                if (commentaireBLL.AddCommentaire(commentaireBll))
                    return StatusCode(HttpStatusCode.Created);
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
                ModuleBlog.BLL.Models.Commentaire commentaireBll = Mapper.Map<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(comment);
                if (commentaireBLL.UpdateCommentaire(commentaireBll))
                    return StatusCode(HttpStatusCode.Created);
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
                return Ok();
            else
                return StatusCode(HttpStatusCode.InternalServerError);
        }



    }
}
