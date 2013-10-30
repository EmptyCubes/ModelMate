using System.Linq;

namespace ModelMate.Helpers
{
    static class ObjectExtensions
    {
        public static object GetValue(this object obj,
                                      string fieldName)
        {
            var type = obj.GetType();
            var field = type.GetFields()
                            .FirstOrDefault(m => m.Name == fieldName);

            if (field != null)
            {
                return field.GetValue(obj);
            }

            var property = type.GetProperties()
                               .FirstOrDefault(m => m.Name == fieldName);

            if (property != null)
            {
                return property.GetValue(obj,
                                         null);
            }

            return null;
        }

        public static bool IsArray(this object obj)
        {
            var type = obj.GetType();
            return type.IsArray;
        }
    }
}
