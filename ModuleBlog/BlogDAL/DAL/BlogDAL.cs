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
    public class BlogDAL
    {

        string strcon = Connector.ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public BlogDAL()
        {
            con = new SqlConnection(strcon);
        }
        public string DeleteBlog(int userId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_DeleteBlog";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
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

        public Blog GetBlogById(int idBlog, int userId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogById";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@BlogId", idBlog);
            cmd.Parameters.AddWithValue("@UserId", userId);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
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
                        bDao.Theme = GetThemeById(bDao.Theme_id);
                    }
                }
                con.Close();
                return bDao;
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

        public List<Blog> GetBlogsByCategory(int categoryId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogsByCategory";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            da = new SqlDataAdapter(cmd);           

            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
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
                        bDao.Theme = GetThemeById(bDao.Theme_id);
                        listBDao.Add(bDao);
                    }
                }
                con.Close();
                return listBDao;
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
        public List<Blog> GetBlogs()
        {
            ds = new DataSet();
            
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogs";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
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
                        bDao.Theme = GetThemeById(bDao.Theme_id);
                        listBDao.Add(bDao);
                    }
                }

                con.Close();
                return listBDao;
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

        public List<Blog> GetBlogsBySearch(int categoryId, string keystring)
        {
            ds = new DataSet();

            cmd= new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogsBySearch";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Category", categoryId);
            cmd.Parameters.AddWithValue("@KeyString", keystring);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
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
                con.Close();
                return listBDao;
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

        public List<Blog> GetPromotedBlogs()
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetPromotedBlogs";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
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
                con.Close();
                return listBDao;
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

        public bool PromoteBlog(int userId, bool promoted)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_PromoteBlog";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Promoted", promoted);

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
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public bool UpdateBlog(Blog blog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_UpdateBlog";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", blog.Utilisateur_id);
            cmd.Parameters.AddWithValue("@Title", blog.TitreBlog);
            cmd.Parameters.AddWithValue("@Category", blog.Categorie_id);
            cmd.Parameters.AddWithValue("@Theme", blog.Theme_id);
            cmd.Parameters.AddWithValue("@Actif", blog.Actif);

            da = new SqlDataAdapter(cmd);
           
            try
            {
                con.Open();
                try
                {
                da.Fill(ds);
                con.Close();
                if (string.Equals(ds.Tables[0].Rows[0]["Resultat"].ToString(), "OK"))
                    return true;
                else
                    return false;
            }
                catch(Exception ex)
                {
                    con.Close();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }


        public bool AddBlog(Blog blog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddBlog";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", blog.Utilisateur_id);
            cmd.Parameters.AddWithValue("@Title", blog.TitreBlog);
            cmd.Parameters.AddWithValue("@Category", blog.Categorie_id);
            cmd.Parameters.AddWithValue("@Theme", blog.Theme_id);

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
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public Theme GetThemeById(int themeId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetThemeById";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ThemeId", themeId);


            da = new SqlDataAdapter(cmd);

            try
            {
                if(con.State == ConnectionState.Closed)
                    con.Open();
                try
                {
                da.Fill(ds);
                Theme tDao = new Theme();

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        tDao.Theme_id = int.Parse(dr["Theme_id"].ToString());
                        tDao.Couleur = dr["Couleur"].ToString();
                        tDao.ImageChemin = dr["ImageChemin"].ToString();
                    }
                }
                con.Close();
                return tDao;
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

    }
}