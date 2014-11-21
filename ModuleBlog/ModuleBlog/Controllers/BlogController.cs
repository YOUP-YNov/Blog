
using ModuleBlog.BLL;
using BLLModels = ModuleBlog.BLL.Models;
using ControllersModels = ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class BlogController : MapperConverter
    {
        private BLL.BlogBLL blogBLL;

        public BlogController()
        {
            blogBLL = new BLL.BlogBLL();
        }

        // GET: api/Blog
        /// <summary>
        /// Récupérer la liste des blogs
        /// </summary>
        /// <returns>La liste des blogs</returns>
        [HttpGet, Route("api/blog")]
        public IEnumerable<ControllersModels.Blog> sGet()
        {
            IEnumerable<BLLModels.Blog> blogsBLL = blogBLL.GetBlogs();
            try
            {    
                IEnumerable<ControllersModels.Blog> blogs = Convert<IEnumerable<BLLModels.Blog>, IEnumerable<ControllersModels.Blog>>(blogsBLL);
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
        public ControllersModels.Blog GetById(int id, int userId)
        {
            BLLModels.Blog blogBll = blogBLL.GetBlogById(id, userId);
            try
            {
                ControllersModels.Blog blog = Convert<BLLModels.Blog, ControllersModels.Blog>(blogBll);
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
        public ControllersModels.Blog GetById(int userId)
        {
            BLLModels.Blog blogBll = blogBLL.GetBlogByUserId(userId);
            try
            {
                ControllersModels.Blog blog = Convert<BLLModels.Blog, ControllersModels.Blog>(blogBll);
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
        public IEnumerable<ControllersModels.Blog> GetByCategory(int categoryId)
        {
            IEnumerable<BLLModels.Blog> blogsBLL = blogBLL.GetBlogsByCategory(categoryId);
            try
            {
                IEnumerable<ControllersModels.Blog> blogs = Convert<IEnumerable<BLLModels.Blog>, IEnumerable<ControllersModels.Blog>>(blogsBLL);
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
        public IEnumerable<ControllersModels.Blog> GetPromoted()
        {
            IEnumerable<BLLModels.Blog> blogsBLL = blogBLL.GetPromotedBlogs();
            try
            {
                IEnumerable<ControllersModels.Blog> blogs = Convert<IEnumerable<BLLModels.Blog>, IEnumerable<ControllersModels.Blog>>(blogsBLL);
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
        [HttpGet, Route("api/blog")]
        public IEnumerable<ControllersModels.Blog> Get(string keyword)
        {
            IEnumerable<BLLModels.Blog> blogsBLL = blogBLL.GetBlogsBySearch(0, keyword);
            try
            {
                IEnumerable<ControllersModels.Blog> blogs = Convert<IEnumerable<BLLModels.Blog>, IEnumerable<ControllersModels.Blog>>(blogsBLL);
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
        [HttpGet, Route("api/blog")]
        public IEnumerable<ControllersModels.Blog> Get(string keyword, int categoryId)
        {
            IEnumerable<BLLModels.Blog> blogsBLL = blogBLL.GetBlogsBySearch(categoryId, keyword);
            try
            {
                IEnumerable<ControllersModels.Blog> blogs = Convert<IEnumerable<BLLModels.Blog>, IEnumerable<ControllersModels.Blog>>(blogsBLL);
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
        [HttpPost, Route("api/blog")]
        public IHttpActionResult Post([FromBody]ControllersModels.Blog blog)
        {
            if (blog != null)
            {
                if (blog.Categorie_id == 0 || blog.Theme_id == 0
                    || blog.TitreBlog == string.Empty || blog.Utilisateur_id == 0)
                    return BadRequest("parameters format is not correct.");
                ThemeController tcontroller = new ThemeController();

                ControllersModels.Theme theme = tcontroller.Get(blog.Theme_id);
                BLLModels.Blog blogBll = Convert<ControllersModels.Blog, BLLModels.Blog>(blog);
                if (blogBLL.AddBlog(blogBll))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "add/get_blog";
                        uriB.Query = string.Format("id={0}&author={1}&category={3}", blog.Blog_id, blog.Utilisateur_id, blog.Categorie_id);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                        using ((HttpWebResponse)request.GetResponse()) { };
                    }catch(Exception e)
                    {
                        throw e;
                    }
                    return StatusCode(HttpStatusCode.Created);
                    
                }
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
        [HttpPut, Route("api/blog/{id}")]
        public IHttpActionResult Put([FromBody]ControllersModels.Blog blog)
        {
            if (blog != null)
            {
                if (blog.Categorie_id == 0 || blog.Theme_id == 0
                    || blog.TitreBlog == string.Empty || blog.Utilisateur_id == 0)
                    return BadRequest("parameters format is not correct.");
                ThemeController tcontroller = new ThemeController();
                ControllersModels.Theme theme = tcontroller.Get(blog.Theme_id);
                BLLModels.Blog blogBll = Convert<ControllersModels.Blog, BLLModels.Blog>(blog);
                if (blogBLL.UpdateBlog(blogBll))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "update/get_blog";
                        uriB.Query = string.Format("id={0}&author={1}&category={3}", blog.Blog_id, blog.Utilisateur_id, blog.Categorie_id);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                        using ((HttpWebResponse)request.GetResponse()) { };
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    return StatusCode(HttpStatusCode.Created);
                }
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
        [Route("api/blog/promoted/{id}"), HttpPut]
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
        [HttpPut, Route("api/blog")]
        public IHttpActionResult Delete(int userId)
        {
            if (userId != 0)
            {
                if (blogBLL.DeleteBlog(userId))
                {
                    try
                    {
                        UriBuilder uriB = new UriBuilder();
                        uriB.Host = "www.youp-recherche.azurewebsites.net";
                        uriB.Path = "remove/get_blog";
                        uriB.Query = string.Format("id={0}", userId);
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriB.Uri);
                        using ((HttpWebResponse)request.GetResponse()) { };
                    }
                    catch (Exception e)
                    {
                        throw ;
                    }
                    return Ok();
                }
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }
    }
}
