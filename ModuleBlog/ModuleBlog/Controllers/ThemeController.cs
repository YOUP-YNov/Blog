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
        private THEME_BLL themeBLL;

        /// <summary>
        /// Constructeur de la classe 
        /// </summary>
        public ThemeController()
        {
            themeBLL = new THEME_BLL();
        }

        // GET: api/Theme
        /// <summary>
        /// Obtenir les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>thème correspondant</returns>
        public Theme Get(int themeId)
        {
            if (themeId == 0)
                return null;
            ThemeBLL themeBll = themeBLL.GetThemeById(themeId);
            Mapper.CreateMap<ThemeBLL, Theme>();
            Theme theme = Mapper.Map<ThemeBLL, Theme>(themeBll);
            return theme;
        }
    }
}
