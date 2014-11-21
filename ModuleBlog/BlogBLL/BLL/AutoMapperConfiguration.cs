﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace ModuleBlog.BLL
{
    public static class AutoMapperConfiguration
    {
        public static void CreateMap()
        {
            CreateMapArticle();
            CreateMapHashTag();
            CreateMapBlog();
            CreateMapCategorie();
            CreateMapCommentaire();
            CreateMapPublicite();
            CreateMapTheme();
            try
            {
                Mapper.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException e)
            {
                //new LErreur(e, "Blog/BLL/AutoMapperConfiguration", "AutoMapperConfigurationException", 1).Save("http://loggerasp.azurewebsites.net/");
            }
        }

        private static void CreateMapArticle()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Article, ModuleBlog.BLL.Models.Article>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>();
        }

        private static void CreateMapHashTag()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.HashTagArticle, ModuleBlog.BLL.Models.HashTagArticle>();
        }

        private static void CreateMapBlog()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>();
        }

        private static void CreateMapCategorie()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Categorie, ModuleBlog.BLL.Models.Categorie>();
        }

        private static void CreateMapCommentaire()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
        }

        private static void CreateMapPublicite()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Publicite, ModuleBlog.BLL.Models.Publicite>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
        }

        private static void CreateMapTheme()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.DAL.Models.Theme>();
        }
    }
}
