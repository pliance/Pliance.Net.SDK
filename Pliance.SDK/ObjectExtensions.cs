using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pliance.SDK
{
    public static class ObjectExtensions
    {
        public static string UrlEncoded(this object obj)
        {
            if (obj == null)
            {
                return "";
            }

            var map = UrlEncode(obj);

            if (!map.Any())
            {
                return "";
            }

            return "?" + string.Join("&", map.Select(x => $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value.ToString())}"));
        }

        private static Dictionary<string, object> UrlEncode(object obj)
        {
            var result = new Dictionary<string, object>();

            UrlEncode(result, null, obj);
            return result;
        }

        private static void UrlEncode(Dictionary<string, object> map, string path, object obj)
        {
            if (obj == null)
            {
                return;
            }

            foreach (var item in obj.GetType().GetProperties())
            {
                var name = path != null ? $"{path}.{item.Name}" : item.Name;

                if (item.PropertyType.IsPrimitive || item.PropertyType == typeof(string))
                {
                    map[name] = item.GetValue(obj, null);
                }
                else if (item.PropertyType.IsGenericType && item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var type = item.PropertyType.GetGenericArguments()[0];

                    if (type.IsPrimitive)
                    {
                        var value = item.GetValue(obj, null);

                        if (value != null)
                        {
                            map[name] = value;
                        }
                    }
                }
                else if (item.PropertyType.IsClass)
                {
                    UrlEncode(map, name, item.GetValue(obj, null));
                }
            }
        }
    }
}
