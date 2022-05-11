using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Mapper
{
    public static class MapperExtension
    {
        public static List<T> MapList<T>(this IMapper mapper, IEnumerable<object> sourses)
        {
            var result = new List<T>();

            foreach(var sourse in sourses)
            {
                result.Add(mapper.Map<T>(sourse));
            }

            return result;
        }
    }
}
