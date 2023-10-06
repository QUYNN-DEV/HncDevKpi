using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ApiClient.Helpers
{
    public class JsonHelper
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }
    }
}
