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
            CreateMapPublicite();
        }
        private static void CreateMapBlog()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Blog, ModuleBlog.Controllers.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.BLL.Models.Theme, ModuleBlog.Controllers.Models.Theme>();

            Mapper.CreateMap<ModuleBlog.Controllers.Models.Blog, ModuleBlog.BLL.Models.Blog>();
            Mapper.CreateMap<ModuleBlog.Controllers.Models.Theme, ModuleBlog.BLL.Models.Theme>();
        }

        private static void CreateMapPublicite()
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.Controllers.Models.Publicite>();

            Mapper.CreateMap<ModuleBlog.Controllers.Models.Publicite, ModuleBlog.BLL.Models.Publicite>();
        }
    }
}
