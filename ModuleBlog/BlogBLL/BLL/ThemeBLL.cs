using AutoMapper;
using ModuleBlog.DAL;
using System.Collections.Generic;


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
                ModuleBlog.BLL.Models.Theme themeBll = Mapper.Map<ModuleBlog.DAL.Models.Theme, ModuleBlog.BLL.Models.Theme>(themeDao);
                return themeBll;
            }
            return null;
        }

        /// <summary>
        /// Gets the themes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Theme> GetThemes()
        {
            List<ModuleBlog.DAL.Models.Theme> themeDao = themeDal.GetThemes();
            if (themeDao.Count > 0)
            {
                IEnumerable<ModuleBlog.BLL.Models.Theme> themeBll = Mapper.Map<IEnumerable<ModuleBlog.DAL.Models.Theme>, IEnumerable<ModuleBlog.BLL.Models.Theme>>(themeDao);
                return themeBll;
            }
            return null;
        }
    }
}
