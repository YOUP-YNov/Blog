using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModuleBlog.DAL.Models;


namespace ModuleBlog.DAL
{
    public class ARTICLE_DAL
    { 
        //string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public ARTICLE_DAL()
        {
            string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
                   @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
            con = new SqlConnection(strcon);
        }

        public string DeleteArticle(int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DeleteArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ArticleId", articleId);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public List<ArticleDao> GetArticles(int idBlog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticles";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BlogId", idBlog);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                ArticleDao aDao = new ArticleDao();
                List<ArticleDao> listaDao = new List<ArticleDao>();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        aDao.Article_id = int.Parse(dr["Article_id"].ToString());
                        aDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        aDao.TitreArticle = dr["TitreArticle"].ToString();
                        aDao.ImageChemin = dr["ImageChemin"].ToString();
                        aDao.ContenuArticle = dr["ContenuArticle"].ToString();
                        aDao.Evenement_id = int.Parse(dr["Evenement_id"].ToString());
                        aDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                        aDao.DateModification = Convert.ToDateTime(dr["DateModification"].ToString());
                        aDao.Actif = bool.Parse(dr["Actif"].ToString());

                        // TODO : boucler sur la liste des tags et les ajouter à aDao.ListeTags
                    }
                    listaDao.Add(aDao);
                }
                con.Close();
                return listaDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public List<ArticleDao> GetArticlesByTag(string tag)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticlesByTag";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Tag", tag);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                ArticleDao aDao = new ArticleDao();
                List<ArticleDao> listaDao = new List<ArticleDao>();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        aDao.Article_id = int.Parse(dr["Article_id"].ToString());
                        aDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        aDao.TitreArticle = dr["TitreArticle"].ToString();
                        aDao.ImageChemin = dr["ImageChemin"].ToString();
                        aDao.ContenuArticle = dr["ContenuArticle"].ToString();
                        aDao.Evenement_id = int.Parse(dr["Evenement_id"].ToString());
                        aDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                        aDao.DateModification = Convert.ToDateTime(dr["DateModification"].ToString());
                        aDao.Actif = bool.Parse(dr["Actif"].ToString());

                        // TODO : boucler sur la liste des tags et les ajouter à aDao.ListeTags
                    }
                    listaDao.Add(aDao);
                }
                con.Close();
                return listaDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public List<ArticleDao> GetBlogsBySearch(string keystring)
        {
            ds = new DataSet();

            cmd= new SqlCommand();
            cmd.CommandText = "BLOG_GetArticlesBySearch";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@KeyString", keystring);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);

                ArticleDao aDao = new ArticleDao();
                List<ArticleDao> listaDao = new List<ArticleDao>();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        aDao.Article_id = int.Parse(dr["Article_id"].ToString());
                        aDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        aDao.TitreArticle = dr["TitreArticle"].ToString();
                        aDao.ImageChemin = dr["ImageChemin"].ToString();
                        aDao.ContenuArticle = dr["ContenuArticle"].ToString();
                        aDao.Evenement_id = int.Parse(dr["Evenement_id"].ToString());
                        aDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                        aDao.DateModification = Convert.ToDateTime(dr["DateModification"].ToString());
                        aDao.Actif = bool.Parse(dr["Actif"].ToString());

                        // TODO : boucler sur la liste des tags et les ajouter à aDao.ListeTags
                    }
                    listaDao.Add(aDao);
                }
                con.Close();
                return listaDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
           
        }
                
        public string UpdateArticle(ArticleDao article)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TitreArticle", article.TitreArticle);
            cmd.Parameters.AddWithValue("@ImageChemin", article.ImageChemin);
            cmd.Parameters.AddWithValue("@ContenuArticle", article.ContenuArticle);
            cmd.Parameters.AddWithValue("@Evenement_id", article.Evenement_id);
            cmd.Parameters.AddWithValue("@DateModification", article.DateModification);
            cmd.Parameters.AddWithValue("@Actif", article.Actif);

            da = new SqlDataAdapter(cmd);
           
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
        
        public string AddArticle(ArticleDao article)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Blog_id", article.Blog_id);
            cmd.Parameters.AddWithValue("@TitreArticle", article.TitreArticle);
            cmd.Parameters.AddWithValue("@ImageChemin", article.ImageChemin);
            cmd.Parameters.AddWithValue("@ContenuArticle", article.ContenuArticle);
            cmd.Parameters.AddWithValue("@Evenement_id", article.Evenement_id);
            cmd.Parameters.AddWithValue("@DateCreation", article.DateCreation);
            cmd.Parameters.AddWithValue("@DateModification", article.DateModification);
            cmd.Parameters.AddWithValue("@Actif", article.Actif);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string LikeArticle(LikeDao like)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_LikeArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", like.Utilisateur_id);
            cmd.Parameters.AddWithValue("@Article_id", like.Article_id);
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

    }
}