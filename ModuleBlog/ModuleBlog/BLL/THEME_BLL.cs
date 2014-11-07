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
    /// Couche business pour obtenir un theme
    /// </summary>
    public class THEME_BLL
    {
        /// <summary>
        /// instance de la couche DAL des themes
        /// </summary>
        private THEME_DAL themeDal;
        
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public THEME_BLL()
        {
            themeDal = new THEME_DAL();
        }

        /// <summary>
        /// Récupération du theme par son identifiant
        /// </summary>
        /// <returns>Liste des catégories</returns>
        public ThemeBLL GetThemeById(int themeId)
        {
            ThemeDao themeDao = themeDal.GetThemeById(themeId);
            if (themeDao != null)
            {
                Mapper.CreateMap<ThemeDao, ThemeBLL>();
                ThemeBLL themeBll = Mapper.Map<ThemeDao, ThemeBLL>(themeDao);

                return themeBll;
            }
            return null;
        }
    }
}
