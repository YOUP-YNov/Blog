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
    public class COMMENTAIRE_BLL
    {
        // comment
         private COMMENTAIRE_DAL commentaireDAL;
        public COMMENTAIRE_BLL()
        {
            commentaireDAL = new COMMENTAIRE_DAL();
        }

        public List<CommentaireBLL> GetCommentaires(int articleId)
        {
            List<CommentaireDao> listCommentaireDao = commentaireDAL.GetCommentaires(articleId);
            Mapper.CreateMap<CommentaireDao, CommentaireBLL>();
            List<CommentaireBLL> listCommentaireBLL = Mapper.Map<List<CommentaireDao>,List<CommentaireBLL>>(listCommentaireDao);
            return listCommentaireBLL;
        }

        public CommentaireBLL GetCommentaireById(int commentaireId)
        {

            CommentaireDao commentaireDao = commentaireDAL.GetCommentaireById(commentaireId);
            Mapper.CreateMap<CommentaireDao, CommentaireBLL>();
            CommentaireBLL commentaireBLL = Mapper.Map<CommentaireDao, CommentaireBLL>(commentaireDao);
            return commentaireBLL;
        }

        public string AddCommentaire(CommentaireBLL commentaireBLL)
        {
            Mapper.CreateMap<CommentaireBLL, CommentaireDao>();
            CommentaireDao commentaireDao = Mapper.Map<CommentaireBLL, CommentaireDao>(commentaireBLL);
            string resultat = commentaireDAL.AddCommentaire(commentaireDao);
            return resultat;
        }

        public string UpdateCommentaire(CommentaireBLL commentaireBLL)
        {
            Mapper.CreateMap<CommentaireBLL, CommentaireDao>();
            CommentaireDao commentaireDao = Mapper.Map<CommentaireBLL, CommentaireDao>(commentaireBLL);
            string resultat = commentaireDAL.UpdateCommentaire(commentaireDao);
            return resultat;
        }

        public string DeleteCommentaire(int commentaireId)
        {
            string resultat = commentaireDAL.DeleteCommentaire(commentaireId);
            return resultat;
        }

        public string ReportCommentaire(int commentId,int userId)
        {
            string resultat = commentaireDAL.ReportCommentaire(commentId,userId);
            return resultat;
        }
    }
}