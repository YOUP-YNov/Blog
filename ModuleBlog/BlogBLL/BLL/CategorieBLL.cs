using AutoMapper;
using ModuleBlog.DAL;
using System.Collections.Generic;

namespace ModuleBlog.BLL
{
    /// <summary>
    /// Couche business pour les catégories de blog
    /// </summary>
    public class CategorieBLL
    {
        /// <summary>
        /// instance de la couche DAL des catégories
        /// </summary>
        private CategorieDAL categoryDal;
        
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public CategorieBLL()
        {
            categoryDal = new CategorieDAL();
        }

        /// <summary>
        /// Récupération des catégories de la BDD
        /// </summary>
        /// <returns>Liste des catégories</returns>
        public List<ModuleBlog.BLL.Models.Categorie> GetCategories()
        {
            List<ModuleBlog.DAL.Models.Categorie> categoriesDao = categoryDal.GetCategories();
            if (categoriesDao.Count > 0)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Categorie, ModuleBlog.BLL.Models.Categorie>();
                List<ModuleBlog.BLL.Models.Categorie> categoriesBll = Mapper.Map<List<ModuleBlog.DAL.Models.Categorie>, List<ModuleBlog.BLL.Models.Categorie>>(categoriesDao);

                return categoriesBll;
            }
            return null;
        }
    }
}
