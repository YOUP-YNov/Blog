using AutoMapper;
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
        /// <summary>
        /// Create Maps for the BLL 
        /// </summary>
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

        /// <summary>
        /// Create maps for "Articles"
        /// </summary>
        private static void CreateMapArticle()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Article, ModuleBlog.BLL.Models.Article>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Article, ModuleBlog.DAL.Models.Article>();
        }

        /// <summary>
        /// Create maps for "Hashtags"
        /// </summary>
        private static void CreateMapHashTag()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.HashTagArticle, ModuleBlog.BLL.Models.HashTagArticle>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.HashTagArticle, ModuleBlog.DAL.Models.HashTagArticle>();
        }

        /// <summary>
        /// Create maps for "Blog"
        /// </summary>
        private static void CreateMapBlog()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>();
        }

        /// <summary>
        /// Create maps for "Categorie"
        /// </summary>
        private static void CreateMapCategorie()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Categorie, ModuleBlog.BLL.Models.Categorie>();
        }
        /// <summary>
        /// Create maps for "Commentaire"
        /// </summary>

        private static void CreateMapCommentaire()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.DAL.Models.Commentaire>();
        }

        /// <summary>
        /// Create maps for "Publicite"
        /// </summary>
        private static void CreateMapPublicite()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Publicite, ModuleBlog.BLL.Models.Publicite>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
        }

        /// <summary>
        /// Create maps for "Theme"
        /// </summary>
        private static void CreateMapTheme()
        {
            Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.DAL.Models.Theme>();
        }
    }
}
