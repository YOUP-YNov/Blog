﻿using AutoMapper;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleBlog.BLL
{
    public class ArticleBLL
    {
        private ArticleDAL articleDal;
        public ArticleBLL()
        {
            articleDal = new ArticleDAL();
        }

        public ModuleBlog.BLL.Models.Articles GetArticles(int idUtilisateur, int idBlog)
        {
            ModuleBlog.DAL.Models.Articles articlesDao = articleDal.GetArticles(idUtilisateur, idBlog);
            if (articlesDao.Count > 0)
            {
                return Map(articlesDao);
            }

            return null;
        }

        public ModuleBlog.BLL.Models.Articles GetArticlesByTag(int idUtilisateur, string tag)
        {
            ModuleBlog.DAL.Models.Articles articlesDao = articleDal.GetArticlesByTag(idUtilisateur, tag);
            if (articlesDao.Count > 0)
            {
                return Map(articlesDao);
            }

            return null;
        }

        private ModuleBlog.BLL.Models.Articles Map(ModuleBlog.DAL.Models.Articles articlesToMap)
        {
            ModuleBlog.BLL.Models.Articles articlesBLL = new ModuleBlog.BLL.Models.Articles();

            if (articlesToMap.Count > 0) 
            {

                foreach (ModuleBlog.DAL.Models.Article article in articlesToMap)
                {
                    Mapper.CreateMap<ModuleBlog.DAL.Models.HashTagArticle, ModuleBlog.BLL.Models.HashTagArticle>();
                    List<ModuleBlog.BLL.Models.HashTagArticle> hashTagsBLL = Mapper.Map<List<ModuleBlog.DAL.Models.HashTagArticle>, List<ModuleBlog.BLL.Models.HashTagArticle>>(article.ListeTags);

                    Mapper.CreateMap<ModuleBlog.DAL.Models.Article, ModuleBlog.BLL.Models.Article>();
                    ModuleBlog.BLL.Models.Article articleBLL = Mapper.Map<ModuleBlog.DAL.Models.Article, ModuleBlog.BLL.Models.Article>(article);

                    articleBLL.ListeTags = hashTagsBLL;
                    articlesBLL.Add(articleBLL);
                }
            }

            return articlesBLL;
        }

        public bool LikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.LikeArticle(idUtilisateur, idArticle);
        }

        public bool DislikeArticle(int idUtilisateur, int idArticle)
        {
            return articleDal.DislikeArticle(idUtilisateur, idArticle);
        }

        public string AddArticle(ModuleBlog.BLL.Models.Article article)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>();
            ModuleBlog.DAL.Models.Article articleDao = Mapper.Map<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>(article);
            return articleDal.AddArticle(articleDao);
        }

        //TODO FAIRE LE UPDATE

        public bool DeleteArticle(int idArticle)
        {
            return articleDal.DeleteArticle(idArticle);
        }
    }
}