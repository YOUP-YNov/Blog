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
    public class CATEGORIE_BLL
    {
        private CATEGORIE_DAL categoryDal;
        public CATEGORIE_BLL()
        {
            categoryDal = new CATEGORIE_DAL();
        }

        public List<CategorieBLL> GetCategories()
        {
            List<CategorieDao> categoriesDao = categoryDal.GetCategories();
            Mapper.CreateMap<CategorieDao, CategorieBLL>();
            List<CategorieBLL> categoriesBll = Mapper.Map<List<CategorieDao>, List<CategorieBLL>>(categoriesDao);
            
            return categoriesBll;
        }
    }
}
