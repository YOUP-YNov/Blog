using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using AutoMapper;

namespace ModuleBlog.BLL
{
    public class BlogBLL
    {
        private ModuleBlog.DAL.BlogDAL blogDAL;

        public BlogBLL()
        {
            blogDAL = new ModuleBlog.DAL.BlogDAL();
        }

        public bool DeleteBlog(int userId)
        {
            return blogDAL.DeleteBlog(userId);
        }

        public ModuleBlog.BLL.Models.Blog GetBlogById(int idBlog, int userId)
        {
            ModuleBlog.DAL.Models.Blog blogDao = blogDAL.GetBlogById(idBlog, userId);

            Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
            ModuleBlog.BLL.Models.Blog blogBLL = Mapper.Map<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>(blogDao);

            return blogBLL;
        }

        public List<ModuleBlog.BLL.Models.Blog> GetBlogsByCategory(int categoryId)
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogsByCategory(categoryId);
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public List<ModuleBlog.BLL.Models.Blog> GetBlogs()
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogs();
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        public List<ModuleBlog.BLL.Models.Blog> GetBlogsBySearch(int categoryId, string keystring)
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetBlogsBySearch(categoryId, keystring);
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public List<ModuleBlog.BLL.Models.Blog> GetPromotedBlogs()
        {
            List<ModuleBlog.DAL.Models.Blog> blogsDao = blogDAL.GetPromotedBlogs();
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                List<ModuleBlog.BLL.Models.Blog> blogsBll = Mapper.Map<List<ModuleBlog.DAL.Models.Blog>, List<ModuleBlog.BLL.Models.Blog>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public bool PromoteBlog(int userId, bool promoted)
        {
            return blogDAL.PromoteBlog(userId,promoted);
        }
        
        public bool UpdateBlog(ModuleBlog.BLL.Models.Blog blog)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.DAL.Models.Theme>();
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            bool resultat = blogDAL.UpdateBlog(blogDao);
            return resultat;
        }

        public bool AddBlog(ModuleBlog.BLL.Models.Blog blog)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.DAL.Models.Theme>();
            ModuleBlog.DAL.Models.Blog blogDao = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.DAL.Models.Blog>(blog);
            //ThemeDao themeDao = Mapper.Map<ThemeBLL, ThemeDao>(blog.Theme);
            //blogDao.Theme = themeDao;
            bool resultat = blogDAL.AddBlog(blogDao);
            return resultat;
        }

        public ModuleBlog.BLL.Models.Theme GetThemeById(int themeId)
        {
            ModuleBlog.DAL.Models.Theme themeDao = blogDAL.GetThemeById(themeId);

            Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
            ModuleBlog.BLL.Models.Theme themeBll = Mapper.Map<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>(themeDao);

            return themeBll;
        }

        public Models.Blog GetBlogByUserId(int userId)
        {
            ModuleBlog.DAL.Models.Blog blogDao = blogDAL.GetBlogByUserId(userId);
            if (blogDao.DateCreation > new DateTime(1, 1, 1, 0, 0, 0))
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                ModuleBlog.BLL.Models.Blog blogBLL = Mapper.Map<ModuleBlog.DAL.Models.Blog, ModuleBlog.BLL.Models.Blog>(blogDao);

                return blogBLL;
            }
            else
                return null;
        }
    }
}