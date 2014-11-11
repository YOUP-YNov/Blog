using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModuleBlog.Controllers.Models;
using ModuleBlog.DAL.Models;

namespace ModuleBlog.DAL
{
    public class COMMENTAIRE_DAL
    {

        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;


        public COMMENTAIRE_DAL()
        {
            con = new SqlConnection(strcon);
        }

        public string DeleteCommentaire(int commentaireId)
        {
            DataSet ds = new DataSet();
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
                try
                {
                    da.Fill(ds);
                    con.Close();
                    return ds.Tables[0].Rows[0]["Resultat"].ToString();
                }
                catch(Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }


        public CommentaireDao GetCommentaireById(int commentaireId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetCommentaireById";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CommentaireId", commentaireId);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
                    CommentaireDao cDao = new CommentaireDao();

                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            cDao.ContenuCommentaire = Convert.ToString(dr["ContenuCommentaire"].ToString());
                            cDao.Actif = Convert.ToBoolean(dr["Actif"].ToString());
                            cDao.Article_id = Convert.ToInt32(dr["Article_id"].ToString());
                            cDao.Commentaire_id = Convert.ToInt32(dr["Commentaire_id"].ToString());
                            cDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                            cDao.Utilisateur_id = Convert.ToInt32(dr["Utilisateur_id"].ToString());
                            if (!String.IsNullOrEmpty(dr["DateModification"].ToString()))
                            {
                                cDao.DateModification = Convert.ToDateTime(dr["DateModification"].ToString());
                            }


                        }
                    }
                    con.Close();
                    return cDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    throw ex;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<CommentaireDao> GetCommentaires(int articleId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetCommentaires";
            cmd.CommandTimeout = 0;
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
                    List<CommentaireDao> listCDao = new List<CommentaireDao>();

                    foreach (DataTable table in ds.Tables)
                    {
                        CommentaireDao cDao = new CommentaireDao();
                        foreach (DataRow dr in table.Rows)
                        {
                            cDao.ContenuCommentaire = Convert.ToString(dr["ContenuCommentaire"].ToString());
                            cDao.Actif = Convert.ToBoolean(dr["Actif"].ToString());
                            cDao.Article_id = Convert.ToInt32(dr["Article_id"].ToString());
                            cDao.Commentaire_id = Convert.ToInt32(dr["Commentaire_id"].ToString());
                            cDao.DateCreation = Convert.ToDateTime(dr["DateCreation"].ToString());
                            if (!String.IsNullOrEmpty(dr["DateModification"].ToString()))
                            {
                                cDao.DateModification = Convert.ToDateTime(dr["DateModification"].ToString());
                            }
                            cDao.Utilisateur_id = Convert.ToInt32(dr["Utilisateur_id"].ToString());
                            listCDao.Add(cDao);
                        }

                    }
                    con.Close();
                    return listCDao;
                }
                catch(Exception ex)
                {
                    con.Close();
                    throw ex;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public string AddCommentaire(CommentaireDao commentaire)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddCommentaire";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ArticleId", commentaire.Article_id);
            cmd.Parameters.AddWithValue("@UtilisateurId", commentaire.Utilisateur_id);
            cmd.Parameters.AddWithValue("@CreationDate", commentaire.DateCreation);
            cmd.Parameters.AddWithValue("@ContenuCommentaire", commentaire.ContenuCommentaire);
           

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
                catch(Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string UpdateCommentaire(CommentaireDao commentaire)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateCommentaire";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CommentaireId", commentaire.Commentaire_id);
            cmd.Parameters.AddWithValue("@ContenuCommentaire", commentaire.ContenuCommentaire);
            cmd.Parameters.AddWithValue("@ModificationDate", commentaire.DateModification);
       

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
                catch(Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string ReportCommentaire(int commentId,int userId )
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_ReportCommentaire";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CommentaireId", commentId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            

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
                catch(Exception ex)
                {
                    con.Close();
                    return ex.Message;
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        

    }
}