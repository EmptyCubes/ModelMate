using System.Collections.Generic;

namespace ModelMate.Map
{
    public interface IMapCollection : IMap
    {
        bool IsArray { get; }
        IEnumerable<IMap> Mappings { get; set; }
    }
}
