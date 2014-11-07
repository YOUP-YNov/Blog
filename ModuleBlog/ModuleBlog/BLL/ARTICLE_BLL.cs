using AutoMapper;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleBlog.BLL
{
    public class ARTICLE_BLL
    {
        private ARTICLE_DAL articleDal;
        public ARTICLE_BLL()
        {
            articleDal = new ARTICLE_DAL();
        }

        public ArticlesBLL GetArticles(int idUtilisateur, int idBlog)
        {
            ArticlesDao articlesDao = articleDal.GetArticles(idUtilisateur, idBlog);
            if (articlesDao.Count > 0)
            {
                Mapper.CreateMap<ArticlesDao, ArticlesBLL>();
                ArticlesBLL articlesBLL = Mapper.Map<ArticlesDao, ArticlesBLL>(articlesDao);

                return articlesBLL;
            }

            return null;
        }

        public ArticlesBLL GetArticles(int idUtilisateur, int idBlog)
        {
            ArticlesDao articlesDao = articleDal.GetArticles(idUtilisateur, idBlog);
            if (articlesDao.Count > 0)
            {
                Mapper.CreateMap<ArticlesDao, ArticlesBLL>();
                ArticlesBLL articlesBLL = Mapper.Map<ArticlesDao, ArticlesBLL>(articlesDao);

                return articlesBLL;
            }

            return null;
        }

        public ArticlesBLL GetArticlesByTag(int idUtilisateur, string tag)
        {
            ArticlesDao articlesDao = articleDal.GetArticlesByTag(idUtilisateur, tag);
            if (articlesDao.Count > 0)
            {
                Mapper.CreateMap<ArticlesDao, ArticlesBLL>();
                ArticlesBLL articlesBLL = Mapper.Map<ArticlesDao, ArticlesBLL>(articlesDao);

                return articlesBLL;
            }

            return null;
        }

        public string LikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.LikeArticle(idUtilisateur, idArticle);
        }

        public string DislikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.DislikeArticle(idUtilisateur, idArticle);
        }

        public string AddArticle(ArticleBLL article)
        {
            Mapper.CreateMap<ArticleBLL, ArticleDao>();
            ArticleDao articleDao = Mapper.Map<ArticleBLL, ArticleDao>(article);
            return articleDal.AddArticle(articleDao);
        }

        public string DeleteArticle(int idArticle)
        {
            return articleDal.DeleteArticle(idArticle);
        }
    }
}