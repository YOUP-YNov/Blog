using AutoMapper;
using ModuleBlog.BLL;
using BLLModels = ModuleBlog.BLL.Models;
using ControllersModels = ModuleBlog.Controllers.Models;
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
    public class CategorieController : MapperConverter
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
        [HttpGet, Route("api/Category")]
        public IEnumerable<ControllersModels.Categorie> Get()
        {
            IEnumerable<BLLModels.Categorie> categoriesBll = categoryBLL.GetCategories();
            IEnumerable<ControllersModels.Categorie> categories = Convert<IEnumerable<BLLModels.Categorie>, IEnumerable<ControllersModels.Categorie>>(categoriesBll);
            return categories;
        }
    }
}
