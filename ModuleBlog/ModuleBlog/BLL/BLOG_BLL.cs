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
    public class BLOG_BLL
    {
        private BLOG_DAL blogDAL;

        public BLOG_BLL()
        {
            blogDAL = new BLOG_DAL();
        }

        public string DeleteBlog(int userId)
        {
            string resultat = blogDAL.DeleteBlog(userId);
            return resultat;
        }

        public BlogBLL GetBlogById(int idBlog, int userId)
        {
            BlogDao blogDao = blogDAL.GetBlogById(idBlog, userId);

            Mapper.CreateMap<BlogDao, BlogBLL>();
            BlogBLL blogBll = Mapper.Map<BlogDao, BlogBLL>(blogDao);

            return blogBll;
        }

        public List<BlogBLL> GetBlogsByCategory(int categoryId)
        {
            List<BlogDao> blogsDao = blogDAL.GetBlogsByCategory(categoryId);
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<BlogDao, BlogBLL>();
                List<BlogBLL> blogsBll = Mapper.Map<List<BlogDao>, List<BlogBLL>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public List<BlogBLL> GetBlogs()
        {
            List<BlogDao> blogsDao = blogDAL.GetBlogs();
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<BlogDao, BlogBLL>();
                Mapper.CreateMap<ThemeDao, ThemeBLL>();
                List<BlogBLL> blogsBll = Mapper.Map<List<BlogDao>, List<BlogBLL>>(blogsDao);
                return blogsBll;
            }
            return null;
        }

        public List<BlogBLL> GetBlogsBySearch(int categoryId, string keystring)
        {
            List<BlogDao> blogsDao = blogDAL.GetBlogsBySearch(categoryId,keystring);
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<BlogDao, BlogBLL>();
                List<BlogBLL> blogsBll = Mapper.Map<List<BlogDao>, List<BlogBLL>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public List<BlogBLL> GetPromotedBlogs()
        {
            List<BlogDao> blogsDao = blogDAL.GetPromotedBlogs();
            if (blogsDao.Count > 0)
            {
                Mapper.CreateMap<BlogDao, BlogBLL>();
                List<BlogBLL> blogsBll = Mapper.Map<List<BlogDao>, List<BlogBLL>>(blogsDao);

                return blogsBll;
            }
            return null;
        }

        public string PromoteBlog(int userId, bool promoted)
        {
            string resultat = blogDAL.PromoteBlog(userId,promoted);
            return resultat;
        }
        
        public string UpdateBlog(BlogBLL blog)
        {
            Mapper.CreateMap<BlogBLL, BlogDao>();
            BlogDao blogDao = Mapper.Map<BlogBLL, BlogDao>(blog);
            string resultat = blogDAL.UpdateBlog(blogDao);
            return resultat;
        }

        public string AddBlog(BlogBLL blog)
        {
            Mapper.CreateMap<BlogBLL, BlogDao>();
            BlogDao blogDao = Mapper.Map<BlogBLL, BlogDao>(blog);
            string resultat = blogDAL.AddBlog(blogDao);
            return resultat;
        }

        public ThemeBLL GetThemeById(int themeId)
        {
            ThemeDao themeDao = blogDAL.GetThemeById(themeId);

            Mapper.CreateMap<ThemeDao, ThemeBLL>();
            ThemeBLL themeBll = Mapper.Map<ThemeDao, ThemeBLL>(themeDao);

            return themeBll;
        }
    }
}