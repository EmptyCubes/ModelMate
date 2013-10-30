using System;

namespace ModelMate.Map
{
    public class FieldMap : IMap
    {
        public string FieldName { get; set; }
        public Type DataType { get; set; }
        public string MapTo { get; set; }
    }
}
