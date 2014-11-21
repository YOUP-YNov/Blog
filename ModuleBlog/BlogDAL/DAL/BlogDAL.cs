using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ModuleBlog.DAL.Models;
using BlogDAL.DAL;


namespace ModuleBlog.DAL
{
    /// <summary>
    /// DAL pour les blogs
    /// </summary>
    public class BlogDAL : ControllerDAL
    {
        /// <summary>
        /// Récupérer la liste des blogs
        /// </summary>
        /// <returns>liste de blogs</returns>
        public List<Blog> GetBlogs()
        {
            try
            {           
                FillData("BLOG_GetBlogs", ref ds);
                List<Blog> listBDao = new List<Blog>();
                Blog bDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new Blog();
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        bDao.Theme = new ThemeDAL().GetThemeById(bDao.Theme_id);
                        listBDao.Add(bDao);
                    }
                }
                return listBDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogs", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogs", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Récupérer un blog par Id
        /// </summary>
        /// <param name="idBlog">identifiant du blog</param>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <returns>Blog</returns>

        public Blog GetBlogById(int idBlog, int userId)
        {
            try
            {
                FillData("BLOG_GetBlogById", ref ds, 
                    new Dictionary<string, object>() { {"@BlogId", idBlog}, {"@UserId", userId} });
                Blog bDao = new Blog();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        bDao.Theme = new ThemeDAL().GetThemeById(bDao.Theme_id);
                    }
                }
                return bDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogById", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogById", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Récupérer le blog d'un utilisateur
        /// </summary>
        /// <param name="userId">identifiant de l'utilisateur</param>
        /// <returns>Blog</returns>
        public Blog GetBlogByUserId(int userId)
        {
            try
            {
                FillData("BLOG_GetBlogByUserId", ref ds, new Dictionary<string,object>(){ {"@UserId", userId} });
                Blog bDao = new Blog();

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        bDao.Theme = new ThemeDAL().GetThemeById(bDao.Theme_id);
                    }
                }
                return bDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogByUserId", ex.Message, 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogByUserId", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Récupérer les blogs d'une catégorie
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <returns>Liste de blogs</returns>
        public List<Blog> GetBlogsByCategory(int categoryId)
        {
            try
            {
                FillData("BLOG_GetBlogsByCategory", ref ds, new Dictionary<string, object>() { {"@CategoryId", categoryId} });
                List<Blog> listBDao = new List<Blog>();
                Blog bDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new Blog();
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        bDao.Theme = new ThemeDAL().GetThemeById(bDao.Theme_id);
                        listBDao.Add(bDao);
                    }
                }
                con.Close();
                return listBDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsByCategory", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsByCategory", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Récupérer les blogs promus
        /// </summary>
        /// <returns>Liste de blogs</returns>
        public List<Blog> GetPromotedBlogs()
        {
            try
            {
                FillData("BLOG_GetPromotedBlogs", ref ds);
                List<Blog> listBDao = new List<Blog>();
                Blog bDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new Blog();
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        listBDao.Add(bDao);
                    }
                }
                return listBDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetPromotedBlogs", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetPromotedBlogs", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
            

        }

        /// <summary>
        /// Récupérer les blogs par recherche
        /// </summary>
        /// <param name="categoryId">identifiant de la catégorie</param>
        /// <param name="keystring">mots-clé de la recherche</param>
        /// <returns>Liste de blogs</returns>
        public List<Blog> GetBlogsBySearch(int categoryId, string keystring)
        {
            try
            {
                FillData("BLOG_GetBlogsBySearch", ref ds, 
                    new Dictionary<string, object>() { {"@Category", categoryId}, {"@KeyString", keystring} });
                List<Blog> listBDao = new List<Blog>();
                Blog bDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new Blog();
                        bDao.Blog_id = int.Parse(dr["Blog_id"].ToString());
                        bDao.Utilisateur_id = int.Parse(dr["Utilisateur_id"].ToString());
                        bDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        bDao.TitreBlog = dr["TitreBlog"].ToString();
                        bDao.DateCreation = DateTime.Parse(dr["DateCreation"].ToString());
                        bDao.Actif = bool.Parse(dr["Actif"].ToString());
                        bDao.Promotion = bool.Parse(dr["Promotion"].ToString());
                        bDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        listBDao.Add(bDao);
                    }
                }
                return listBDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsBySearch", ex.Message, 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsBySearch", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
           
        }

        /// <summary>
        /// Ajout d'un blog
        /// </summary>
        /// <param name="blog">blog</param>
        /// <returns>True si ajout / False sinon</returns>
        public bool AddBlog(Blog blog)
        {
            try
            {            
                Dictionary<string, object> listParams = new Dictionary<string, object>();            
                listParams.Add("@UserId", blog.Utilisateur_id);
                listParams.Add("@Title", blog.TitreBlog);
                listParams.Add("@Category", blog.Categorie_id);
                listParams.Add("@Theme", blog.Theme_id);
                FillData("BLOG_AddBlog", ref ds, listParams);                
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/AddBlog", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/AdBlog", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Mise à jour d'un blog
        /// </summary>
        /// <param name="blog">blog</param>
        /// <returns>True si update / False sinon</returns>
        public bool UpdateBlog(Blog blog)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@UserId", blog.Utilisateur_id);
                listParams.Add("@Title", blog.TitreBlog);
                listParams.Add("@Category", blog.Categorie_id);
                listParams.Add("@Theme", blog.Theme_id);
                listParams.Add("@Actif", blog.Actif);
                FillData("BLOG_UpdateBlog", ref ds, listParams);
                if (string.Equals(ds.Tables[0].Rows[0]["Resultat"].ToString(), "OK"))
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/UpdateBLog", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/UpdateBLog", ex.Message, 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Promouvoir un blog
        /// </summary>
        /// <param name="userId">identifiant d'un utilisateur</param>
        /// <param name="promoted">promotion</param>
        /// <returns>True si promu / False sinon</returns>
        public bool PromoteBlog(int userId, bool promoted)
        {
            try
            {
                Dictionary<string, object> listParams = new Dictionary<string, object>();
                listParams.Add("@UserId", userId);
                listParams.Add("@Promoted", promoted);
                FillData("BLOG_PromoteBlog", ref ds, listParams); 
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/PromoteBlog", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/PromoteBlog", ex.Message, 1);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Désactivation d'un blog
        /// </summary>
        /// <param name="userId">identifiant d'un utilisateur</param>
        /// <returns>True si désactivé / False sinon</returns>
        public bool DeleteBlog(int userId)
        {
            try
            {
                FillData("BLOG_DeleteBlog", ref ds, new Dictionary<string, object>() { {"@userId", userId} });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/DeleteBlog", ex.Message, 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/DeleteBlog", ex.Message, 1);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}