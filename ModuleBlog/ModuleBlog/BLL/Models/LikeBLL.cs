using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL.Models
{
    public class LikeBLL
    {
        public int Like_id { get; set; }
        public int Utilisateur_id { get; set; }
        public int Article_id { get; set; }

        public LikeBLL()
        {

        }
    }
}
