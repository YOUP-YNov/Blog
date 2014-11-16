using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModuleBlog.DAL.Models;
using BlogDAL.DAL;
using Logger;


namespace ModuleBlog.DAL
{
    /// <summary>
    /// Couche DAL des catégories des blogs
    /// </summary>
    public class ThemeDAL
    {
        #region propriétés
        //string strcon = Connector.ConnectionString;
        /// <summary>
        /// Objet permettant d'effecture des requêtes à la BDD
        /// </summary>
        SqlCommand cmd;
        /// <summary>
        /// Objet de gestion de la connexion à la BDD
        /// </summary>
        SqlConnection con;
        /// <summary>
        /// Objet Tableau recevant les données récupérées par la requête
        /// </summary>
        SqlDataAdapter da;
        /// <summary>
        /// Dataset que l'on rempli grâce au SqlDataAdapter permettant de naviguer entre les lignes et colonnes
        /// </summary>
        DataSet ds; 
        #endregion

        string loggerUrl = "http://loggerasp.azurewebsites.net/";

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public ThemeDAL()
        {
            string strcon = Connector.ConnectionString;
            con = new SqlConnection(strcon);
        }
        
        /// <summary>
        /// Récupérer les informations d'un thème
        /// </summary>
        /// <param name="themeId">identifiant du thème</param>
        /// <returns>Thème</returns>
        public Theme GetThemeById(int themeId)
        {
            ds = new DataSet();
            
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetThemeById";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ThemeId", themeId);
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
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

                    con.Close();
                    return tDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ThemeDAL/GetThemeById", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return null;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ThemeDAL/GetThemeById", "Connexion à la BDD", 3).Save(loggerUrl);
                return null;
            }
        }

        public List<Theme> GetThemes()
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetThemes";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
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

                    con.Close();
                    return listDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ThemeDAL/GetThemes", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return null;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ThemeDAL/GetThemes", "Connexion à la BDD", 3).Save(loggerUrl);
                return null;
            }
        }
    }
}