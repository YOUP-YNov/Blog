using System;
using System.Collections.Generic;
using ModuleBlog.DAL;
using AutoMapper;

namespace ModuleBlog.BLL
{
    /// <summary>
    /// Classe de gestion des Blogs sur la couche BLL
    /// </summary>
    public class BlogBLL
    {
        /// <summary>
        /// Instance de la couche DAL des blogs
        /// </summary>
        private ModuleBlog.DAL.BlogDAL blogDAL;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BlogBLL"/>.
        /// </summary>
        public BlogBLL()
        {
            blogDAL = new ModuleBlog.DAL.BlogDAL();
        }

        /// <summary>
        /// Désactive un blog
        /// </summary>
        /// <param name="userId">L'identifiant de l'utilisateur</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool DeleteBlog(int userId)
        {
            return blogDAL.DeleteBlog(userId);
        }

        /// <summary>
        /// Récupérer un blog par son identifiant
        /// </summary>
        /// <param name="idBlog">identifiant du blog</param>
        /// <param name="userId">identifiant de l'utilisateur<param>
        /// <returns>Blog</returns>
        public ModuleBlog.BLL.Models.Blog GetBlogById(int idBlog, int userId)
        {
            ModuleBlog.DAL.Models.Blog blogDao = blogDAL.GetBlogById(idBlog, userId);
            ModuleBlog.BLL.Models.Blog blogBLL = Mapper.Map<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>(blogDao);
            return blogBLL;
        }

        /// <summary>
        /// Récupérer les blogs pour une catégorie
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>Liste des blogs de la catégorie</returns>
        public List<ModuleBlog.BLL.Models.Blog> GetBlogsByCategory(int categoryId)
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogsByCategory(categoryId);
            if (blogsDao.Count > 0)
            {   
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        /// <summary>
        /// Récupérer tous les blogs
        /// </summary>
        /// <returns>Liste des blogs</returns>
        public List<ModuleBlog.BLL.Models.Blog> GetBlogs()
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogs();
            if (blogsDao.Count > 0)
            {   
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        /// <summary>
        /// Récupérer les blogs selon une recherche
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <param name="keystring">chaine de caractère à rechercher</param>
        /// <returns>Liste des blogs</returns>
        public List<ModuleBlog.BLL.Models.Blog> GetBlogsBySearch(int categoryId, string keystring)
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogsBySearch(categoryId, keystring);
            if (blogsDao.Count > 0)
            {
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        /// <summary>
        /// Récupérer les blogs promus
        /// </summary>
        /// <returns>Liste des blogs</returns>
        public List<ModuleBlog.BLL.Models.Blog> GetPromotedBlogs()
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetPromotedBlogs();
            if (blogsDao.Count > 0)
            {
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        /// <summary>
        /// Promouvoir un blog
        /// </summary>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <param name="promoted"><c>true</c> si à promouvoir, <c>false</c> pour enlever le privilège</param>
        /// <returns></returns>
        public bool PromoteBlog(int userId, bool promoted)
        {
            return blogDAL.PromoteBlog(userId,promoted);
        }

        /// <summary>
        /// Mettre à jour un blog
        /// </summary>
        /// <param name="blog">Blog à mettre à jour</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool UpdateBlog(ModuleBlog.BLL.Models.Blog blog)
        {   
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            bool resultat = blogDAL.UpdateBlog(blogDao);
            return resultat;
        }

        /// <summary>
        /// Ajouter un blog
        /// </summary>
        /// <param name="blog">Blog à ajouter</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool AddBlog(ModuleBlog.BLL.Models.Blog blog)
        {   
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            bool resultat = blogDAL.AddBlog(blogDao);
            return resultat;
        }

        /// <summary>
        /// Récupérer le thème par un identifiant
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>Theme</returns>
        public ModuleBlog.BLL.Models.Theme GetThemeById(int themeId)
        {
            ModuleBlog.DAL.Models.Theme themeDao = new ThemeDAL().GetThemeById(themeId);
            ModuleBlog.BLL.Models.Theme themeBll = Mapper.Map<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>(themeDao);
            return themeBll;
        }

        /// <summary>
        /// Récupérer le blog d'un utilisateur
        /// </summary>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <returns>Blog</returns>
        public Models.Blog GetBlogByUserId(int userId)
        {
            ModuleBlog.DAL.Models.Blog blogDao = blogDAL.GetBlogByUserId(userId);
            if (blogDao.DateCreation > new DateTime(1, 1, 1, 0, 0, 0))
            {   
                ModuleBlog.BLL.Models.Blog blogBLL = Mapper.Map<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>(blogDao);
                return blogBLL;
            }
            else
                return null;
        }
    }
}