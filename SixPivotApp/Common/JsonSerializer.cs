using Newtonsoft.Json;
using SixPivotApp.Common.Interfaces;

namespace SixPivotApp
{
    public class JsonSerializer : IJsonSerializer
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}