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
        private BlogBLL blogBLL;

        public BlogController()
        {
            blogBLL = new BlogBLL();
        }

        #region Map
        private IEnumerable<ModuleBlog.Controllers.Models.Blog> Map(IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL)
        {
            if (blogsBLL != null)
                return Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
            else
                return null;
        }

        private ModuleBlog.Controllers.Models.Blog Map(ModuleBlog.BLL.Models.Blog blogBLL)
        {
            if (blogBLL != null)
                return Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>(blogBLL);
            else
                return null;
        }

        private ModuleBlog.BLL.Models.Blog Map(ModuleBlog.Controllers.Models.Blog blog)
        {
            if (blog != null)
                return Mapper.Map<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>(blog);
            else
                return null;
        }
        #endregion


        // GET: api/Blog
        /// <summary>
        /// Récupérer la liste des blogs
        /// </summary>
        /// <returns>La liste des blogs</returns>
        [HttpGet, Route("api/blog")]
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> Get()
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogs();
            try
            {    
                IEnumerable<ModuleBlog.Controllers.Models.Blog> blogs = Map(blogsBLL);
                return blogs;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // GET: api/Blog/5
        /// <summary>
        /// Récupérer un blog par son identifiant (et indique qu'il a été visité)
        /// </summary>
        /// <param name="id">identifiant du blog</param>
        /// <param name="userId">identifiant de l'utilisateur connecté</param>
        /// <returns>le blog</returns>
        [Route("api/blog/{id}")]
        [HttpGet]
        public ModuleBlog.Controllers.Models.Blog GetById(int id, int userId)
        {
            ModuleBlog.BLL.Models.Blog blogBll = blogBLL.GetBlogById(id, userId);
            try
            {
                ModuleBlog.Controllers.Models.Blog blog = Map(blogBll);
                return blog;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Blog/User
        /// <summary>
        /// Récupérer un blog pour un utilisateur
        /// </summary>
        /// <param name="id">identifiant de l'utilisateur</param>
        /// <returns>le blog</returns>
        [Route("api/blog")]
        [HttpGet]
        public ModuleBlog.Controllers.Models.Blog GetById(int userId)
        {
            ModuleBlog.BLL.Models.Blog blogBll = blogBLL.GetBlogByUserId(userId);
            try
            {
                ModuleBlog.Controllers.Models.Blog blog = Map(blogBll);
                return blog;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Blog
        /// <summary>
        /// Récupérer la liste des blogs pour une catégorie
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>la liste des blogs</returns>
        [Route("api/blog/category/{categoryId}"), HttpGet]
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> GetByCategory(int categoryId)
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogsByCategory(categoryId);
            try
            {
                IEnumerable<ModuleBlog.Controllers.Models.Blog> blogs = Map(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // GET: api/Blog/Promoted
        /// <summary>
        /// Récupérer la liste des blogs mis en avant
        /// </summary>
        /// <returns>Liste des blogs</returns>
        [Route("api/blog/promoted")]
        [HttpGet]
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> GetPromoted()
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetPromotedBlogs();
            try
            {
                IEnumerable<ModuleBlog.Controllers.Models.Blog> blogs = Map(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET : api/Blog
        /// <summary>
        /// Effectuer une recherche de blog par noms
        /// </summary>
        /// <param name="keyword">chaine de caractère à chercher</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> Get(string keyword)
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogsBySearch(0, keyword);
            try
            {
                IEnumerable<ModuleBlog.Controllers.Models.Blog> blogs = Map(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET : api/Blog
        /// <summary>
        /// Effectuer une recherche de blog par noms pour une catégorie
        /// </summary>
        /// <param name="keyword">chaine de caractère à chercher</param>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>Liste des blogs</returns>
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> Get(string keyword, int categoryId)
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogsBySearch(categoryId, keyword);
            try
            {
                IEnumerable<ModuleBlog.Controllers.Models.Blog> blogs = Map(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // POST: api/Blog
        /// <summary>
        /// Ajouter un blog
        /// </summary>
        /// <param name="blog">le blog à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post([FromBody]ModuleBlog.Controllers.Models.Blog blog)
        {
            if (blog != null)
            {
                if (blog.Categorie_id == 0 || blog.Theme_id == 0
                    || blog.TitreBlog == string.Empty || blog.Utilisateur_id == 0)
                    return BadRequest("parameters format is not correct.");
                ThemeController tcontroller = new ThemeController();

                ModuleBlog.Controllers.Models.Theme theme = tcontroller.Get(blog.Theme_id);
                ModuleBlog.BLL.Models.Blog blogBll = Map(blog);
                if (blogBLL.AddBlog(blogBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        // PUT: api/Blog/5
        /// <summary>
        /// Mettre à jour un blog
        /// </summary>
        /// <param name="blog">Blog à modifier</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put([FromBody]ModuleBlog.Controllers.Models.Blog blog)
        {
            if (blog != null)
            {
                if (blog.Categorie_id == 0 || blog.Theme_id == 0
                    || blog.TitreBlog == string.Empty || blog.Utilisateur_id == 0)
                    return BadRequest("parameters format is not correct.");
                ThemeController tcontroller = new ThemeController();
                ModuleBlog.Controllers.Models.Theme theme = tcontroller.Get(blog.Theme_id);
                ModuleBlog.BLL.Models.Blog blogBll = Map(blog);
                if (blogBLL.UpdateBlog(blogBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        // PUT : api/Blog/5
        /// <summary>
        /// Promouvoir un blog
        /// </summary>
        /// <param name="id">identifiant du blog à promouvoir</param>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <param name="promoted">promouvoir = 1 (vrai)</param>
        /// <returns>Réponse HTTP</returns>
        [Route("api/Blog/{id}"), HttpPut]
        public IHttpActionResult Put(int id, int userId, bool promoted)
        {
            if (userId != 0)
            {
                if (blogBLL.PromoteBlog(userId, promoted))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        // PUT: api/Blog
        /// <summary>
        /// Désactiver un blog
        /// </summary>
        /// <param name="userId">identifiant de l'utilisateur dont on doit désactiver le blog</param>
        /// <returns>Réponse HTTP</returns>
        [HttpPut, Route("api/Blog")]
        public IHttpActionResult Delete(int userId)
        {
            if (userId != 0)
            {
                if (blogBLL.DeleteBlog(userId))
                    return Ok();
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        
    }
}
