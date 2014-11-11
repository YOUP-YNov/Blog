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
    /// <summary>
    /// Contrôleur pour les catégories de blog
    /// </summary>
    public class CategorieController : ApiController
    {
        /// <summary>
        /// instance de la couche métiers des catégories
        /// </summary>
        private CategorieBLL categoryBLL;

        /// <summary>
        /// Constructeur de la classe 
        /// </summary>
        public CategorieController()
        {
            categoryBLL = new CategorieBLL();
        }

        // GET: api/Category
        /// <summary>
        /// Récupérer la liste des catégories
        /// </summary>
        /// <returns>liste des catégories</returns>
        public IEnumerable<ModuleBlog.Controllers.Models.Categorie> Get()
        {
            IEnumerable<ModuleBlog.BLL.Models.Categorie> categoriesBll = categoryBLL.GetCategories();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Categorie, ModuleBlog.Controllers.Models.Categorie>();
            IEnumerable<ModuleBlog.Controllers.Models.Categorie> categories = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Categorie>, IEnumerable<ModuleBlog.Controllers.Models.Categorie>>(categoriesBll);
            return categories;
        }
    }
}
