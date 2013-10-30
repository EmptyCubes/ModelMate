using System;
using System.Collections.Generic;

namespace ModelMate.Map
{
    public class ObjectMap : IMapCollection
    {
        public string FieldName { get; set; }
        public Type DataType { get; set; }
        public string MapTo { get; set; }
        public bool IsArray { get { return false; } }
        public IEnumerable<IMap> Mappings { get; set; }
    }
}
