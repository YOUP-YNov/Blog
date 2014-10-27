using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ModuleBlog.DAL
{
    public class COMMENTAIRE_DAL
    {
   
        string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
               @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
       // string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmd = null;
     
        SqlConnection con;
        SqlDataAdapter da;

        public COMMENTAIRE_DAL(){
            con = new SqlConnection(strcon);
        }
        public string DeleteCommentaire(int commentaireId)
        {
            DataSet ds = new DataSet();
            string result = "";
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DeleteCommentaire";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CommentaireId", commentaireId);
           
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }


        public string GetCommentaireById(int commentaireId)
        {
            DataSet ds = new DataSet();
            string result = "";
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetCommentaireById";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@CommentaireId", commentaireId);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }

    }
}