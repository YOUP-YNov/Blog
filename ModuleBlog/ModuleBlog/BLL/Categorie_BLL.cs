using AutoMapper;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL
{
    /// <summary>
    /// Couche business pour les catégories de blog
    /// </summary>
    public class CATEGORIE_BLL
    {
        /// <summary>
        /// instance de la couche DAL des catégories
        /// </summary>
        private CATEGORIE_DAL categoryDal;
        
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public CATEGORIE_BLL()
        {
            categoryDal = new CATEGORIE_DAL();
        }

        /// <summary>
        /// Récupération des catégories de la BDD
        /// </summary>
        /// <returns>Liste des catégories</returns>
        public List<CategorieBLL> GetCategories()
        {
            List<CategorieDao> categoriesDao = categoryDal.GetCategories();
            if (categoriesDao.Count > 0)
            {
                Mapper.CreateMap<CategorieDao, CategorieBLL>();
                List<CategorieBLL> categoriesBll = Mapper.Map<List<CategorieDao>, List<CategorieBLL>>(categoriesDao);

                return categoriesBll;
            }
            return null;
        }
    }
}
