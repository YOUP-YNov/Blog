using System;
using System.Collections.Generic;


namespace ModuleBlog.Controllers.Models
{
    public class Article
    {
        /// <summary>
        /// Gets or sets the article_id.
        /// </summary>
        /// <value>
        /// The article_id.
        /// </value>
        public int Article_id { get; set; }
        /// <summary>
        /// Gets or sets the blog_id.
        /// </summary>
        /// <value>
        /// The blog_id.
        /// </value>
        public int Blog_id { get; set; }
        /// <summary>
        /// Gets or sets the titre article.
        /// </summary>
        /// <value>
        /// The titre article.
        /// </value>
        public string TitreArticle { get; set; }
        /// <summary>
        /// Gets or sets the image chemin.
        /// </summary>
        /// <value>
        /// The image chemin.
        /// </value>
        public string ImageChemin { get; set; }
        /// <summary>
        /// Gets or sets the contenu article.
        /// </summary>
        /// <value>
        /// The contenu article.
        /// </value>
        public string ContenuArticle { get; set; }
        /// <summary>
        /// Gets or sets the evenement_id.
        /// </summary>
        /// <value>
        /// The evenement_id.
        /// </value>
        public int Evenement_id { get; set; }
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
        /// Gets or sets a value indicating whether this <see cref="Article"/> is actif.
        /// </summary>
        /// <value>
        ///   <c>true</c> if actif; otherwise, <c>false</c>.
        /// </value>
        public bool Actif { get; set; }

        /// <summary>
        /// Gets or sets the liste tags.
        /// </summary>
        /// <value>
        /// The liste tags.
        /// </value>
        public List<HashTagArticle> ListeTags { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        public Article()
        {

        }
    }
}
