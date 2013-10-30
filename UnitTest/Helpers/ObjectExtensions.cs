using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTest.Helpers
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            var dictionary = source as IDictionary<string, object>;
            if (dictionary != null)
            {
                return dictionary;
            }

            return source.GetType()
                         .GetProperties(bindingAttr)
                         .ToDictionary
                (
                 propInfo => propInfo.Name,
                 propInfo => propInfo.GetValue(source, (object[])null)
                );

        }
    }
}
