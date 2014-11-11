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
    public class ThemeBLL
    {
        /// <summary>
        /// instance de la couche DAL des themes
        /// </summary>
        private ThemeDAL themeDal;
        
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public ThemeBLL()
        {
            themeDal = new ThemeDAL();
        }

        /// <summary>
        /// Récupérer les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>Thème</returns>
        public ModuleBlog.BLL.Models.Theme GetThemeById(int themeId)
        {
            ModuleBlog.DAL.Models.Theme themeDao = themeDal.GetThemeById(themeId);
            if (themeDao != null)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>();
                ModuleBlog.BLL.Models.Theme themeBll = Mapper.Map<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>(themeDao);

                return themeBll;
            }
            return null;
        }
    }
}
