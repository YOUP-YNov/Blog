
namespace ModuleBlog.Controllers.Models
{
    public class Publicite
    {
        /// <summary>
        /// Gets or sets the publicite_id.
        /// </summary>
        /// <value>
        /// The publicite_id.
        /// </value>
        public int Publicite_id { get; set; }

        /// <summary>
        /// Gets or sets the blog_id.
        /// </summary>
        /// <value>
        /// The blog_id.
        /// </value>
        public int Blog_id { get; set; }

        /// <summary>
        /// Gets or sets the largeur.
        /// </summary>
        /// <value>
        /// The largeur.
        /// </value>
        public int Largeur { get; set; }

        /// <summary>
        /// Gets or sets the hauteur.
        /// </summary>
        /// <value>
        /// The hauteur.
        /// </value>
        public int Hauteur { get; set; }

        /// <summary>
        /// Gets or sets the contenu publicite.
        /// </summary>
        /// <value>
        /// The contenu publicite.
        /// </value>
        public string ContenuPublicite { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Publicite"/> class.
        /// </summary>
        public Publicite()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Publicite"/> class.
        /// </summary>
        /// <param name="blog_id">The blog_id.</param>
        /// <param name="largeur">The largeur.</param>
        /// <param name="hauteur">The hauteur.</param>
        /// <param name="contenu">The contenu.</param>
        public Publicite(int blog_id, int largeur, int hauteur, string contenu)
        {
            //Publicite_id = publicite_id;
            Blog_id = blog_id;
            Largeur = largeur;
            Hauteur = hauteur;
            ContenuPublicite = contenu;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Publicite"/> class.
        /// </summary>
        /// <param name="publicite_id">The publicite_id.</param>
        /// <param name="blog_id">The blog_id.</param>
        /// <param name="largeur">The largeur.</param>
        /// <param name="hauteur">The hauteur.</param>
        /// <param name="contenu">The contenu.</param>
        public Publicite(int publicite_id, int blog_id, int largeur, int hauteur, string contenu)
            : this(blog_id, largeur, hauteur, contenu)
        {
            Publicite_id = publicite_id;
        }
    }
}
