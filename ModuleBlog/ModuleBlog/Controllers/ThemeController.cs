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
    /// Contrôleur pour les themes de blog
    /// </summary>
    public class ThemeController : MapperConverter
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
        public ControllersModels.Theme Get(int themeId)
        {
            if (themeId == 0)
                return null;
            BLLModels.Theme themeBll = themeBLL.GetThemeById(themeId);
            ControllersModels.Theme theme = Convert<BLLModels.Theme, ControllersModels.Theme>(themeBll);
            return theme;
        }

        // GET: api/Theme
        /// <summary>
        /// Obtenir les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>thème correspondant</returns>
        public IEnumerable<ControllersModels.Theme> Get()
        {
            IEnumerable<BLLModels.Theme> themeBll = themeBLL.GetThemes();
            IEnumerable<ControllersModels.Theme> theme = Convert<IEnumerable<BLLModels.Theme>, IEnumerable<ControllersModels.Theme>>(themeBll);
            return theme;
        }
    }
}
