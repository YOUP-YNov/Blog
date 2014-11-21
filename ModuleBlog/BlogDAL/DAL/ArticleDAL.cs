using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ModuleBlog.DAL.Models;
using BlogDAL.DAL;


namespace ModuleBlog.DAL
{
    public class ArticleDAL : ControllerDAL
    {
        public Articles GetArticles(int idUtilisateur, int idBlog)
        {
            try
            {
                FillData("BLOG_GetArticles", ref ds, new Dictionary<string,object>(){ {"@UtilisateurId", idUtilisateur}, {"@BlogId", idBlog}});
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

                        con.Close();

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
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/GetArticles", ex.Message, 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/GetArticles", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Articles GetArticlesByTag(int utilisateurId, string tag)
        {
            try
            {
                FillData("BLOG_GetArticlesByTag", ref ds, new Dictionary<string,object>(){ {"@Utilisateur_id", utilisateurId}, {"@Tag", tag}});
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

                        con.Close();

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
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/GetArticlesByTag", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/GetArticlesByTag", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool LikeArticle(int utilisateurId, int articleId)
        {
            try
            {
                FillData("BLOG_LikeArticle", ref ds, new Dictionary<string,object>(){ {"@Utilisateur_id", utilisateurId}, {"@Article_id", articleId} });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/LikeArticle", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/LikeArticle", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DislikeArticle(int utilisateurId, int articleId)
        {
            try
            {
                FillData("BLOG_DislikeArticle", ref ds, new Dictionary<string,object>(){ {"@Utilisateur_id", utilisateurId}, {"@Article_id", articleId} });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");

            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/DislikeArticle", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/DislikeArticle", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
                
        public bool UpdateArticle(Article article)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@Article_id", article.Article_id);
                listParams.Add("@TitreArticle", article.TitreArticle);
                listParams.Add("@ImageChemin", article.ImageChemin);
                listParams.Add("@ContenuArticle", article.ContenuArticle);
                listParams.Add("@Evenement_id", article.Evenement_id);
                FillData("BLOG_UpdateArticle", ref ds, listParams);
                string articleUpdatedId = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                con.Close();

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
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/UpdateArticle", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/UpdateArticle", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public string AddArticle(Article article)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@Blog_id", article.Blog_id);
                listParams.Add("@TitreArticle", article.TitreArticle);
                listParams.Add("@ImageChemin", article.ImageChemin);
                listParams.Add("@ContenuArticle", article.ContenuArticle);
                listParams.Add("@Evenement_id", article.Evenement_id);
                FillData("BLOG_AddArticle", ref ds, listParams);
                string articleCreatedId = ds.Tables[0].Rows[0]["Resultat"].ToString();

                con.Close();

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
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/AddArticle", ex.Message, 1);
                return ex.Message;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/AddArticle", ex.Message, 1);
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        private void AddHashTag(HashTagArticle hashtag, SqlConnection con)
        {
            try
            {
                FillData("BLOG_AddHashTag", ref ds, new Dictionary<string,object>(){ {"@Article_id", hashtag.Article_id}, {"@Mots", hashtag.Mots} });                
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/AddHashTag", ex.Message, 1);
                throw ex;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/AddHashTag", ex.Message, 1);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DeleteArticle(int articleId)
        {
            try
            {
                FillData("BLOG_DeleteArticle", ref ds, new Dictionary<string, object>() { { "@ArticleId", articleId } });              
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/DeleteArticle", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/DeleteArticle", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /**
         * Cette méthode ne doit pas être utilisée par les clients,
         * c'est une méthode uniquement créée pour les tests 
         * **/
        public string DeleteArticleForReal(int articleId)
        {
            try
            {
                FillData("BLOG_DeleteArticleForReal", ref ds, new Dictionary<string, object>() { { "@Article_id", articleId } });
                return ds.Tables[0].Rows[0]["Resultat"].ToString();
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/ArticleDAL/DeleteArticleForReal", ex.Message, 1);
                return ex.Message;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/ArticleDAL/DeleteArticleForReal", ex.Message, 1);
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }
}