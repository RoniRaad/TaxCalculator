using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace TaxCalculator.Core.Extensions
{
    public static class HtmlGetExtension
    {
        public static string ObjToGetString(this object obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.IgnoreNullValues = true;

            var serializedObject = JsonSerializer.Serialize(obj, options);

            var deserializedObject = JsonSerializer.Deserialize<IDictionary<string, object>>(serializedObject);

            var enumerableObject = deserializedObject.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value.ToString()));

            return string.Join("&", enumerableObject);
        }
    }
}
