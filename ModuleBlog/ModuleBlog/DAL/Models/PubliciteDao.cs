﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.DAL.Models
{
    public class PubliciteDao
    {
        public int Publicite_id { get; set; }
        public int Blog_id { get; set; }
        public int Largeur { get; set; }
        public int Hauteur { get; set; }
        public string ContenuPublicite { get; set; }

        public PubliciteDao()
        {

        }
    }
}
