using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Controllers.Models
{
    public class Article
    {
        public int Article_id { get; set; }
        public int Blog_id { get; set; }
        public string TitreArticle { get; set; }
        public string ImageChemin { get; set; }
        public string ContenuArticle { get; set; }
        public int Evenement_id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool Actif { get; set; }

        public List<HashTagArticle> ListeTags { get; set; }
        public Article()
        {

        }
    }
}
