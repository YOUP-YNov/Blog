using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ModuleBlog.DAL
{
    public class BLOG_DAL
    {
        string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
               @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
       // string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmdselect = null;
        SqlCommand cmdupdate = null;
        SqlCommand cmddelete = null;
        SqlCommand cmdinsert = null;
        SqlConnection con;
        SqlDataAdapter da;

        public DataSet DeleteBlog(int userId)
        {
            DataSet ds = new DataSet();
            con = new SqlConnection(strcon);
            cmddelete = new SqlCommand();
            cmddelete.CommandText = "BLOG_DeleteBlog";
            cmddelete.CommandTimeout = 0;
            cmddelete.CommandType = CommandType.StoredProcedure;
            cmddelete.Connection = con;
            da = new SqlDataAdapter(cmddelete);
            cmddelete.Parameters.Add(new SqlParameter("@UserId",
                   SqlDbType.BigInt, 12, "User_id"));
            cmddelete.Parameters["@UserId"].Value = userId;
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return ds;
        }

        public BlogDao GetBlogById(int idBlog)
        {
            DataSet ds = new DataSet();
            BlogDao bDao = new BlogDao();
            con = new SqlConnection(strcon);
            cmdselect = new SqlCommand();
            cmdselect.CommandText = "BLOG_GetBlogById";
            cmdselect.CommandTimeout = 0;
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.Connection = con;
            da = new SqlDataAdapter(cmdselect);
            cmdselect.Parameters.Add(new SqlParameter("@BlogId",
                      SqlDbType.BigInt, 12, "Blog_id"));
            cmdselect.Parameters.Add(new SqlParameter("@UserId",
                      SqlDbType.BigInt, 12, "User_id"));
            cmdselect.Parameters["@BlogId"].Value = idBlog;
            cmdselect.Parameters["@UserId"].Value = 7;
            // à définir la valeur du user ID ou l'a recupere t-on?
            try
            {
                con.Open();
                da.Fill(ds);
                
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
                    }
                }
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            return bDao;
        }

        public BlogDao GetBlogByCategory(int categoryId)
        {
            DataSet ds = new DataSet();
            BlogDao bDao = new BlogDao();
            con = new SqlConnection(strcon);
            cmdselect = new SqlCommand();
            cmdselect.CommandText = "BLOG_GetBlogByCategory";
            cmdselect.CommandTimeout = 0;
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.Connection = con;
            da = new SqlDataAdapter(cmdselect);
            cmdselect.Parameters.Add(new SqlParameter("@CategoryId",
                      SqlDbType.BigInt, 12, "Category_id"));
            cmdselect.Parameters.Add(new SqlParameter("@CategoryId",
                      SqlDbType.BigInt, 12, "Category_id"));
            cmdselect.Parameters["@CategoryId"].Value = categoryId;
            

            try
            {
                con.Open();

                da.Fill(ds);
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
                    }
                }
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            return bDao;
        }
        public List<BlogDao> GetBlogs()
        {
            DataSet ds = new DataSet();
            List<BlogDao> listBDao = new List<BlogDao>();
            con = new SqlConnection(strcon);
            cmdselect = new SqlCommand();
            cmdselect.CommandText = "BLOG_GetBlogs";
            cmdselect.CommandTimeout = 0;
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.Connection = con;
            da = new SqlDataAdapter(cmdselect);

            try
            {
                con.Open();
                da.Fill(ds);
                foreach (DataTable table in ds.Tables)
                {
                    BlogDao bDao = new BlogDao();
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
                    }
                    listBDao.Add(bDao);
                }

                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            return listBDao;

        }

        public List<BlogDao> GetBlogsBySearch(int categoryId, string keystring)
        {
            DataSet ds = new DataSet();
            List<BlogDao> listBDao = new List<BlogDao>();
            con = new SqlConnection(strcon);
            cmdselect = new SqlCommand();
            cmdselect.CommandText = "BLOG_GetBlogBySearch";
            cmdselect.CommandTimeout = 0;
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.Connection = con;
            da = new SqlDataAdapter(cmdselect);
            cmdselect.Parameters.Add(new SqlParameter("@CategoryId",
                      SqlDbType.BigInt, 12, "Category_id"));
            cmdselect.Parameters.Add(new SqlParameter("@KeyString",
                      SqlDbType.VarChar, 50, "TitreBlog"));
            cmdselect.Parameters["@CategoryId"].Value = categoryId;
            cmdselect.Parameters["@KeyString"].Value = keystring;
            try
            {
                con.Open();
                da.Fill(ds);
                foreach (DataTable table in ds.Tables)
                {
                    BlogDao bDao = new BlogDao();
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
                    }
                    listBDao.Add(bDao);
                }
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            return listBDao;
        }

        public List<BlogDao> GetPromotedBlogs()
        {
            DataSet ds = new DataSet();
            List<BlogDao> listBDao = new List<BlogDao>();
            con = new SqlConnection(strcon);
            cmdselect = new SqlCommand();
            cmdselect.CommandText = "BLOG_GetPromotedBlogs";
            cmdselect.CommandTimeout = 0;
            cmdselect.CommandType = CommandType.StoredProcedure;
            cmdselect.Connection = con;
            da = new SqlDataAdapter(cmdselect);

            try
            {
                con.Open();
                da.Fill(ds);
                foreach (DataTable table in ds.Tables)
                {
                    BlogDao bDao = new BlogDao();
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
                    }
                    listBDao.Add(bDao);
                }
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            return listBDao;

        }

        public DataSet PromoteBlog(int userId)
        {
            DataSet ds = new DataSet();
            con = new SqlConnection(strcon);
            cmdupdate = new SqlCommand();
            cmdupdate.CommandText = "BLOG_PromoteBlog";
            cmdupdate.CommandTimeout = 0;
            cmdupdate.CommandType = CommandType.StoredProcedure;
            cmdupdate.Connection = con;
            da = new SqlDataAdapter(cmdupdate);
            cmdupdate.Parameters.Add(new SqlParameter("@UserId",
                   SqlDbType.BigInt, 12, "User_id"));
            cmdupdate.Parameters["@UserId"].Value = userId;
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return ds;
        }

        public DataSet UpdateBlog(BlogDao blog)
        {

            DataSet ds = new DataSet();
            con = new SqlConnection(strcon);
            cmdupdate = new SqlCommand();
            cmdupdate.CommandText = "BLOG_PromoteBlog";
            cmdupdate.CommandTimeout = 0;
            cmdupdate.CommandType = CommandType.StoredProcedure;
            cmdupdate.Connection = con;
            da = new SqlDataAdapter(cmdupdate);
            cmdupdate.Parameters.Add(new SqlParameter("@UserId",
                   SqlDbType.BigInt, 12, "User_id"));
            cmdupdate.Parameters["@UserId"].Value = blog.Utilisateur_id;
            cmdupdate.Parameters.Add(new SqlParameter("@Title",
                   SqlDbType.VarChar, 50, "Titre_blog"));
            cmdupdate.Parameters["@Title"].Value = blog.TitreBlog;
            cmdupdate.Parameters.Add(new SqlParameter("@Category",
                   SqlDbType.BigInt, 12, "Category_id"));
            cmdupdate.Parameters["@Category"].Value = blog.Categorie_id;
            cmdupdate.Parameters.Add(new SqlParameter("@Theme",
                   SqlDbType.BigInt, 12, "Theme_id"));
            cmdupdate.Parameters["@Theme"].Value = blog.Theme_id;
           
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return ds;
        }


        public DataSet AddBlog(BlogDao blog)
        {

            DataSet ds = new DataSet();
            con = new SqlConnection(strcon);
            cmdinsert = new SqlCommand();
            cmdinsert.CommandText = "BLOG_AddBlog";
            cmdinsert.CommandTimeout = 0;
            cmdinsert.CommandType = CommandType.StoredProcedure;
            cmdinsert.Connection = con;
            da = new SqlDataAdapter(cmdinsert);
            cmdinsert.Parameters.Add(new SqlParameter("@UserId",
                   SqlDbType.BigInt, 12, "User_id"));
            cmdinsert.Parameters["@UserId"].Value = blog.Utilisateur_id;
            cmdinsert.Parameters.Add(new SqlParameter("@Title",
                   SqlDbType.VarChar, 50, "Titre_blog"));
            cmdinsert.Parameters["@Title"].Value = blog.TitreBlog;
            cmdinsert.Parameters.Add(new SqlParameter("@Category",
                   SqlDbType.BigInt, 12, "Category_id"));
            cmdinsert.Parameters["@Category"].Value = blog.Categorie_id;
            cmdinsert.Parameters.Add(new SqlParameter("@Theme",
                   SqlDbType.BigInt, 12, "Theme_id"));
            cmdinsert.Parameters["@Theme"].Value = blog.Theme_id;
            cmdinsert.Parameters.Add(new SqlParameter("@CreationDate",
                   SqlDbType.DateTime, 12, "CreationDate"));
            cmdinsert.Parameters["@Theme"].Value = blog.DateCreation;


            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (SqlException)
            {
                throw;
            }

            return ds;
        }

    }
}