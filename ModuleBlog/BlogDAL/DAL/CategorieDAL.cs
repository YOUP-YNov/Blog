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
    public class CategorieDAL
    {
        #region propriétés
        //string strcon = Connector.ConnectionString;
        /// <summary>
        /// Objet permettant d'effecture des requêtes à la BDD
        /// </summary>
        SqlCommand cmd;
        /// <summary>
        /// Objet de gestion de la connexion à la BDD
        /// </summary>
        SqlConnection con;
        /// <summary>
        /// Objet Tableau recevant les données récupérées par la requête
        /// </summary>
        SqlDataAdapter da;
        /// <summary>
        /// Dataset que l'on rempli grâce au SqlDataAdapter permettant de naviguer entre les lignes et colonnes
        /// </summary>
        DataSet ds; 
        #endregion

        string strcon = Connector.ConnectionString;
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public CategorieDAL()
        {
            //string strcon = @"User id =YoupDev;Password=youpD3VASP*;" +
            //       @"Server=avip9np4yy.database.windows.net,1433;Database=YoupDev";
            con = new SqlConnection(strcon);
        }
        
        /// <summary>
        /// Récupération de la liste des catégories
        /// </summary>
        /// <returns></returns>
        public List<Categorie> GetCategories()
        {
            ds = new DataSet();
            
            cmd = new SqlCommand();
            cmd.CommandText = "BLOG_GetCategories";




            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                try
                {
                    da.Fill(ds);
                    con.Close();
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