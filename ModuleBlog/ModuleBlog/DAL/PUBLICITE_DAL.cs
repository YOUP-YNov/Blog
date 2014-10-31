using ModuleBlog.Controllers.Models;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ModuleBlog.DAL
{
    public class PUBLICITE_DAL
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public PUBLICITE_DAL()
        {
            string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
                   @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
            con = new SqlConnection(strcon);
        }


        public PubliciteDao GetAdByBlogId(int BlogId)
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
                da.Fill(ds);
                PubliciteDao pDao = new PubliciteDao();

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
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string UpdateAd(int publiciteId, int largeur, int hauteur, string contenu)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateAd";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@PubliciteId", publiciteId);
            cmd.Parameters.AddWithValue("@Largeur", largeur);
            cmd.Parameters.AddWithValue("@Hauteur", hauteur);
            cmd.Parameters.AddWithValue("@ContenuPublicite", contenu);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0]["Resultat"].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string AddAd(int blogId, int largeur, int hauteur, string contenu)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddAd";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            cmd.Parameters.AddWithValue("@Largeur", largeur);
            cmd.Parameters.AddWithValue("@Hauteur", hauteur);
            cmd.Parameters.AddWithValue("@ContenuPublicite", contenu);


            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                
                return ds.Tables[0].Rows[0]["Resultat"].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
    }
}