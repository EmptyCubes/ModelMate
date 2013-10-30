using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ModelMate.Helpers;
using ModelMate.Map;
using Newtonsoft.Json;

namespace ModelMate
{
    public class DefaultTranslator : ITranslater
    {
        public DefaultTranslator()
        {
        }

        public DefaultTranslator(IEnumerable<IMap> mappings)
        {
            Mappings = mappings;
        }

        public IEnumerable<IMap> Mappings { get; set; }

        public object Translate(object source)
        {
            return Translate(source,
                             Mappings);
        }

        public object Translate(dynamic source,
                                IEnumerable<IMap> mappings)
        {
            return OnTranslate(source,
                               mappings,
                               new ExpandoObject());
        }

        public T Translate<T>(object source)
        {
            return Translate<T>(source,
                                Mappings);
        }

        public T Translate<T>(object source,
                              IEnumerable<IMap> mappings)
        {
            //TODO: This should be a reflection based mapper
            var translated = Translate(source,
                                       mappings);

            var json = JsonConvert.SerializeObject(translated);
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected object OnTranslate(object source,
                                     IEnumerable<IMap> mappings,
                                     IDictionary<string, object> context)
        {
            foreach (var map in mappings)
            {
                var obj = source.GetValue(map.FieldName);
                var val = Converter.ToType(obj,
                                           map.DataType);

                var collection = map as IMapCollection;
                if (collection != null)
                {
                    if (collection.IsArray &&
                        string.IsNullOrEmpty(collection.MapTo))
                        throw new FormatException("Unable to insert IEnumerable into context root.");

                    if (string.IsNullOrEmpty(collection.MapTo))
                    {
                        OnTranslate(obj,
                                    collection.Mappings,
                                    context);

                        //Because we are merging we don't want to add a nested object
                        continue;
                    }

                    if (collection.IsArray)
                    {
                        val = OnTranslateCollection((IEnumerable) val,
                                                    collection.Mappings);
                    }
                    else
                    {
                        val = OnTranslate(val,
                                          collection.Mappings,
                                          new ExpandoObject());
                    }
                }

                context.Add(map.MapTo,
                            val);
            }

            return context;
        }

        protected IEnumerable<ExpandoObject> OnTranslateCollection(IEnumerable source,
                                                                   IEnumerable<IMap> mappings)
        {
            var items = new ArrayList();
            foreach (var item in source)
            {
                items.Add(OnTranslate(item,
// ReSharper disable once PossibleMultipleEnumeration
                                      mappings,
                                      new ExpandoObject()));
            }
            return items.Cast<ExpandoObject>()
                        .ToArray();
        }
    }
}
