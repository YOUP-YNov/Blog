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
    public class PUBLICITE_BLL
    {
        private PUBLICITE_DAL adDal;

        public PUBLICITE_BLL()
        {
            adDal = new PUBLICITE_DAL();
        }

        public PubliciteBLL GetAdByBlogId(int id)
        {
            PubliciteDao adDao = adDal.GetAdByBlogId(id);
            if (adDao != null)
            {
                Mapper.CreateMap<PubliciteDao, PubliciteBLL>();
                PubliciteBLL adBll = Mapper.Map<PubliciteDao, PubliciteBLL>(adDao);

                return adBll;
            }
            return null;
        }

        public bool AddAd(PubliciteBLL ad)
        {
            Mapper.CreateMap<PubliciteBLL, PubliciteDao>();
            PubliciteDao adDao = Mapper.Map<PubliciteBLL, PubliciteDao>(ad);
            string add = adDal.AddAd(adDao);
            if (string.Equals(add, "OK"))
                return true;
            else
                return false;
        }

        public bool UpdateAdd(PubliciteBLL ad)
        {
            Mapper.CreateMap<PubliciteBLL, PubliciteDao>();
            PubliciteDao adDao = Mapper.Map<PubliciteBLL, PubliciteDao>(ad);
            string updateResult = adDal.UpdateAd(adDao);
            if (string.Equals(updateResult, "OK"))
                return true;
            else
                return false;
        }
    }
}
