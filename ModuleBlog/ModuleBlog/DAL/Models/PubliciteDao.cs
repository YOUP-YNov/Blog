using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.DAL.Models
{
    public class PubliciteDao
    {
        public int Publicite_id { get; set; }
        public int Blog_id { get; set; }
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public string ContenuPublicite { get; set; }

        public PubliciteDao()
        {

        }

        public PubliciteDao(int blogId, int largeur, int hauteur, string contenu)
        {
            Blog_id = blogId;
            Largeur = largeur;
            Hauteur = hauteur;
            ContenuPublicite = contenu;
        }
    }
}
