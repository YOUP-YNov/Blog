using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class MapperConverter : ApiController
    {
        /// <summary>
        /// Converts the specified element.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDest">The type of the dest.</typeparam>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public IEnumerable<TDest> Convert<TSource, TDest>(IEnumerable<TSource> element)
        {
            try
            {
                return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(element);
            }
            catch(AutoMapperMappingException)
            {
                // TODO LOGGER
                return default(IEnumerable<TDest>);
            }
        }

        /// <summary>
        /// Converts the specified element.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDest">The type of the dest.</typeparam>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public TDest Convert<TSource, TDest>(TSource element)
        {
            try
            {
                return Mapper.Map<TSource, TDest>(element);
            }
            catch (AutoMapperMappingException)
            {
                // TODO LOGGER
                return default(TDest);
            }
        }
    }
}
    