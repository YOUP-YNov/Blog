using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL.Models
{
    /// <summary>
    /// Objet catégorie
    /// </summary>
    public class CategorieBLL
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
        public CategorieBLL()
        {

        }
    }
}
