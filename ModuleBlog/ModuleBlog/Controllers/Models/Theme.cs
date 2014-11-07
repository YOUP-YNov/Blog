using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Controllers.Models
{
    public class Theme
    {
        public int Theme_id { get; set; }
        public string Couleur { get; set; }
        public string ImageChemin { get; set; }
        public Theme()
        {
            
        }
    }
}
