using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void CreateMap()
        {
            CreateMapBlog();
            CreateMapTheme();
            CreateMapPublicite();
            CreateMapCommentaire();
            CreateMapCategory();
            CreateMapArticle();
        }
        private static void CreateMapBlog()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();            

            Mapper.CreateMap<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>();            
        }

        private static void CreateMapTheme()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();

            Mapper.CreateMap<ModuleBlog.Controllers.Models.Theme, ModuleBlog.BLL.Models.Theme>();
        }

        private static void CreateMapPublicite()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.Controllers.Models.Publicite>();

            Mapper.CreateMap<ModuleBlog.Controllers.Models.Publicite, ModuleBlog.BLL.Models.Publicite>();
        }

        private static void CreateMapCommentaire()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.Controllers.Models.Commentaire>();
            Mapper.CreateMap<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
           
        }

        private static void CreateMapCategory()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Categorie, ModuleBlog.Controllers.Models.Categorie>();
        }

        private static void CreateMapArticle()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.HashTagArticle, ModuleBlog.Controllers.Models.HashTagArticle>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Article, ModuleBlog.Controllers.Models.Article>();

            Mapper.CreateMap<ModuleBlog.Controllers.Models.HashTagArticle, ModuleBlog.BLL.Models.HashTagArticle>();
            Mapper.CreateMap<ModuleBlog.Controllers.Models.Article, ModuleBlog.BLL.Models.Article>();
        }
    }
}
