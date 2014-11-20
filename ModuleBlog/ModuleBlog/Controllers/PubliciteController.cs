using AutoMapper;
using ModuleBlog.BLL;
using BLLModels = ModuleBlog.BLL.Models;
using ControllersModels = ModuleBlog.Controllers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class PubliciteController : MapperConverter
    {
        private PubliciteBLL adBLL;

        public PubliciteController()
        {
            adBLL = new PubliciteBLL();
        }
        
        // GET: api/Ad
        /// <summary>
        /// Récupérer la publicité associée à un blog
        /// </summary>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>contenu de la publicité</returns>
        [HttpGet, Route("api/ad")]
        public ControllersModels.Publicite Get(int blogId)
        {
            BLLModels.Publicite adBll = adBLL.GetAdByBlogId(blogId);
            ControllersModels.Publicite ad = Convert<BLLModels.Publicite, ControllersModels.Publicite>(adBll);

            return ad;
        }

        // POST: api/Ad
        /// <summary>
        /// Ajouter une publicite à un blog
        /// </summary>
        /// <param name="publicite">publicité à ajouter</param>
        /// <returns>Réponse HTTP</returns>
        [HttpPost, Route("api/ad")]
        public IHttpActionResult Post([FromBody]ControllersModels.Publicite publicite)//string blogid, string largeur, string hauteur, string contenu)
        {
            if (publicite != null)
            {
                if (publicite.Blog_id == 0 || publicite.Largeur == 0
                    || publicite.Hauteur == 0 || publicite.ContenuPublicite == string.Empty)
                    return BadRequest("parameters format is not correct.");
                BLLModels.Publicite adBll = Convert<ControllersModels.Publicite, BLLModels.Publicite>(publicite);
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
        /// <param name="id">identifiant de la publicité</param>
        /// <param name="publicite">publicité à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        [HttpPut, Route("api/ad/{id}")]
        public IHttpActionResult Put(int id, [FromBody]ControllersModels.Publicite publicite)
        {
            if (publicite != null)
            {
                if (id == 0 || publicite.Blog_id == 0 || publicite.Largeur == 0 
                    || publicite.Hauteur == 0 || publicite.ContenuPublicite == string.Empty)
                    return BadRequest("parameters format is not correct.");
                publicite.Publicite_id = id;
                BLLModels.Publicite adBll = Convert<ControllersModels.Publicite, BLLModels.Publicite>(publicite);
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
