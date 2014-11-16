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
    public class ArticleDAL
    {
        string strcon = Connector.ConnectionString;
        string loggerUrl = "http://loggerasp.azurewebsites.net/";
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public ArticleDAL()
        {
            con = new SqlConnection(strcon);
        }

        public Articles GetArticles(int idUtilisateur, int idBlog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticles";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UtilisateurId", idUtilisateur);
            cmd.Parameters.AddWithValue("@BlogId", idBlog);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();

               try
               {
                   da.Fill(ds);
                   con.Close();
                   Articles listaDao = new Articles();
                   foreach (DataTable table in ds.Tables)
                   {
                       foreach (DataRow dr in table.Rows)
                       {
                           Article aDao = new Article();

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
                           }
                           else
                               aDao = listaDao.Search(aDao.Article_id);

                           string hashTagId = dr["HashTagArticle_id"].ToString();
                           if (!String.IsNullOrEmpty(hashTagId))
                           {
                               HashTagArticle hashTagDao = new HashTagArticle();
                               hashTagDao.HashTagArticle_id = int.Parse(hashTagId);
                               hashTagDao.Mots = dr["Mots"].ToString();
                               aDao.ListeTags.Add(hashTagDao);
                           }
                       }
                   }
                   return listaDao;
                }
                catch(Exception ex)
               {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/GetArticles", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return null;
               }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/GetArticles", "Ouverture de la connexion à la BDD", 3).Save(loggerUrl);
                return null;
            }
        }

        public Articles GetArticlesByTag(int utilisateurId, string tag)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetArticlesByTag";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Tag", tag);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                
                try
                {
                    da.Fill(ds);
                    con.Close();
                    Articles listaDao = new Articles();
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            Article aDao = new Article();

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
                                if (!String.IsNullOrEmpty(DateModification))
                                    aDao.DateModification = Convert.ToDateTime(DateModification);
                                aDao.Actif = bool.Parse(dr["Actif"].ToString());
                                aDao.IsLiked = Convert.ToBoolean(dr["IsLiked"].ToString());
                                listaDao.Add(aDao);
                            }
                            else
                                aDao = listaDao.Search(aDao.Article_id);

                            string hashTagId = dr["HashTagArticle_id"].ToString();
                            if (!String.IsNullOrEmpty(hashTagId))
                            {
                                HashTagArticle hashTagDao = new HashTagArticle();
                                hashTagDao.HashTagArticle_id = int.Parse(hashTagId);
                                hashTagDao.Mots = dr["Mots"].ToString();
                                aDao.ListeTags.Add(hashTagDao);
                            }
                        }
                    }
                    return listaDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/GetArticleById", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return null;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/GetArticleById", "Connexion à la BDD", 3).Save(loggerUrl);
                return null;
            }
        }

        public bool LikeArticle(int utilisateurId, int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_LikeArticle";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Article_id", articleId);

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
                    new LErreur(ex, "Blog/ArticleDAL/LikeArticle", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/LikeArticle", "Connexion à la BDD", 3).Save(loggerUrl);
                return false;
            }
        }

        public bool DislikeArticle(int utilisateurId, int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DislikeArticle";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Utilisateur_id", utilisateurId);
            cmd.Parameters.AddWithValue("@Article_id", articleId);

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
                    new LErreur(ex, "Blog/ArticleDAL/DislikeArticle", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/DislikeArticle", "Connexion à la BDD", 3).Save(loggerUrl);
                return false;
            }
        }
                
        public bool UpdateArticle(Article article)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateArticle";

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
               
                try
                {
                    da.Fill(ds);
                    con.Close();

                    string articleUpdatedId = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                    if (articleUpdatedId != "PAS OK")
                    {
                        foreach (HashTagArticle hashtag in article.ListeTags)
                        {
                            hashtag.Article_id = int.Parse(articleUpdatedId);
                            AddHashTag(hashtag, con);
                        }

                        return true;
                    }

                    return false;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/UpdateArticle", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/UpdateArticle", "Connexion à la BDD", 1).Save(loggerUrl);
                return false;
            }
        }
        
        public string AddArticle(Article article)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddArticle";

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
                
                try
                {
                    da.Fill(ds);
                    con.Close();

                    string articleCreatedId = ds.Tables[0].Rows[0]["Resultat"].ToString();

                    if (articleCreatedId != "PAS OK")
                    {
                        foreach (HashTagArticle hashtag in article.ListeTags)
                        {
                            hashtag.Article_id = int.Parse(articleCreatedId);
                            AddHashTag(hashtag, con);
                        }
                    }

                    return articleCreatedId;
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/AddArticle", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/AddArticle", "Connexion à la BDD", 3).Save(loggerUrl);
                return ex.Message;
            }
        }

        private void AddHashTag(HashTagArticle hashtag, SqlConnection con)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "BLOG_AddHashTag";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = con;
            command.Parameters.AddWithValue("@Article_id", hashtag.Article_id);
            command.Parameters.AddWithValue("@Mots", hashtag.Mots);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                
                try
                {
                    da.Fill(ds);
                    string articleCreatedId = ds.Tables[0].Rows[0]["Resultat"].ToString();
                }
                catch(Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/AddHashTag", "Interraction avec la BDD", 1).Save(loggerUrl);
                    throw ex;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/AddHashTag", "Connexion à la BDD", 3).Save(loggerUrl);
                throw ex;
            }
        }

        public bool DeleteArticle(int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DeleteArticle";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ArticleId", articleId);

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
                    new LErreur(ex, "Blog/ArticleDAL/DeleteArticle", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/DeleteArticle", "Connexion à la BDD", 3).Save(loggerUrl);
                return false;
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

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Article_id", articleId);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
               
                try
                {
                    da.Fill(ds);
                    con.Close();
                    return ds.Tables[0].Rows[0]["Resultat"].ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    new LErreur(ex, "Blog/ArticleDAL/DeleteArticleForReal", "Interraction avec la BDD", 1).Save(loggerUrl);
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                new LErreur(ex, "Blog/ArticleDAL/DeleteArticleForReal", "Connexion à la BDD", 3).Save(loggerUrl);
                return ex.Message;
            }
        }

    }
}