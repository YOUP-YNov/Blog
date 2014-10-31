﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL.Models
{
    public class BlogBLL
    {
        public int Blog_id { get; set; }
        public int Utilisateur_id { get; set; }
        public string TitreBlog { get; set; }
        public DateTime DateCreation { get; set; }
        public int Categorie_id { get; set; }
        public bool Actif { get; set; }
        public bool Promotion { get; set; }
        public int Theme_id { get; set; }
        public ThemeBLL Theme { get; set; }

        public BlogBLL()
        {

        }
    }
}
