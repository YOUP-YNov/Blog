
namespace ModuleBlog.BLL.Models
{
    public class HashTagArticle
    {
        /// <summary>
        /// Gets or sets the hash tag article_id.
        /// </summary>
        /// <value>
        /// The hash tag article_id.
        /// </value>
        public int HashTagArticle_id { get; set; }

        /// <summary>
        /// Gets or sets the article_id.
        /// </summary>
        /// <value>
        /// The article_id.
        /// </value>
        public int Article_id { get; set; }

        /// <summary>
        /// Gets or sets the mots.
        /// </summary>
        /// <value>
        /// The mots.
        /// </value>
        public string Mots { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashTagArticle"/> class.
        /// </summary>
        public HashTagArticle()
        {

        }
    }
}