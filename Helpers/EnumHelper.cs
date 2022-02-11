using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T value) where T : System.Enum
        {
            try
            {
                FieldInfo field = value.GetType().GetField(value.ToString());

                if (field != null && field.GetCustomAttributes(typeof(DescriptionAttribute), true) is DescriptionAttribute[] { Length: > 0 } attributes)
                {
                    return attributes.First().Description;
                }
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }
    }
}
