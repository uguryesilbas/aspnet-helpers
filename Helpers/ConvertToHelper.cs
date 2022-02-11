using System;

namespace Helpers
{

    public static class ConvertToHelper
    {
        public static T As<T>(this object obj) where T : IComparable
        {
            try
            {
                Type type = typeof(T);

                if (obj != null)
                {
                    if (!IsNullableType(type) && !string.IsNullOrEmpty(obj.ToString()))
                        return (T)Convert.ChangeType(obj, type);

                    else if (string.IsNullOrEmpty(obj.ToString()))
                        return default(T);
                }

                return (T)Convert.ChangeType(obj, Nullable.GetUnderlyingType(type));
            }
            catch
            {
                return default(T);
            }
        }

        private static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
