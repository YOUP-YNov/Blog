using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Controllers.Models
{
    public class Publicite
    {
        public int Publicite_id { get; set; }
        public int Blog_id { get; set; }
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public string ContenuPublicite { get; set; }

        public Publicite()
        {

        }

        public Publicite(int blog_id, int largeur, int hauteur, string contenu)
        {
            //Publicite_id = publicite_id;
            Blog_id = blog_id;
            Largeur = largeur;
            Hauteur = hauteur;
            ContenuPublicite = contenu;
        }

        public Publicite(int publicite_id, int blog_id, int largeur, int hauteur, string contenu)
            : this(blog_id, largeur, hauteur, contenu)
        {
            Publicite_id = publicite_id;
        }
    }
}
