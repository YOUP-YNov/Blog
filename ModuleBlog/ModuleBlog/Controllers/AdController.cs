using AutoMapper;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;
using ModuleBlog.Controllers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class AdController : ApiController
    {
        private PUBLICITE_BLL adBLL;

        public AdController()
        {
            adBLL = new PUBLICITE_BLL();
        }

        // GET: api/Ad
        /// <summary>
        /// Récupérer la publicité associée à un blog
        /// </summary>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>contenu de la publicité</returns>
        public Publicite Get(int blogId)
        {
            PubliciteBLL adBll = adBLL.GetAdByBlogId(blogId);
            Mapper.CreateMap<PubliciteBLL, Publicite>();
            Publicite ad = Mapper.Map<PubliciteBLL, Publicite>(adBll);

            return ad;
        }

        // POST: api/Ad
        /// <summary>
        /// Ajouter une publicite à un blog
        /// </summary>
        /// <param name="publicite">publicité à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post([FromBody]Publicite publicite)//string blogid, string largeur, string hauteur, string contenu)
        {
            if (publicite != null)
            {
                Mapper.CreateMap<Publicite, PubliciteBLL>();
                PubliciteBLL adBll = Mapper.Map<Publicite, PubliciteBLL>(publicite);
                if (adBLL.AddAd(adBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");
        }

        // PUT: api/Ad/5
        /// <summary>
        /// Mettre à jour une publicité
        /// </summary>
        /// <param name="publicite">publicité à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(int id, [FromBody]Publicite publicite)
        {
            if (publicite != null)
            {
                publicite.Publicite_id = id;
                Mapper.CreateMap<Publicite, PubliciteBLL>();
                PubliciteBLL adBll = Mapper.Map<Publicite, PubliciteBLL>(publicite);
                if (adBLL.UpdateAdd(adBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");
            }
            else
                return BadRequest("parameter is null");          
        }
    }
}
