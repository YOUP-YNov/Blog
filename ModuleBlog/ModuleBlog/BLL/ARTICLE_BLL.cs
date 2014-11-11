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
                return Map(articlesDao);
            }

            return null;
        }

        public ArticlesBLL GetArticlesByTag(int idUtilisateur, string tag)
        {
            ArticlesDao articlesDao = articleDal.GetArticlesByTag(idUtilisateur, tag);
            if (articlesDao.Count > 0)
            {
                return Map(articlesDao);
            }

            return null;
        }

        private ArticlesBLL Map(ArticlesDao articlesToMap)
        {
            ArticlesBLL articlesBLL = new ArticlesBLL();

            if (articlesToMap.Count > 0) 
            {

                foreach (ArticleDao article in articlesToMap)
                {
                    Mapper.CreateMap<HashTagArticleDao, HashTagArticleBLL>();
                    List<HashTagArticleBLL> hashTagsBLL = Mapper.Map<List<HashTagArticleDao>, List<HashTagArticleBLL>>(article.ListeTags);

                    Mapper.CreateMap<ArticleDao, ArticleBLL>();
                    ArticleBLL articleBLL = Mapper.Map<ArticleDao, ArticleBLL>(article);

                    articleBLL.ListeTags = hashTagsBLL;
                    articlesBLL.Add(articleBLL);
                }
            }

            return articlesBLL;
        }

        public Boolean LikeArticle(int idUtilisateur, int idArticle)
        {
            return (articleDal.LikeArticle(idUtilisateur, idArticle) == "OK");
        }

        public Boolean DislikeArticle(int idUtilisateur, int idArticle)
        {
            return (articleDal.DislikeArticle(idUtilisateur, idArticle) == "OK");
        }

        public string AddArticle(ArticleBLL article)
        {
            Mapper.CreateMap<ArticleBLL, ArticleDao>();
            ArticleDao articleDao = Mapper.Map<ArticleBLL, ArticleDao>(article);
            return articleDal.AddArticle(articleDao);
        }

        public Boolean DeleteArticle(int idArticle)
        {
            return (articleDal.DeleteArticle(idArticle) == "OK");
        }
    }
}