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
    public class CategoryController : ApiController
    {
        /// <summary>
        /// instance de la couche métiers des catégories
        /// </summary>
        private CATEGORIE_BLL categoryBLL;

        /// <summary>
        /// Constructeur de la classe 
        /// </summary>
        public CategoryController()
        {
            categoryBLL = new CATEGORIE_BLL();
        }

        // GET: api/Category
        /// <summary>
        /// Récupérer la liste des catégories
        /// </summary>
        /// <returns>liste des catégories</returns>
        public IEnumerable<Categorie> Get()
        {
            IEnumerable<CategorieBLL> categoriesBll = categoryBLL.GetCategories();
            Mapper.CreateMap<CategorieBLL, Categorie>();
            IEnumerable<Categorie> categories = Mapper.Map<IEnumerable<CategorieBLL>, IEnumerable<Categorie>>(categoriesBll);
            return categories;
        }
    }
}
