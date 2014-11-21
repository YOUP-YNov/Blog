using System;
using System.Collections.Generic;
using ModuleBlog.DAL;
using AutoMapper;

namespace ModuleBlog.BLL
{
    public class BlogBLL
    {
        private ModuleBlog.DAL.BlogDAL blogDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogBLL"/> class.
        /// </summary>
        public BlogBLL()
        {
            blogDAL = new ModuleBlog.DAL.BlogDAL();
        }

        /// <summary>
        /// Deletes the blog.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool DeleteBlog(int userId)
        {
            return blogDAL.DeleteBlog(userId);
        }

        /// <summary>
        /// Gets the blog by identifier.
        /// </summary>
        /// <param name="idBlog">The identifier blog.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public ModuleBlog.BLL.Models.Blog GetBlogById(int idBlog, int userId)
        {
            ModuleBlog.DAL.Models.Blog blogDao = blogDAL.GetBlogById(idBlog, userId);
            ModuleBlog.BLL.Models.Blog blogBLL = Mapper.Map<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>(blogDao);
            return blogBLL;
        }

        /// <summary>
        /// Gets the blogs by category.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
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
        /// Gets the blogs.
        /// </summary>
        /// <returns></returns>
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
        /// Gets the blogs by search.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="keystring">The keystring.</param>
        /// <returns></returns>
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
        /// Gets the promoted blogs.
        /// </summary>
        /// <returns></returns>
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
        /// Promotes the blog.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="promoted">if set to <c>true</c> [promoted].</param>
        /// <returns></returns>
        public bool PromoteBlog(int userId, bool promoted)
        {
            return blogDAL.PromoteBlog(userId,promoted);
        }

        /// <summary>
        /// Updates the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public bool UpdateBlog(ModuleBlog.BLL.Models.Blog blog)
        {   
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            bool resultat = blogDAL.UpdateBlog(blogDao);
            return resultat;
        }

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blog">The blog.</param>
        /// <returns></returns>
        public bool AddBlog(ModuleBlog.BLL.Models.Blog blog)
        {   
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            bool resultat = blogDAL.AddBlog(blogDao);
            return resultat;
        }

        /// <summary>
        /// Gets the theme by identifier.
        /// </summary>
        /// <param name="themeId">The theme identifier.</param>
        /// <returns></returns>
        public ModuleBlog.BLL.Models.Theme GetThemeById(int themeId)
        {
            ModuleBlog.DAL.Models.Theme themeDao = new ThemeDAL().GetThemeById(themeId);
            ModuleBlog.BLL.Models.Theme themeBll = Mapper.Map<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>(themeDao);
            return themeBll;
        }

        /// <summary>
        /// Gets the blog by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
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