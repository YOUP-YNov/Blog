using AutoMapper;
using ModuleBlog.DAL;


namespace ModuleBlog.BLL
{
    public class PubliciteBLL
    {
        private PubliciteDAL adDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="PubliciteBLL"/> class.
        /// </summary>
        public PubliciteBLL()
        {
            adDal = new PubliciteDAL();
        }

        /// <summary>
        /// Gets the ad by blog identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds the ad.
        /// </summary>
        /// <param name="ad">The ad.</param>
        /// <returns></returns>
        public bool AddAd(ModuleBlog.BLL.Models.Publicite ad)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.AddAd(adDao);
        }

        /// <summary>
        /// Updates the add.
        /// </summary>
        /// <param name="ad">The ad.</param>
        /// <returns></returns>
        public bool UpdateAdd(ModuleBlog.BLL.Models.Publicite ad)
        {
            Mapper.CreateMap<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>();
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.UpdateAd(adDao);
        }
    }
}
