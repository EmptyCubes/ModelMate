using System;

namespace ModelMate.Map
{
    public interface IMap
    {
        string FieldName { get; set; }
        Type DataType { get; set; }

        string MapTo { get; set; }
    }
}