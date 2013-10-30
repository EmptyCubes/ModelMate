using System;
using System.Collections.Generic;

namespace ModelMate.Map
{
    public class CollectionMap : IMapCollection
    {
        public string FieldName { get; set; }
        public Type DataType { get; set; }
        public string MapTo { get; set; }
        public bool IsArray { get { return true; } }
        public IEnumerable<IMap> Mappings { get; set; }
    }
}
