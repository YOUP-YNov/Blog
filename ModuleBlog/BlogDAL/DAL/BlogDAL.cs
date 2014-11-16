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
    public class BlogDAL : ControllerDAL
    {
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
                LogException(ex, "Blog/BlogDAL/GetBlogs", "SqlException", 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogs", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/GetBlogById", "SqlException", 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogById", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/GetBlogByUserId", "SqlException", 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogByUserId", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/GetBlogsByCategory", "SqlException", 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsByCategory", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/GetPromotedBlogs", "SqlException", 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetPromotedBlogs", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
            

        }
        
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
                LogException(ex, "Blog/BlogDAL/GetBlogsBySearch", "SqlException", 1);
                return null;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/GetBlogsBySearch", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
           
        }
        
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
                LogException(ex, "Blog/BlogDAL/AddBlog", "SqlException", 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/AdBlog", "Exception", 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/UpdateBLog", "SqlException", 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/UpdateBLog", "Exception", 1);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
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
                LogException(ex, "Blog/BlogDAL/PromoteBlog", "SqlException", 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/PromoteBlog", "Exception", 1);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public bool DeleteBlog(int userId)
        {
            try
            {
                FillData("BLOG_DeleteBlog", ref ds, new Dictionary<string, object>() { {"@userId", userId} });
                return (ds.Tables[0].Rows[0]["Resultat"].ToString() == "OK");
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/BlogDAL/DeleteBlog", "SqlException", 1);
                return false;
            }
            catch(Exception ex)
            {
                LogException(ex, "Blog/BlogDAL/DeleteBlog", "Exception", 1);
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