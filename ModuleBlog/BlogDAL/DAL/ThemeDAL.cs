using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModuleBlog.DAL.Models;
using BlogDAL.DAL;


namespace ModuleBlog.DAL
{
    /// <summary>
    /// Couche DAL des catégories des blogs
    /// </summary>
    public class ThemeDAL : ControllerDAL
    {        
        /// <summary>
        /// Récupérer les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>Thème</returns>
        public Theme GetThemeById(int themeId)
        {
            try
            {
                FillData("BLOG_GetThemeById", ref ds, new Dictionary<string, object>() { {"@ThemeId", themeId} });
                Theme tDao = new Theme();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        tDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        tDao.Couleur = dr["Couleur"].ToString();
                        tDao.ImageChemin = dr["ImageChemin"].ToString();
                    }
                }
                return tDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ThemeDAL/GetThemeById", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Récupérer la liste des thèmes
        /// </summary>
        /// <returns>Liste des thèmes</returns>
        public List<Theme> GetThemes()
        {
            try
            {
                FillData("BLOG_GetThemes", ref ds);
                List<Theme> listDao = new List<Theme>();
                Theme tDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        tDao = new Theme();
                        tDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        tDao.Couleur = dr["Couleur"].ToString();
                        tDao.ImageChemin = dr["ImageChemin"].ToString();
                        listDao.Add(tDao);
                    }
                }
                return listDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ThemeDAL/GetThemes", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}