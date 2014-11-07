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
        string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public ARTICLE_DAL()
        {
            con = new SqlConnection(strcon);
        }

        public ArticlesDao GetArticles(int idUtilisateur, int idBlog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticles";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UtilisateurId", idUtilisateur);
            cmd.Parameters.AddWithValue("@BlogId", idBlog);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                ArticlesDao listaDao = new ArticlesDao();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        ArticleDao aDao = new ArticleDao();

                        aDao.Article_id = int.Parse(dr["Article_id"].ToString());

                        if (!listaDao.Contains(aDao))
                        {
                            aDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                            aDao.TitreArticle = dr["TitreArticle"].ToString();
                            aDao.ImageChemin = dr["ImageChemin"].ToString();
                            aDao.ContenuArticle = dr["ContenuArticle"].ToString();

                            string EvenementId = dr["Evenement_id"].ToString();
                            if (!String.IsNullOrEmpty(EvenementId))
                                aDao.Evenement_id = int.Parse(EvenementId); 
                            
                            aDao.Actif = bool.Parse(dr["Actif"].ToString());
                            aDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                            
                            string DateModification = dr["DateModification"].ToString();
                            if (!String.IsNullOrEmpty(DateModification))
                                aDao.DateModification = Convert.ToDateTime(DateModification); aDao.Actif = bool.Parse(dr["Actif"].ToString());
                            
                            aDao.IsLiked = Convert.ToBoolean(dr["IsLiked"].ToString());
                            listaDao.Add(aDao);
                        } else 
                            aDao = listaDao.GetArticleDao(aDao.Article_id);

                        string hashTagId = dr["HashTagArticle_id"].ToString();
                        if (!String.IsNullOrEmpty(hashTagId))
                        {
                            HashTagArticleDao hashTagDao = new HashTagArticleDao();
                            hashTagDao.HashTagArticle_id = int.Parse(hashTagId);
                            hashTagDao.Mots = dr["Mots"].ToString();
                            aDao.ListeTags.Add(hashTagDao);
                        }
                    }
                }
                con.Close();
                return listaDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public ArticlesDao GetArticlesByTag(int utilisateurId, string tag)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticlesByTag";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Tag", tag);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                ArticlesDao listaDao = new ArticlesDao();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        ArticleDao aDao = new ArticleDao();

                        aDao.Article_id = int.Parse(dr["Article_id"].ToString());

                        if (!listaDao.Contains(aDao))
                        {
                            aDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                            aDao.TitreArticle = dr["TitreArticle"].ToString();
                            aDao.ImageChemin = dr["ImageChemin"].ToString();
                            aDao.ContenuArticle = dr["ContenuArticle"].ToString();

                            string EvenementId = dr["Evenement_id"].ToString();
                            if (!String.IsNullOrEmpty(EvenementId))
                                aDao.Evenement_id = int.Parse(EvenementId); 

                            aDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                            string DateModification = dr["DateModification"].ToString();
                            if(!String.IsNullOrEmpty(DateModification))
                                aDao.DateModification = Convert.ToDateTime(DateModification);
                            aDao.Actif = bool.Parse(dr["Actif"].ToString());
                            aDao.IsLiked = Convert.ToBoolean(dr["IsLiked"].ToString());
                            listaDao.Add(aDao);
                        } else
                            aDao = listaDao.GetArticleDao(aDao.Article_id);

                        string hashTagId = dr["HashTagArticle_id"].ToString();
                        if (!String.IsNullOrEmpty(hashTagId))
                        {
                            HashTagArticleDao hashTagDao = new HashTagArticleDao();
                            hashTagDao.HashTagArticle_id = int.Parse(hashTagId);
                            hashTagDao.Mots = dr["Mots"].ToString();
                            aDao.ListeTags.Add(hashTagDao);
                        }
                    }
                }
                con.Close();
                return listaDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string LikeArticle(int utilisateurId, int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_LikeArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Article_id", articleId);

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

        public string DislikeArticle(int utilisateurId, int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DislikeArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Article_id", articleId);

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
                
        public string UpdateArticle(ArticleDao article)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateArticle";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Article_id", article.Article_id);
            cmd.Parameters.AddWithValue("@TitreArticle", article.TitreArticle);
            cmd.Parameters.AddWithValue("@ImageChemin", article.ImageChemin);
            cmd.Parameters.AddWithValue("@ContenuArticle", article.ContenuArticle);
            cmd.Parameters.AddWithValue("@Evenement_id", article.Evenement_id);

            da = new SqlDataAdapter(cmd);
           
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                string articleUpdatedId = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                if (articleUpdatedId != "PAS OK")
                {
                    foreach (HashTagArticleDao hashtag in article.ListeTags)
                    {
                        hashtag.Article_id = int.Parse(articleUpdatedId);
                        AddHashTag(hashtag, con);
                    }
                }

                return articleUpdatedId;
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

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();

                string articleCreatedId = ds.Tables[0].Rows[0]["Resultat"].ToString();

                if (articleCreatedId != "PAS OK")
                {
                    foreach (HashTagArticleDao hashtag in article.ListeTags)
                    {
                        hashtag.Article_id = int.Parse(articleCreatedId);
                        AddHashTag(hashtag, con);
                    }
                }

                return articleCreatedId;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        private void AddHashTag(HashTagArticleDao hashtag, SqlConnection con)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "BLOG_AddHashTag";
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = con;
            command.Parameters.AddWithValue("@Article_id", hashtag.Article_id);
            command.Parameters.AddWithValue("@Mots", hashtag.Mots);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
                string articleCreatedId = ds.Tables[0].Rows[0]["Resultat"].ToString();
            }
            catch (SqlException ex)
            { }
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

                return ds.Tables[0].Rows[0]["Resultat"].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        /**
         * Cette méthode ne doit pas être utilisée par les clients,
         * c'est une méthode uniquement créée pour les tests 
         * **/
        public string DeleteArticleForReal(int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DeleteArticleForReal";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Article_id", articleId);

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