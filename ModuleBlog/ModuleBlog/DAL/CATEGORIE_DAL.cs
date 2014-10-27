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
    public class CATEGORIE_DAL
    {      
        //string strcon = ConfigurationManager.ConnectionStrings["YoupDEV"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public CATEGORIE_DAL()
        {
            string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
                   @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
            con = new SqlConnection(strcon);
        }
        

        public List<CategorieDao> GetCategories()
        {
            ds = new DataSet();
            
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetCategories";
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                da.Fill(ds);
                List<CategorieDao> listCDao = new List<CategorieDao>();
                foreach (DataTable table in ds.Tables)
                {
                    CategorieDao cDao = new CategorieDao();
                    foreach (DataRow dr in table.Rows)
                    {
                        cDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        cDao.Libelle = dr["Libelle"].ToString();
                    }
                    listCDao.Add(cDao);
                }

                con.Close();
                return listCDao;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}