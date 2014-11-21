using System;

namespace ModuleBlog.DAL.Models
{
    public class Blog
    {
        /// <summary>
        /// Gets or sets the blog_id.
        /// </summary>
        /// <value>
        /// The blog_id.
        /// </value>
        public int Blog_id { get; set; }

        /// <summary>
        /// Gets or sets the utilisateur_id.
        /// </summary>
        /// <value>
        /// The utilisateur_id.
        /// </value>
        public int Utilisateur_id { get; set; }

        /// <summary>
        /// Gets or sets the titre blog.
        /// </summary>
        /// <value>
        /// The titre blog.
        /// </value>
        public string TitreBlog { get; set; }

        /// <summary>
        /// Gets or sets the date creation.
        /// </summary>
        /// <value>
        /// The date creation.
        /// </value>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Gets or sets the categorie_id.
        /// </summary>
        /// <value>
        /// The categorie_id.
        /// </value>
        public int Categorie_id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Blog"/> is actif.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actif; otherwise, <c>false</c>.
        /// </value>
        public bool Actif { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Blog"/> is promotion.
        /// </summary>
        /// <value>
        ///   <c>true</c> if promotion; otherwise, <c>false</c>.
        /// </value>
        public bool Promotion { get; set; }

        /// <summary>
        /// Gets or sets the theme_id.
        /// </summary>
        /// <value>
        /// The theme_id.
        /// </value>
        public int Theme_id { get; set; }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>
        /// The theme.
        /// </value>
        public Theme Theme { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Blog"/> class.
        /// </summary>
        public Blog()
        {

        }
    }
}
