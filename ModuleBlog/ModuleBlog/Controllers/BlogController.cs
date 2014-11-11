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

        // GET: api/ModuleBlog.Controllers.Models.Blog
        /// <summary>
        /// Récupérer la liste des blogs
        /// </summary>
        /// <returns>La liste des blogs</returns>
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> Get()
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogs();
            try
            {
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();    
                List<ModuleBlog.Controllers.Models.Blog> blogs = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
                return blogs;
            }
            catch(Exception)
            {
                return null;
            }
        }

        // GET: api/ModuleBlog.Controllers.Models.Blog/5
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
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
                ModuleBlog.Controllers.Models.Blog blog = Mapper.Map<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>(blogBll);
                return blog;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/ModuleBlog.Controllers.Models.Blog/5
        /// <summary>
        /// Récupérer la liste des blogs pour une catégorie
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>la liste des blogs</returns>
        [Route("api/blog/{id}")]
        [HttpGet]
        public IEnumerable<ModuleBlog.Controllers.Models.Blog> GetByCategory(int id, int categoryId)
        {
            IEnumerable<ModuleBlog.BLL.Models.Blog> blogsBLL = blogBLL.GetBlogsByCategory(categoryId);
            try
            {
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
                List<ModuleBlog.Controllers.Models.Blog> blogs = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // GET: api/ModuleBlog.Controllers.Models.Blog/Promoted
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
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
                List<ModuleBlog.Controllers.Models.Blog> blogs = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET : api/ModuleBlog.Controllers.Models.Blog
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
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
                List<ModuleBlog.Controllers.Models.Blog> blogs = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET : api/ModuleBlog.Controllers.Models.Blog
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
                Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
                List<ModuleBlog.Controllers.Models.Blog> blogs = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Blog>, List<ModuleBlog.Controllers.Models.Blog>>(blogsBLL);
                return blogs;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // POST: api/ModuleBlog.Controllers.Models.Blog
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
                Mapper.CreateMap<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.Controllers.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                ModuleBlog.BLL.Models.Blog blogBll = Mapper.Map<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>(blog);
                
                if (blogBLL.AddBlog(blogBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        // PUT: api/UpdateBlog
        /// <summary>
        /// Mettre à jour un blog
        /// </summary>
        /// <param name="blog">ModuleBlog.Controllers.Models.Blog à modifier</param>
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
                Mapper.CreateMap<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>();
                Mapper.CreateMap<ModuleBlog.Controllers.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                ModuleBlog.BLL.Models.Blog blogBll = Mapper.Map<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>(blog);
                if (blogBLL.UpdateBlog(blogBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
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
