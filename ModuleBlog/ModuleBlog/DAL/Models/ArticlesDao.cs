using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleBlog.DAL.Models
{
    public class ArticlesDao : List<ArticleDao>
    {
        public new bool Contains(ArticleDao articleToMatch)
        {
            foreach(ArticleDao article in this)
            {
                if (article.Article_id == articleToMatch.Article_id)
                    return true;
            }

            return false;
        }

        public ArticleDao GetArticleDao(int articleId)
        {
            foreach (ArticleDao article in this)
            {
                if (article.Article_id == articleId)
                    return article;
            }

            return null;
        }
    }
}