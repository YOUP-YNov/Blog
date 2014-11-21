using ModuleBlog.DAL;
using System.Collections.Generic;
using AutoMapper;

namespace ModuleBlog.BLL
{
    /// <summary>
    /// Classe de gestion des commentaires de la couche BLL
    /// </summary>
    public class CommentaireBLL
    {
        /// <summary>
        /// instance de la DAL commentaire
        /// </summary>
        private CommentaireDAL commentaireDAL;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CommentaireBLL"/>.
        /// </summary>
        public CommentaireBLL()
        {
            commentaireDAL = new CommentaireDAL();
        }

        /// <summary>
        /// Récupérer les commentaires d'un article
        /// </summary>
        /// <param name="articleId">identifiant de l'article</param>
        /// <returns>Liste des Commentaire</returns>
        public List<ModuleBlog.BLL.Models.Commentaire> GetCommentaires(int articleId)
        {
            List<ModuleBlog.DAL.Models.Commentaire> listCommentaireDao = commentaireDAL.GetCommentaires(articleId);
            if (listCommentaireDao.Count > 0)
            {
                List<ModuleBlog.BLL.Models.Commentaire> listCommentaireBLL = Mapper.Map<List<ModuleBlog.DAL.Models.Commentaire>, List<ModuleBlog.BLL.Models.Commentaire>>(listCommentaireDao);
                return listCommentaireBLL;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Récupérer un commentaire par son identifiant
        /// </summary>
        /// <param name="commentaireId">identifiant du commentaire</param>
        /// <returns>Commentaire</returns>
        public ModuleBlog.BLL.Models.Commentaire GetCommentaireById(int commentaireId)
        {

            ModuleBlog.DAL.Models.Commentaire commentaireDao = commentaireDAL.GetCommentaireById(commentaireId);
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = Mapper.Map<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(commentaireDao);
            return commentaireBLL;
        }

        /// <summary>
        /// Ajouter un commentaire
        /// </summary>
        /// <param name="commentaireBLL">Commentaire</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool AddCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.AddCommentaire(commentaireDao);
        }

        /// <summary>
        /// Mettre à jour un commentaire
        /// </summary>
        /// <param name="commentaireBLL">Commentaire</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool UpdateCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.UpdateCommentaire(commentaireDao);
        }

        /// <summary>
        /// Désactiver un commentaire
        /// </summary>
        /// <param name="commentaireId">identifiant du commentaire</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool DeleteCommentaire(int commentaireId)
        {
            return commentaireDAL.DeleteCommentaire(commentaireId);
        }

        /// <summary>
        /// Signaler un commentaire
        /// </summary>
        /// <param name="commentId">Identifiant du commentaire</param>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool ReportCommentaire(int commentId,int userId)
        {
            return commentaireDAL.ReportCommentaire(commentId,userId);
        }
    }
}