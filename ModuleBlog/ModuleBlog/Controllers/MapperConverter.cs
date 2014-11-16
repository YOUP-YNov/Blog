using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ModuleBlog.Controllers
{
    public class MapperConverter : ApiController
    {
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
    