using AutoMapper;
using ModuleBlog.BLL;
using ModuleBlog.BLL.Models;
using ModuleBlog.Controllers.Models;
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
        /// Ajouter une publicité à un blog
        /// </summary>
        /// <param name="blogid">id du blog concerné</param>
        /// <param name="largeur">largeur de la publicité</param>
        /// <param name="hauteur">hauteur de la publicité</param>
        /// <param name="contenu">contenu de la publicité</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(string blogid, string largeur, string hauteur, string contenu)
        {
            try
            {
                int blogidint = Convert.ToInt32(blogid);
                int largeurint = Convert.ToInt32(largeur);
                int hauteurint = Convert.ToInt32(hauteur);
                if(contenu == string.Empty)
                    throw new ArgumentException();
                Publicite publicite = new Publicite(blogidint, largeurint, hauteurint, contenu);
                Mapper.CreateMap<Publicite, PubliciteBLL>();
                PubliciteBLL adBll = Mapper.Map<Publicite, PubliciteBLL>(publicite);
                if(adBLL.AddAd(adBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");

            }
            catch(ArgumentException)
            {
                return BadRequest("parameters are not correct.");
            }
            catch (FormatException)
            {
                return BadRequest("paramaters format is not correct.");
            }
        }

        // PUT: api/Ad/5
        /// <summary>
        /// Mettre à jour une publicité pour un blog
        /// </summary>
        /// <param name="blogid"></param>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <param name="contenu"></param>
        /// <returns></returns>
        public IHttpActionResult Put(int id, string blogid, string largeur, string hauteur, string contenu)
        {
            try
            {
                int blogidint = Convert.ToInt32(blogid);
                int largeurint = Convert.ToInt32(largeur);
                int hauteurint = Convert.ToInt32(hauteur);
                if (contenu == string.Empty)
                    throw new ArgumentException();
                Publicite publicite = new Publicite(id, blogidint, largeurint, hauteurint, contenu);
                Mapper.CreateMap<Publicite, PubliciteBLL>();
                PubliciteBLL adBll = Mapper.Map<Publicite, PubliciteBLL>(publicite);
                if (adBLL.UpdateAdd(adBll))
                    return StatusCode(HttpStatusCode.Created);
                else
                    return BadRequest("an error occured");

            }
            catch (ArgumentException)
            {
                return BadRequest("parameters are not correct.");
            }
            catch (FormatException)
            {
                return BadRequest("paramaters format is not correct.");
            }            
        }
    }
}
