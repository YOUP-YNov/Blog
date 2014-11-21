using ModuleBlog.DAL;
using System.Collections.Generic;
using AutoMapper;

namespace ModuleBlog.BLL
{
    public class CommentaireBLL
    {
        
        private CommentaireDAL commentaireDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentaireBLL"/> class.
        /// </summary>
        public CommentaireBLL()
        {
            commentaireDAL = new CommentaireDAL();
        }

        /// <summary>
        /// Gets the commentaires.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public List<ModuleBlog.BLL.Models.Commentaire> GetCommentaires(int articleId)
        {
            List<ModuleBlog.DAL.Models.Commentaire> listCommentaireDao = commentaireDAL.GetCommentaires(articleId);
            if (listCommentaireDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
                List<ModuleBlog.BLL.Models.Commentaire> listCommentaireBLL = Mapper.Map<List<ModuleBlog.DAL.Models.Commentaire>, List<ModuleBlog.BLL.Models.Commentaire>>(listCommentaireDao);
                return listCommentaireBLL;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the commentaire by identifier.
        /// </summary>
        /// <param name="commentaireId">The commentaire identifier.</param>
        /// <returns></returns>
        public ModuleBlog.BLL.Models.Commentaire GetCommentaireById(int commentaireId)
        {

            ModuleBlog.DAL.Models.Commentaire commentaireDao = commentaireDAL.GetCommentaireById(commentaireId);
            Mapper.CreateMap<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = Mapper.Map<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(commentaireDao);
            return commentaireBLL;
        }

        /// <summary>
        /// Adds the commentaire.
        /// </summary>
        /// <param name="commentaireBLL">The commentaire BLL.</param>
        /// <returns></returns>
        public bool AddCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.AddCommentaire(commentaireDao);
        }

        /// <summary>
        /// Updates the commentaire.
        /// </summary>
        /// <param name="commentaireBLL">The commentaire BLL.</param>
        /// <returns></returns>
        public bool UpdateCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.UpdateCommentaire(commentaireDao);
        }

        /// <summary>
        /// Deletes the commentaire.
        /// </summary>
        /// <param name="commentaireId">The commentaire identifier.</param>
        /// <returns></returns>
        public bool DeleteCommentaire(int commentaireId)
        {
            return commentaireDAL.DeleteCommentaire(commentaireId);
        }

        /// <summary>
        /// Reports the commentaire.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool ReportCommentaire(int commentId,int userId)
        {
            return commentaireDAL.ReportCommentaire(commentId,userId);
        }
    }
}