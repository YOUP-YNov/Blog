using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBlog.Controllers
{
    class MapperConverter
    {
        public IEnumerable<U> Convert<T, U>(IEnumerable<T> element)
        {
            return Mapper.Map<IEnumerable<T>, IEnumerable<U>>(element);
        }

        public U Convert<T, U>(T element)
        {
            return Mapper.Map<T, U>(element);
        }
    }
}
    