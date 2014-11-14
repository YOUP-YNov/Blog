using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void CreateMap()
        {
            CreateMapBlog();
        }
        private static void CreateMapBlog()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();
        }

        private static void CreateMapCommentaire()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Commentaire, ModuleBlog.Controllers.Models.Commentaire>();
            Mapper.CreateMap<ModuleBlog.Controllers.Models.Commentaire, ModuleBlog.BLL.Models.Commentaire>();
           
        }
    }
}
