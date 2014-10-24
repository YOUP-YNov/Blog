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
        // GET: api/Ad
        /// <summary>
        /// Récupérer les publicités associées à un blog
        /// </summary>
        /// <param name="blogId">identifiant du blog</param>
        /// <returns>liste des publicités</returns>
        public IEnumerable<Publicite> Get(int blogId)
        {
            return null;
        }

        // POST: api/Ad
        /// <summary>
        /// Créer une publicité
        /// </summary>
        /// <param name="publicite">publicité à créer</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Post(Publicite publicite)
        {
            return Ok();
        }

        // PUT: api/Ad/5
        /// <summary>
        /// Mettre à jour une publicité
        /// </summary>
        /// <param name="publicite">publicité à mettre à jour</param>
        /// <returns>Réponse HTTP</returns>
        public IHttpActionResult Put(Publicite publicite)
        {
            return Ok();
        }
    }
}
