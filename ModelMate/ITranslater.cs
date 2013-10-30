using System.Collections.Generic;
using ModelMate.Map;

namespace ModelMate
{
    public interface ITranslater
    {
        IEnumerable<IMap> Mappings { get; set; }

        object Translate(object source);

        object Translate(object source,
                         IEnumerable<IMap> mappings);

        T Translate<T>(object source);

        T Translate<T>(object source,
                       IEnumerable<IMap> mappings);
    }
}
