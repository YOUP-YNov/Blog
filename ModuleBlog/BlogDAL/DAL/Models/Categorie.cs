
namespace ModuleBlog.DAL.Models
{
    /// <summary>
    /// Objet catégorie
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
        /// constructeur
        /// </summary>
        public Categorie()
        {

        }
    }
}
