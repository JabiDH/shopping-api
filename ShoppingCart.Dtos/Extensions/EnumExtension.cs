using ShoppingCart.Dtos.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Dtos.Enums;

namespace ShoppingCart.Dtos.Extensions
{
    public static class EnumExtension
    {
        public static T GetEnumValueFromStringValue<T>(this Enum enumType, string stringValue) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = (EnumStringValueAttribute)Attribute.GetCustomAttribute(field, typeof(EnumStringValueAttribute));

                if (attribute != null && string.Equals(attribute.Value, stringValue, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException($"No enum value with string value '{stringValue}' found in {typeof(T).Name}");
        }
    }
}
