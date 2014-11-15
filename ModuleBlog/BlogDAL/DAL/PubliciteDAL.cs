using BlogDAL.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModuleBlog.DAL
{
    /// <summary>
    /// DAL pour les publicités
    /// </summary>
    public class PubliciteDAL : ControllerDAL
    { 
        // implicite :
        //public PubliciteDAL()
        //    : base()
        //{}

        /// <summary>
        /// Récupérer une publicité pour un blog
        /// </summary>
        /// <param name="BlogId">identifiant du blog</param>
        /// <returns>publicité</returns>
        public Publicite GetAdByBlogId(int BlogId)
        {
            try
            {
                cmd.CommandText = "BLOG_GetAdByBlogId";
                cmd.Parameters.AddWithValue("@BlogId", BlogId);
                da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(ds);
                Publicite pDao = new Publicite();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        pDao.Publicite_id = int.Parse(dr["Publicite_id"].ToString());
                        pDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        pDao.Largeur = int.Parse(dr["Largeur"].ToString());
                        pDao.Hauteur = int.Parse(dr["Hauteur"].ToString());
                        pDao.ContenuPublicite = dr["ContenuPublicite"].ToString();
                    }
                }
                return pDao;
            }
            catch (SqlException ex)
            {
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Ajouter une publicité à un blog
        /// </summary>
        /// <param name="ad">Publicité</param>
        /// <returns>True si created / False sinon</returns>
        public bool AddAd(Publicite ad)
        {           
            try
            {
                cmd.CommandText = "BLOG_AddAd";            
                cmd.Parameters.AddWithValue("@BlogId", ad.Blog_id);
                cmd.Parameters.AddWithValue("@Largeur", ad.Largeur);
                cmd.Parameters.AddWithValue("@Hauteur", ad.Hauteur);
                cmd.Parameters.AddWithValue("@ContenuPublicite", ad.ContenuPublicite);
                da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(ds);

                return (Convert.ToBoolean(ds.Tables[0].Rows[0][0]));
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Mettre à jour une publicité
        /// </summary>
        /// <param name="ad">publicité</param>
        /// <returns>True si updated / False sinon</returns>
        public bool UpdateAd(Publicite ad)
        {
            try
            {
                cmd.CommandText = "BLOG_UpdateAd";
                cmd.Parameters.AddWithValue("@PubliciteId", ad.Publicite_id);
                cmd.Parameters.AddWithValue("@Largeur", ad.Largeur);
                cmd.Parameters.AddWithValue("@Hauteur", ad.Hauteur);
                cmd.Parameters.AddWithValue("@ContenuPublicite", ad.ContenuPublicite);
                da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(ds);
                return (Convert.ToBoolean(ds.Tables[0].Rows[0][0]));
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}