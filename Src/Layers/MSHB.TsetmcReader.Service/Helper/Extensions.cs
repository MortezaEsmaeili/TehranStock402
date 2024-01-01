using AutoMapper;
using System.Collections.Generic;

namespace MSHB.TsetmcReader.Service.Helper
{
    public static class Extensions
    {
        private static Mapper _mapper = MapperConfig.Instance;
        public static string ToCleanString(this string input)
        {
            return input.Replace("ی", "ي").Replace("ک", "ك");
        }
        public static IEnumerable<T> Convert<S,T>(this IEnumerable<S> source) 
            where T:class
            where S : class
        {
           return _mapper.Map<IEnumerable<T>>(source);
        }
    }
}
