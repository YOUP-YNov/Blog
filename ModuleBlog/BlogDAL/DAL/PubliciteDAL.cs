using BlogDAL.DAL;
using Logger;
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
    public class PubliciteDAL
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        string strcon = Connector.ConnectionString;
        string loggerUrl = "http://loggerasp.azurewebsites.net/";

        public PubliciteDAL()
        {
            con = new SqlConnection(strcon);
        }


        public Publicite GetAdByBlogId(int BlogId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetAdByBlogId";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BlogId", BlogId);


            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
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
                    con.Close();
                    return pDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/PubliciteDAL/GetAdById", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return null;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/PubliciteDAL/GetAdById", "Connexion à la BDD", 3).Save(loggerUrl);
                return null;
            }
        }

        public bool AddAd(Publicite ad)//int blogId, int largeur, int hauteur, string contenu)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddAd";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BlogId", ad.Blog_id);
            cmd.Parameters.AddWithValue("@Largeur", ad.Largeur);
            cmd.Parameters.AddWithValue("@Hauteur", ad.Hauteur);
            cmd.Parameters.AddWithValue("@ContenuPublicite", ad.ContenuPublicite);


            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
                    con.Close();
                    return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
                }
                catch (Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/PubliciteDAL/AddAd", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/PubliciteDAL/AddAd", "Connexion à la BDD", 3).Save(loggerUrl);
                return false;
            }
        }

        public bool UpdateAd(Publicite ad)//int publiciteId, int largeur, int hauteur, string contenu)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateAd";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PubliciteId", ad.Publicite_id);
            cmd.Parameters.AddWithValue("@Largeur", ad.Largeur);
            cmd.Parameters.AddWithValue("@Hauteur", ad.Hauteur);
            cmd.Parameters.AddWithValue("@ContenuPublicite", ad.ContenuPublicite);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
                    con.Close();
                    return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/PubliciteDAL/UpdateAd", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/PubliciteDAL/UpdateAd", "Connexion à la BDD", 3).Save(loggerUrl);
                return false;
            }
        }
    }
}