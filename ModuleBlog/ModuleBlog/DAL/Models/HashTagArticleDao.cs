﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.DAL.Models
{
    public class HashTagArticleDao
    {
        public int HashTagArticle_id { get; set; }
        public int Article_id { get; set; }
        public string Mots { get; set; }

        public HashTagArticleDao()
        {

        }
    }
}
