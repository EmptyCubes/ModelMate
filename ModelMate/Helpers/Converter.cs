using System;

namespace ModelMate.Helpers
{
    internal static class Converter
    {
        public static object ToType(object source,
                                    Type type)
        {
            var t = typeof (Converter);
            var method = t.GetMethod("CastTo");

            var generic = method.MakeGenericMethod(new[]
                                            {
                                                type
                                            });

            return generic.Invoke(null,
                                  new[]
                                  {
                                      source
                                  });
        }

        public static T CastTo<T>(object source)
        {
            return (T) source;
        }
    }
}