using AutoMapper;
using ModuleBlog.BLL.Models;
using ModuleBlog.DAL;
using ModuleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.BLL
{
    public class PubliciteBLL
    {
        private PubliciteDAL adDal;

        public PubliciteBLL()
        {
            adDal = new PubliciteDAL();
        }

        public ModuleBlog.BLL.Models.Publicite GetAdByBlogId(int id)
        {
            ModuleBlog.DAL.Models.Publicite adDao = adDal.GetAdByBlogId(id);
            if (adDao != null)
            {
                Mapper.CreateMap<ModuleBlog.DAL.Models.Publicite, ModuleBlog.BLL.Models.Publicite>();
                ModuleBlog.BLL.Models.Publicite adBll = Mapper.Map<ModuleBlog.DAL.Models.Publicite, ModuleBlog.BLL.Models.Publicite>(adDao);

                return adBll;
            }
            return null;
        }

        public bool AddAd(ModuleBlog.BLL.Models.Publicite ad)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.AddAd(adDao);
        }

        public bool UpdateAdd(ModuleBlog.BLL.Models.Publicite ad)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.UpdateAd(adDao);
        }
    }
}
