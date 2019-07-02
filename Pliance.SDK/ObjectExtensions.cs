using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Pliance.SDK
{
    public class Box<T>
    {
        public T Item { get; }

        public Box(T item)
        {
            Item = item;
        }
    }

    public static class ObjectExtensions
    {
        public static string UrlEncoded(this object obj)
        {
            if (obj == null)
            {
                return "";
            }

            var map = new Dictionary<string, object>();
            
            UrlEncode(map, null, obj, null);

            if (!map.Any())
            {
                return "";
            }

            return "?" + string.Join("&", map.Select(x => $"{HttpUtility.UrlEncode(x.Key)}={HttpUtility.UrlEncode(x.Value.ToString())}"));
        }

        private static void UrlEncode(Dictionary<string, object> map, string path, object obj, PropertyInfo prop)
        {
            if (obj == null)
            {
                return;
            }

            if (prop?.PropertyType.IsPrimitive == true || prop?.PropertyType == typeof(string))
            {
                map[path] = obj;
            }
            else if (prop?.PropertyType.IsGenericType == true && prop?.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                object element = obj;
                var boxType = typeof(Box<>);
                Type[] typeArgs = { element.GetType() };
                var makeme = boxType.MakeGenericType(typeArgs);
                var box = Activator.CreateInstance(makeme, element);

                UrlEncode(map, $"{path}", element, box.GetType().GetProperty("Item"));
            }
            else if (prop?.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)) == true)
            {
                var index = 0;
                var array = (IEnumerable)obj;

                foreach (var element in array)
                {
                    var boxType = typeof(Box<>);
                    Type[] typeArgs = { element.GetType() };
                    var makeme = boxType.MakeGenericType(typeArgs);
                    var box = Activator.CreateInstance(makeme, element);

                    UrlEncode(map, $"{path}[{index++}]", element, box.GetType().GetProperty("Item"));
                }
            }
            else
            {
                foreach (var item in obj.GetType().GetProperties())
                {
                    var name = path != null ? $"{path}.{item.Name}" : item.Name;

                    UrlEncode(map, name, item.GetValue(obj, null), item);
                }
            }
        }
    }
}
