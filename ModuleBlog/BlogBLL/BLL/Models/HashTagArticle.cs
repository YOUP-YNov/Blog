using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL.Models
{
    public class HashTagArticle
    {
        public int HashTagArticle_id { get; set; }
        public int Article_id { get; set; }
        public string Mots { get; set; }

        public HashTagArticle()
        {

        }
    }
}