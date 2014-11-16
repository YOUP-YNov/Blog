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
    /// Couche DAL des catégories des blogs
    /// </summary>
    public class CategorieDAL : ControllerDAL
    { 
        /// <summary>
        /// Récupération de la liste des catégories
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategories()
        {
            try
            {                
                FillData("BLOG_GetCategories", ref ds);                
                List<Categorie> listCDao = new List<Categorie>();
                Categorie cDao;
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        cDao = new Categorie();
                        cDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        cDao.Libelle = dr["Libelle"].ToString();
                        listCDao.Add(cDao);
                    }
                }
                return listCDao;
            }
            catch (SqlException SqlE)
            {
                LogException(SqlE, "Blog/CategorieDAL/GetCategories", "SqlException", 1);
                return null;
            }
            catch (FormatException formatE)
            {
                LogException(formatE, "Blog/CategorieDAL/GetCategories", "FormatException", 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/CategorieDAL/GetCategories", "Exception", 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}