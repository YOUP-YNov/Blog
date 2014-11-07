using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.DAL.Models
{
    /// <summary>
    /// Objet catégorie
    /// </summary>
    public class CategorieDao
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
        /// constructeur
        /// </summary>
        public CategorieDao()
        {

        }
    }
}
