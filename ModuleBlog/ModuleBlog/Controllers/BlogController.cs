using AutoMapper;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;
using ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class BlogController : ApiController
    {
        private BLOG_BLL blogBLL;

        public BlogController()
        {
            blogBLL = new BLOG_BLL();
        }

        // GET: api/Blog
        /// <summary>
        /// Récupérer la liste des blogs
        /// </summary>
        /// <returns>La liste des blogs</returns>
        public IEnumerable<Blog> Get()
        {
            IEnumerable<BlogBLL> blogsBLL = blogBLL.GetBlogs();
            try
            {
                Mapper.CreateMap<BlogBLL, Blog>();
                Mapper.CreateMap<ThemeBLL, Theme>();    
                List<Blog> blogs = Mapper.Map<IEnumerable<BlogBLL>, List<Blog>>(blogsBLL);
                return blogs;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // GET: api/BlogById/5
        /// <summary>
        /// Récupérer un blog par son identifiant (et indique qu'il a été visité)
        /// </summary>
        /// <param name="id">identifiant du blog</param>
        /// <param name="userId">identifiant de l'utilisateur connecté</param>
        /// <returns>le blog</returns>
        [Route("api/blog/{id}")]
        [HttpGet]
        public Blog GetById(int id, int userId)
        {
            BlogBLL blogBll = blogBLL.GetBlogById(id, userId);
            try
            {
                Mapper.CreateMap<BlogBLL, Blog>();
                Mapper.CreateMap<ThemeBLL, Theme>();
                Blog blog = Mapper.Map<BlogBLL, Blog>(blogBll);
                return blog;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/BlogByCategory/5
        /// <summary>
        /// Récupérer la liste des blogs pour une catégorie
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>la liste des blogs</returns>
        public IEnumerable<Blog> GetByCategory(int categoryId)
        {
            return null;
        }


        // GET: api/PromotedBlogs
        /// <summary>
        /// Récupérer la liste des blogs mis en avant
        /// </summary>
        /// <param name="promoted">blog mis en avant = vrai</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Blog> Get(bool promoted)
        {
            return null;
        }

        // GET : api/Blog/
        /// <summary>
        /// Effectuer une recherche de blog par noms
        /// </summary>
        /// <param name="keyword">chaine de caractère à chercher</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Blog> Get(string keyword)
        {
            return null;
        }

        /// <summary>
        /// Effectuer une recherche de blog par noms pour une catégorie
        /// </summary>
        /// <param name="keyword">chaine de caractère à chercher</param>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<Blog> Get(string keyword, int categoryId)
        {
            return null;
        }


        // POST: api/Blog
        /// <summary>
        /// Ajouter un blog
        /// </summary>
        /// <param name="blog">le blog à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(Blog blog)
        {
            return Ok();
        }

        // PUT: api/UpdateBlog
        /// <summary>
        /// Mettre à jour un blog
        /// </summary>
        /// <param name="blog">Blog à modifier</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(Blog blog)
        {
            return Ok();
        }

        // PUT : api/UpdateBlog
        /// <summary>
        /// Promouvoir un blog
        /// </summary>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <param name="Promoted">promouvoir = 1 (vrai)</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(int userId, bool Promoted)
        {
            return Ok();
        }

        // PUT: api/DisableBlog/5
        /// <summary>
        /// Désactiver un blog
        /// </summary>
        /// <param name="id">identifiant du blog à désactiver</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }

        
    }
}
