using ModuleBlog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL.Models;
using AutoMapper;

namespace ModuleBlog.BLL
{
    public class CommentaireBLL
    {
        
        private CommentaireDAL commentaireDAL;

        public CommentaireBLL()
        {
            commentaireDAL = new CommentaireDAL();
        }
        
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

        public ModuleBlog.BLL.Models.Commentaire GetCommentaireById(int commentaireId)
        {

            ModuleBlog.DAL.Models.Commentaire commentaireDao = commentaireDAL.GetCommentaireById(commentaireId);
            Mapper.CreateMap<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
            ModuleBlog.BLL.Models.Commentaire commentaireBLL = Mapper.Map<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>(commentaireDao);
            return commentaireBLL;
        }

        public bool AddCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.AddCommentaire(commentaireDao);
        }

        public bool UpdateCommentaire(ModuleBlog.BLL.Models.Commentaire commentaireBLL)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
            ModuleBlog.DAL.Models.Commentaire commentaireDao = Mapper.Map<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>(commentaireBLL);
            return commentaireDAL.UpdateCommentaire(commentaireDao);
        }

        public bool DeleteCommentaire(int commentaireId)
        {
            return commentaireDAL.DeleteCommentaire(commentaireId);
        }

        public bool ReportCommentaire(int commentId,int userId)
        {
            return commentaireDAL.ReportCommentaire(commentId,userId);
        }
    }
}