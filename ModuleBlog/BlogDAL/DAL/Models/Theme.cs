
namespace ModuleBlog.DAL.Models
{
    public class Theme
    {
        /// <summary>
        /// Gets or sets the theme_id.
        /// </summary>
        /// <value>
        /// The theme_id.
        /// </value>
        public int Theme_id { get; set; }

        /// <summary>
        /// Gets or sets the couleur.
        /// </summary>
        /// <value>
        /// The couleur.
        /// </value>
        public string Couleur { get; set; }

        /// <summary>
        /// Gets or sets the image chemin.
        /// </summary>
        /// <value>
        /// The image chemin.
        /// </value>
        public string ImageChemin { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        public Theme()
        {

        }
    }
}
