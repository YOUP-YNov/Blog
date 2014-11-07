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
    public class CommentController : ApiController
    {
       
        private COMMENTAIRE_BLL commentaireBLL;

        
        public CommentController()
        {
            commentaireBLL = new COMMENTAIRE_BLL();
        }

        // GET: api/Comment
        /// <summary>
        /// Récupérer tous les commentaires d'un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article</param>
        /// <returns>Liste des commentaires</returns>
        public IEnumerable<Commentaire> Get(int articleId)
        {
            IEnumerable<CommentaireBLL> commentairesBll = commentaireBLL.GetCommentaires(articleId); 
            Mapper.CreateMap<CommentaireBLL, Commentaire>();
            IEnumerable<Commentaire> commentaires = Mapper.Map<IEnumerable<CommentaireBLL>, IEnumerable<Commentaire>>(commentairesBll);
            return commentaires;
        }

        // GET: api/Comment/5
        /// <summary>
        /// Récupérer un commentaire spécifique
        /// </summary>
        /// <param name="id">identifiant du commentaire</param>
        /// <returns>le commentaire</returns>
        public Commentaire GetById(int id)
        {
            CommentaireBLL commentaireBll = commentaireBLL.GetCommentaireById(id);
            Mapper.CreateMap<CommentaireBLL, Commentaire>();
            Commentaire commentaire = Mapper.Map<CommentaireBLL, Commentaire>(commentaireBll);

            return commentaire;
        }

        // POST: api/Comment
        /// <summary>
        /// Ajouter un commentaire
        /// </summary>
        /// <param name="comment">commentaire à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(Commentaire comment)
        {
            /*
            if (comment != null)
            {
                if (comment.Article_id == 0 || comment.Commentaire_id == 0 || comment.ContenuCommentaire == string.Empty)
                    return BadRequest("parameters format is not correct.");
                Mapper.CreateMap<Commentaire, CommentaireBLL>();
                CommentaireBLL commentaireBll = Mapper.Map<Commentaire, CommentaireBLL>(comment);
                if (adBLL.AddAd(commentBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
             */
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


            string resultat = commentaireBLL.ReportCommentaire(commentId, userId);
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
