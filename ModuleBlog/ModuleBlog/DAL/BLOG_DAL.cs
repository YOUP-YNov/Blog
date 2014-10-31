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
    public class BLOG_DAL
    {
        

        //string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public BLOG_DAL()
        {
            string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
                   @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
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
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public BlogBLL GetBlogById(int idBlog, int userId)
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
                da.Fill(ds);
                BlogBLL bDao = new BlogBLL();

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
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<BlogBLL> GetBlogsByCategory(int categoryId)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogByCategory";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            da = new SqlDataAdapter(cmd);           

            try
            {
                con.Open();
                da.Fill(ds);
                List<BlogBLL> listBDao = new List<BlogBLL>();
                BlogBLL bDao;

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new BlogBLL();
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
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<BlogBLL> GetBlogs()
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
                da.Fill(ds);
                List<BlogBLL> listBDao = new List<BlogBLL>();
                BlogBLL bDao;
                foreach (DataTable table in ds.Tables)
                {

                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new BlogBLL();
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
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<BlogBLL> GetBlogsBySearch(int categoryId, string keystring)
        {
            ds = new DataSet();

            cmd= new SqlCommand();
            cmd.CommandText = "BLOG_GetBlogBySearch";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.Parameters.AddWithValue("@KeyString", keystring);

            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                List<BlogBLL> listBDao = new List<BlogBLL>();
                BlogBLL bDao;

                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new BlogBLL();
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
            catch (SqlException ex)
            {
                throw ex;
            }
           
        }

        public List<BlogBLL> GetPromotedBlogs()
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
                da.Fill(ds);
                List<BlogBLL> listBDao = new List<BlogBLL>();
                BlogBLL bDao;

                foreach (DataTable table in ds.Tables)
                {
                    
                    foreach (DataRow dr in table.Rows)
                    {
                        bDao = new BlogBLL();
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
            catch (SqlException ex)
            {
                throw ex;
            }
            

        }

        public string PromoteBlog(int userId, bool promoted)
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
                da.Fill(ds);
                con.Close();

                return ds.Tables[0].Rows[0].ToString();
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBlog(BlogBLL blog)
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


        public string AddBlog(BlogBLL blog)
        {
            ds = new DataSet();

            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_AddBlog";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@UserId", blog.Utilisateur_id);
            cmd.Parameters.AddWithValue("@Title", blog.TitreBlog);
            cmd.Parameters.AddWithValue("@CreationDate", blog.DateCreation);
            cmd.Parameters.AddWithValue("@Category", blog.Categorie_id);
            cmd.Parameters.AddWithValue("@Theme", blog.Theme_id);

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

        public ThemeDao GetThemeById(int themeId)
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
                con.Open();
                da.Fill(ds);
                ThemeDao tDao = new ThemeDao();

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
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}