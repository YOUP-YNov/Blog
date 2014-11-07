using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Controllers.Models
{
    /// <summary>
    /// Objet categorie
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// identifiant
        /// </summary>
        public int Categorie_id { get; set; }
        /// <summary>
        /// libellé
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Categorie()
        {

        }
    }
}
