using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.DAL.Models
{
    public class Commentaire
    {
        public int Commentaire_id { get; set; }
        public int Article_id { get; set; }
        public int Utilisateur_id { get; set; }
        public string ContenuCommentaire { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool Actif { get; set; }

        public Commentaire()
        {
                
        }
    }
}
