using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ModuleBlog.DAL.Models;
using BlogDAL.DAL;

namespace ModuleBlog.DAL
{
    /// <summary>
    /// DAL pour les commentaires
    /// </summary>
    public class CommentaireDAL : ControllerDAL
    {
        /// <summary>
        /// Récupérer la liste des commentaires d'un article
        /// </summary>
        /// <param name="articleId">identifiant d'un article</param>
        /// <returns>liste des commentaires</returns>
        public List<Commentaire> GetCommentaires(int articleId)
        {
            try
            {
                FillData("BLOG_GetCommentaires", ref ds, new Dictionary<string, object>() { { "@ArticleId", articleId } });
                List<Commentaire> listCDao = new List<Commentaire>();
                foreach (DataTable table in ds.Tables)
                {
                    Commentaire cDao = new Commentaire();
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
                return listCDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/GetCommentaires", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/GetCommentaires", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// Récupérer un commentaire
        /// </summary>
        /// <param name="commentaireId">identifiant d'un commentaire</param>
        /// <returns>commentaire</returns>
        public Commentaire GetCommentaireById(int commentaireId)
        {
            try
            {
                FillData("BLOG_GetCommentaireById", ref ds, new Dictionary<string, object>() { { "@CommentaireId", commentaireId } });         
                Commentaire cDao = new Commentaire();
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
                return cDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/GetCommentaireById", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/GetCommentaireById", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Ajout d'un commentaire
        /// </summary>
        /// <param name="commentaire">commentaire</param>
        /// <returns>True si ajout / False sinon</returns>
        public bool AddCommentaire(Commentaire commentaire)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@ArticleId", commentaire.Article_id);
                listParams.Add("@UtilisateurId", commentaire.Utilisateur_id);
                listParams.Add("@ContenuCommentaire", commentaire.ContenuCommentaire);
                FillData("BLOG_AddCommentaire", ref ds, listParams);
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/AddCommentaire", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/AddCommentaire", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Mise à jour d'un commentaire
        /// </summary>
        /// <param name="commentaire">commentaire</param>
        /// <returns>True si update / False sinon</returns>
        public bool UpdateCommentaire(Commentaire commentaire)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@CommentaireId", commentaire.Commentaire_id);
                listParams.Add("@ContenuCommentaire", commentaire.ContenuCommentaire);
                listParams.Add("@Actif", commentaire.Actif);
                FillData("BLOG_UpdateCommentaire", ref ds, listParams);
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/UpdateCommentaire", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/UpdateCommentaire", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Report d'un commentaire
        /// </summary>
        /// <param name="commentId">identifiant du commentaire</param>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <returns>True si report / False sinon</returns>
        public bool ReportCommentaire(int commentId,int userId )
        {
            try
            {
                FillData("BLOG_ReportCommentaire", ref ds, 
                    new Dictionary<string, object>() { { "@CommentaireId", commentId }, { "@UserId", userId } });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/ReportCommentaire", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/ReportCommentaire", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// désactivation d'un commentaire
        /// </summary>
        /// <param name="commentId">identifiant du commentaire</param>
        /// <returns>True si désactivation / False sinon</returns>
        public bool DeleteCommentaire(int commentaireId)
        {
            try
            {
                FillData("BLOG_DeleteCommentaire", ref ds, new Dictionary<string, object>() { {"@CommentaireId", commentaireId} });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CommentaireDAL/DeleteCommentaire", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/CommentaireDAL/DeleteCommentaire", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}