using AutoMapper;
using ModuleBlog.DAL;


namespace ModuleBlog.BLL
{
    /// <summary>
    /// Classe de gestion des publicités pour la couche BLL
    /// </summary>
    public class PubliciteBLL
    {
        /// <summary>
        /// Instance de la couche DAL pour les publicités
        /// </summary>
        private PubliciteDAL adDal;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="PubliciteBLL"/>.
        /// </summary>
        public PubliciteBLL()
        {
            adDal = new PubliciteDAL();
        }

        /// <summary>
        /// Récupérer la publicité associée à un blog
        /// </summary>
        /// <param name="id">identifiant du blog</param>
        /// <returns>Publicité</returns>
        public ModuleBlog.BLL.Models.Publicite GetAdByBlogId(int id)
        {
            ModuleBlog.DAL.Models.Publicite adDao = adDal.GetAdByBlogId(id);
            if (adDao != null)
            {                
                ModuleBlog.BLL.Models.Publicite adBll = Mapper.Map<ModuleBlog.DAL.Models.Publicite, ModuleBlog.BLL.Models.Publicite>(adDao);
                return adBll;
            }
            return null;
        }

        /// <summary>
        /// Ajouter une publicité
        /// </summary>
        /// <param name="ad">Publicité</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool AddAd(ModuleBlog.BLL.Models.Publicite ad)
        {
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.AddAd(adDao);
        }

        /// <summary>
        /// Mettre à jour une publicité
        /// </summary>
        /// <param name="ad">Publicité</param>
        /// <returns>True si DAL OK / False sinon</returns>
        public bool UpdateAdd(ModuleBlog.BLL.Models.Publicite ad)
        {
            ModuleBlog.DAL.Models.Publicite adDao = Mapper.Map<ModuleBlog.BLL.Models.Publicite, ModuleBlog.DAL.Models.Publicite>(ad);
            return adDal.UpdateAd(adDao);
        }
    }
}
