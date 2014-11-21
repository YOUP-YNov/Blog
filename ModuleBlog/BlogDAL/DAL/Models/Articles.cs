using System.Collections.Generic;


namespace ModuleBlog.DAL.Models
{
    public class Articles : List<Article>
    {
        /// <summary>
        /// Determines whether [contains] [the specified article to match].
        /// </summary>
        /// <param name="articleToMatch">The article to match.</param>
        /// <returns></returns>
        public new bool Contains(Article articleToMatch)
        {
            foreach(Article article in this)
            {
                if (article.Article_id == articleToMatch.Article_id)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the specified article identifier.
        /// </summary>
        /// <param name="articleId">The article identifier.</param>
        /// <returns></returns>
        public Article Search(int articleId)
        {
            foreach (Article article in this)
            {
                if (article.Article_id == articleId)
                    return article;
            }

            return null;
        }
    }
}