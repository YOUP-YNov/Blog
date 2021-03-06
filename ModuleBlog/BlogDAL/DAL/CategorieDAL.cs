﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        /// <returns>liste de catégorie</returns>
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
                LogException(SqlE, "Blog/CategorieDAL/GetCategories", SqlE.Message, 1);
                return null;
            }
            catch (FormatException formatE)
            {
                LogException(formatE, "Blog/CategorieDAL/GetCategories", formatE.Message, 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/CategorieDAL/GetCategories", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Categorie GetCategoryById(int id)
        {
            try
            {
                FillData("BLOG_GetCategoryById", ref ds,
                    new Dictionary<string, object>() { { "@CategoryId", id }});

                Categorie cDao = new Categorie();
                foreach (DataTable table in ds.Tables)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        cDao.Categorie_id = int.Parse(dr["Categorie_id"].ToString());
                        cDao.Libelle = dr["Libelle"].ToString();
                    }
                }
                return cDao;
            }
            catch (SqlException ex)
            {
                LogException(ex, "Blog/CategorieDal/GetCategoryById", ex.Message, 1);
                return null;
            }
            catch (Exception ex)
            {
                LogException(ex, "Blog/CategorieDal/GetCategoryById", ex.Message, 1);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}