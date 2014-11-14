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
    /// Contrôleur pour les themes de blog
    /// </summary>
    public class ThemeController : ApiController
    {
        /// <summary>
        /// instance de la couche métiers des thèmes
        /// </summary>
        private ThemeBLL themeBLL;

        /// <summary>
        /// Constructeur de la classe 
        /// </summary>
        public ThemeController()
        {
            themeBLL = new ThemeBLL();
        }

        // GET: api/Theme
        /// <summary>
        /// Obtenir les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>thème correspondant</returns>
        public ModuleBlog.Controllers.Models.Theme Get(int themeId)
        {
            if (themeId == 0)
                return null;
            ModuleBlog.BLL.Models.Theme themeBll = themeBLL.GetThemeById(themeId);
            ModuleBlog.Controllers.Models.Theme theme = Mapper.Map<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>(themeBll);
            return theme;
        }

        // GET: api/Theme
        /// <summary>
        /// Obtenir les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>thème correspondant</returns>
        public IEnumerable<ModuleBlog.Controllers.Models.Theme> Get()
        {
            IEnumerable<ModuleBlog.BLL.Models.Theme> themeBll = themeBLL.GetThemes();
            IEnumerable<ModuleBlog.Controllers.Models.Theme> theme = Mapper.Map<IEnumerable<ModuleBlog.BLL.Models.Theme>, IEnumerable<ModuleBlog.Controllers.Models.Theme>>(themeBll);
            return theme;
        }
    }
}
