using System.Collections.Generic;
using ModelMate.Map;

namespace UnitTest
{
    internal static class DynamicMappings
    {
        public static IEnumerable<IMap> GetMappings()
        {
            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "CustomerName",
                             MapTo = "CustomerName"
                         };

            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "Email",
                             MapTo = "Email"
                         };

            yield return new ObjectMap
                         {
                             DataType = typeof (object),
                             FieldName = "Company",
                             MapTo = "",
                             Mappings = GetCompanyMaps()
                         };

            yield return new CollectionMap
                         {
                             DataType = typeof (IEnumerable<object>),
                             FieldName = "Addresses",
                             MapTo = "Addresses",
                             Mappings = GetAddressMaps()
                         };
        }

        private static IEnumerable<IMap> GetCompanyMaps()
        {
            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "DBA",
                             MapTo = "CompanyName"
                         };

            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "PhoneNumber",
                             MapTo = "Phone"
                         };
        }

        private static IEnumerable<IMap> GetAddressMaps()
        {
            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "Street1",
                             MapTo = "Street"
                         };

            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "City",
                             MapTo = "City"
                         };

            yield return new FieldMap
                         {
                             DataType = typeof (string),
                             FieldName = "State",
                             MapTo = "State"
                         };

            yield return new FieldMap
                         {
                             DataType = typeof (int),
                             FieldName = "ZipCode",
                             MapTo = "Zip"
                         };
        }
    }
}