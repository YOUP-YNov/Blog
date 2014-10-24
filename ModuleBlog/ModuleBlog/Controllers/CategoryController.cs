using ModuleBlog.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        /// <summary>
        /// Récupérer la liste des catégories
        /// </summary>
        /// <returns>liste des catégories</returns>
        public IEnumerable<Categorie> Get()
        {
            return null;
        }
    }
}
