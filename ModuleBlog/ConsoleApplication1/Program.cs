using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuleBlog;
using ModuleBlog.DAL;
using System.Data.SqlClient;
using ModuleBlog.DAL.Models;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BLOG_DAL obj = new BLOG_DAL();
            BlogDao bDao = new BlogDao();



            Console.WriteLine("1.{0}\n2.{1}\n3.{2}\n4.{3}\n5.{4}\n6.{5}\n7.{6}\n8.{7}",

                bDao.Actif, bDao.Blog_id, bDao.Categorie_id, bDao.DateCreation, bDao.Promotion, bDao.Theme_id, bDao.TitreBlog, bDao.Utilisateur_id);
            Console.ReadLine();
        }
    }
}
