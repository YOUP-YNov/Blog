using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuleBlog.DAL.Models
{
    public class Articles : List<Article>
    {
        public new bool Contains(Article articleToMatch)
        {
            foreach(Article article in this)
            {
                if (article.Article_id == articleToMatch.Article_id)
                    return true;
            }

            return false;
        }

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