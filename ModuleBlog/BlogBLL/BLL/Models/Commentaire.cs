using System;


namespace ModuleBlog.BLL.Models
{
    public class Commentaire
    {
        /// <summary>
        /// Gets or sets the commentaire_id.
        /// </summary>
        /// <value>
        /// The commentaire_id.
        /// </value>
        public int Commentaire_id { get; set; }

        /// <summary>
        /// Gets or sets the article_id.
        /// </summary>
        /// <value>
        /// The article_id.
        /// </value>
        public int Article_id { get; set; }

        /// <summary>
        /// Gets or sets the utilisateur_id.
        /// </summary>
        /// <value>
        /// The utilisateur_id.
        /// </value>
        public int Utilisateur_id { get; set; }

        /// <summary>
        /// Gets or sets the contenu commentaire.
        /// </summary>
        /// <value>
        /// The contenu commentaire.
        /// </value>
        public string ContenuCommentaire { get; set; }

        /// <summary>
        /// Gets or sets the date creation.
        /// </summary>
        /// <value>
        /// The date creation.
        /// </value>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Gets or sets the date modification.
        /// </summary>
        /// <value>
        /// The date modification.
        /// </value>
        public DateTime DateModification { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Commentaire"/> is actif.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actif; otherwise, <c>false</c>.
        /// </value>
        public bool Actif { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Commentaire"/> class.
        /// </summary>
        public Commentaire()
        {
                
        }
    }
}
